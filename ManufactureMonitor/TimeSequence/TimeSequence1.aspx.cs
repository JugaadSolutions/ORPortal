using ManufactureMonitor.DALayer;
using ManufactureMonitor.Entity;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManufactureMonitor
{
    public partial class TimeSequence1 : System.Web.UI.Page
    {
        static DataTable dt, dt1, dt2;
        static List<TimeSequence> Ts;
        static List<DataTable> dts;
        static List<String> fileNames;
        static List<String> sheetNames;
        static bool SpeedLoss;
      
        static String From;
        static String To;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR  " + Session["Machinegroupname"];
            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();


                dts = new List<DataTable>();
                fileNames = new List<string>();
                sheetNames = new List<string>();

                dt = da.GetMachines(Convert.ToInt32(Session["MachineGroup"]));
                MachineSelectionListBox.DataSource = dt.DefaultView;
                MachineSelectionListBox.DataValueField = "Machines";
                MachineSelectionListBox.DataBind();


            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Menu.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Calendar1.SelectedDate == DateTime.MinValue || Calendar2.SelectedDate == DateTime.MinValue)
            {
                Response.Write("<script>alert('Please select From and To dates...');</script>");
                return;
            }

            if (Calendar2.SelectedDate < Calendar1.SelectedDate)
            {
                Response.Write("<script>alert('To Date should be greater than From Date.');</script>");
            }
            else
            {
                String datefrom = Calendar1.SelectedDate.ToShortDateString();
                String dateto = Calendar2.SelectedDate.ToShortDateString();
                int ShiftId = -1;
                String ShiftName = "All Shifts";
                if (ShiftSelectionListBox.SelectedIndex != -1)
                {
                    ShiftId = (int)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"];
                    ShiftName = (string)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Name"];
                }



                if (MachineSelectionListBox.SelectedIndex == -1)
                    return;
                Session["MachineName"] = dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"];
                int machineId = (int)dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"];
                Response.Redirect("~/TimeSequence/TimeSequence1_Show.aspx?MachineId="
                    + dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]
                     + "&MachineName=" + dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"]
                     + "&ShiftId=" + ShiftId
                      + "&ShiftName="+ShiftName
                     + "&datefrom=" + datefrom + "&dateto=" + dateto
                     + "&SpeedLoss=" + CheckBoxList1.Items[0].Selected);
            }
        }

        protected void MachineSelectionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DateTime fromDate = DateTime.Parse(Request.QueryString["datefrom"]);
            //DateTime toDate = DateTime.Parse(Request.QueryString["dateto"]);
            //int machineId = Convert.ToInt32(Request.QueryString["MachineId"]);
            //int ShiftId = (int)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"];
            DataAccess da = new DataAccess(); 
            if (MachineSelectionListBox.SelectedIndex == -1)
                return;
            dt1= da.GetShiftTimings(Convert.ToInt32(dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]));
            //DateTime from = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt1.Rows[0]["Start"]);
            //DateTime to = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt1.Rows[0]["End"]);
            //if (to < from)
            //    to = to.AddDays(1);

            ShiftSelectionListBox.DataSource = dt1.DefaultView;
            ShiftSelectionListBox.DataValueField = "shifts";
            ShiftSelectionListBox.DataBind();
            //dt2 = da.GetStopDetails(machineId, ShiftId, from.ToString("yyyy-MM-dd HH:mm:ss"),
            //                to.ToString("yyyy-MM-dd HH:mm:ss"),
            //                Convert.ToBoolean(Request.QueryString["SpeedLoss"]));
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Ts = new List<TimeSequence>();

            if (validateSelection())
            {
                DataAccess da = new DataAccess();
                
                DateTime fromDate = DateTime.Parse(Calendar1.SelectedDate.ToString("dd-MMM-yyyy"));
                DateTime toDate = DateTime.Parse(Calendar2.SelectedDate.ToString("dd-MMM-yyyy"));

                

                toDate = toDate.AddDays(1);


                int machineId = (int)dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"];

                int ShiftId = -1;

                if (ShiftSelectionListBox.SelectedIndex != -1)
                {
                    ShiftId = (int)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"];

                }



                SpeedLoss = CheckBoxList1.Items[0].Selected;

                ShiftCollection shifts = new ShiftCollection();

                while (fromDate < toDate)
                {
                    DataTable shiftTimingsTable = da.GetShiftTimings(machineId, ShiftId);

                    for (int i = 0; i < shiftTimingsTable.Rows.Count; i++)
                    {

                        DateTime from = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + shiftTimingsTable.Rows[i]["Start"]);

                        DateTime to = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + shiftTimingsTable.Rows[i]["End"]);


                        Shift shift = shifts.getShift(from, to);
                        shift.Breaks = da.getBreaks(shift.ID, machineId);
                        shift.Sessions = da.getSessions(shift.ID, machineId);

                        if (to < from)
                            to = to.AddDays(1);

                        Ts.AddRange(da.GetStopDetails(machineId, shift,
                            from.ToString("yyyy-MM-dd HH:mm:ss"),
                            to.ToString("yyyy-MM-dd HH:mm:ss"), from.ToString("dd-MM-yyyy"),
                            Convert.ToBoolean(Request.QueryString["SpeedLoss"])));

                    }
                    fromDate = fromDate.AddDays(1);
                }
               
                GenerateTimeSequenceReport(Ts);
                
            }
        }


        bool validateSelection()
        {

            if (Calendar1.SelectedDate == DateTime.MinValue || Calendar2.SelectedDate == DateTime.MinValue)
            {
                Response.Write("<script>alert('Please select From and To dates...');</script>");
                return false;
            }

            if (Calendar2.SelectedDate < Calendar1.SelectedDate)
            {
                Response.Write("<script>alert('To Date should be greater than From Date.');</script>");
                return false;
            }
            return true;
        }


        void GenerateTimeSequenceReport(List<TimeSequence> Ts)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=TimeSequence_"
                + (String)dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"] + ".csv");
            Response.Charset = "";
            Response.ContentType = "application/text";
            StringBuilder sBuilder = new System.Text.StringBuilder();

            sBuilder.Append("From,To,Duration,StopType,Problem,Comment");

            sBuilder.Append("\r\n");
            foreach (TimeSequence ts in Ts)
            {
                sBuilder.Append(ts.Date + ",");
                sBuilder.Append(ts.From + ",");
                sBuilder.Append(ts.To + ",");
                sBuilder.Append(ts.Duration + ",");
                sBuilder.Append(ts.StopType + ",");
                sBuilder.Append(ts.Problem + ",");
                sBuilder.Append(ts.Comment + ",");
                sBuilder.Append("\r\n");
            }



            Response.Output.Write(sBuilder.ToString());
            Response.Flush();
            Response.End();
        }
    }
}