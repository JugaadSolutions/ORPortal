using ManufactureMonitor.DALayer;
using ManufactureMonitor.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManufactureMonitor
{
    public partial class ShiftHistroy1 : System.Web.UI.Page
    {
        static DataTable dt, dt1;
        static List<ShiftHistory> Sh;
        static List<ShiftHistory_Summary> shSummary;
        static bool summary;
        static String From;
        static String To;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR  " + Session["Machinegroupname"];
            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
                dt = da.GetMachines(Convert.ToInt32(Session["MachineGroup"]));
                MachineSelectionListBox.DataSource = dt.DefaultView;
                MachineSelectionListBox.DataValueField = "Machines";
                MachineSelectionListBox.DataBind();

            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            From = datepicker1.Text;
            To = datepicker2.Text;

            if (validateSelection())
            {
                DateTime fromDate = Convert.ToDateTime(From);
                DateTime toDate = Convert.ToDateTime(To);
              
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
                    Response.Redirect("~/ShiftHistory/ShiftHistroy_Show.aspx?MachineId="
                        + dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"] + "&MachineName=" + dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"]
                         + "&ShiftId=" + ShiftId
                         + "&ShiftName=" + ShiftName
                         + "&from=" + fromDate + "&to=" + toDate
                         + "&Summary=" + Convert.ToBoolean(CheckBoxList1.Items[0].Selected));
                }
            
        }

        protected void MachineSelectionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataAccess da = new DataAccess();
            if (MachineSelectionListBox.SelectedIndex == -1)
                return;
            dt1 = da.GetShiftTimings(Convert.ToInt32(dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]));
            ShiftSelectionListBox.DataSource = dt1.DefaultView;
            ShiftSelectionListBox.DataValueField = "shifts";
            ShiftSelectionListBox.DataBind();

        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            String From = datepicker1.Text;
            String To = datepicker2.Text;

            if (validateSelection())
            {

                DataAccess da = new DataAccess();
                
                DateTime fromDate = Convert.ToDateTime(From);
                DateTime toDate = Convert.ToDateTime(To);

                toDate = toDate.AddDays(1);
                int machineId = (int)dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"];
                summary = CheckBoxList1.Items[0].Selected;


                int ShiftId = -1;

                if (ShiftSelectionListBox.SelectedIndex != -1)
                {
                    ShiftId = (int)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"];

                }

                Sh = new List<ShiftHistory>();
                shSummary = new List<ShiftHistory_Summary>();
                while (fromDate < toDate)
                {
                    DataTable shiftTimingsTable = da.GetShiftTimings(machineId, ShiftId);

                    for (int i = 0; i < shiftTimingsTable.Rows.Count; i++)
                    {

                        DateTime from = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + shiftTimingsTable.Rows[i]["Start"]);
                       
                        DateTime to = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + shiftTimingsTable.Rows[i]["End"]);

                        if (to < from)
                            to = to.AddDays(1);

                        if (!summary)
                        {

                            Sh.AddRange(da.GetShiftHistory(machineId, from.ToString("yyyy-MM-dd HH:mm:ss"),
                                to.ToString("yyyy-MM-dd HH:mm:ss")
                                ));

                            
                        }
                        else
                        {
                            shSummary.AddRange( da.GetShiftHistory_Summary(machineId, from.ToString("yyyy-MM-dd HH:mm:ss"),
                                to.ToString("yyyy-MM-dd HH:mm:ss")
                                ));

                           
                        }
                    }


                    fromDate = fromDate.AddDays(1);
                }
                if (!summary)
                {



                    GenerateShiftHistoryReport(Sh);
                }
                else
                {


                    GenerateShiftHistorySummaryReport(shSummary);
                }
            }
                
            
        }

        void GenerateShiftHistoryReport(List<ShiftHistory> sh)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=ShiftHistorySummary_"
                + (String)dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"] + ".csv");
            Response.Charset = "";
            Response.ContentType = "application/text";
            StringBuilder sBuilder = new System.Text.StringBuilder();

            sBuilder.Append("Date,From,To,Project/Model,Plan Cycle Time[s],OK Pieces,Scraps,Load Time/Available Time[s], Non-Operation Time 1/Other than Machine[s],"
                + "Non-Operation Time 2/Machine Related[s], Undefined, Idle Time/Exclude Hour[s], KADOURITSU/Operation Ratio[%],"
            + "Bekadouritsu/Operational Availability[s]");

            sBuilder.Append("\r\n");
            foreach (ShiftHistory s in sh)
            {
                sBuilder.Append(s.Date + ",");
                sBuilder.Append(s.From + ",");
                sBuilder.Append(s.To + ",");
                sBuilder.Append(s.Project + ",");
                sBuilder.Append(s.CycleTime + ",");
                sBuilder.Append(s.Actual + ",");
                sBuilder.Append(s.Scraps + ",");
                sBuilder.Append(s.LoadTime + ",");
                sBuilder.Append(s.Nop1 + ",");
                sBuilder.Append(s.Nop2 + ",");
                sBuilder.Append(s.Undefined + ",");

                sBuilder.Append(s.Idle + ",");
                sBuilder.Append(s.KR + ",");
                sBuilder.Append(s.BKR);
                sBuilder.Append("\r\n");
            }

            Response.Output.Write(sBuilder.ToString());
            Response.Flush();
            Response.End();
        }

        void GenerateShiftHistorySummaryReport(List<ShiftHistory_Summary> Sh_Su)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=ShiftHistoryProjectSummary"
                + (String)dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"] + ".csv");
            Response.Charset = "";
            Response.ContentType = "application/text";
            StringBuilder sBuilder = new System.Text.StringBuilder();

            sBuilder.Append("Date,Project/Model,Plan Cycle Time[s],OK Pieces,Scraps,Load Time/Available Time[s], Non-Operation Time 1/Machine Related[s],"
                + "Non-Operation Time 2/Other than Machine[s], Undefined, Idle Time/Exclude Hour[s], KADOURITSU/Operation Ratio[%],"
            + "Bekadouritsu/Operational Availability[s]");

            sBuilder.Append("\r\n");
            foreach (ShiftHistory_Summary s in Sh_Su)
            {
                sBuilder.Append(s.Date + ",");
                sBuilder.Append(s.Project + ",");
                sBuilder.Append(s.CycleTime + ",");
                sBuilder.Append(s.Actual + ",");
                sBuilder.Append(s.Scraps + ",");
                sBuilder.Append(s.LoadTime + ",");
                sBuilder.Append(s.Nop1 + ",");
                sBuilder.Append(s.Nop2 + ",");
                sBuilder.Append(s.Undefined + ",");

                sBuilder.Append(s.Idle + ",");
                sBuilder.Append(s.KR + ",");
                sBuilder.Append(s.BKR);
                sBuilder.Append("\r\n");
            }

            Response.Output.Write(sBuilder.ToString());
            Response.Flush();
            Response.End();
        }


        bool validateSelection()
        {
            
            DateTime fromDate = Convert.ToDateTime(From);
            DateTime toDate = Convert.ToDateTime(To);


            if (From == ""  || To == "")
            {
                Response.Write("<script>alert('Please select From and To dates...');</script>");
                return false;
            }
            if ( toDate < fromDate)
            {
                Response.Write("<script>alert('To Date should be greater than From Date.');</script>");
                return false;
            }
            
            return true;
        }
        
    }
}