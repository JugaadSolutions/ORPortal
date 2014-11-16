using ManufactureMonitor.DALayer;
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
    public partial class ProblemAccumulation : System.Web.UI.Page
    {
        static DataTable dt,dt1,dt2;
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
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Session["MachineGroup"]);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if( validateSelection() )
            {
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
                Response.Redirect("~/ProblemAccumulation/ProblemAccumulation_Show.aspx?MachineGroupId=" + Session["MachineGroup"]
                     + "&MachineId=" + (int)dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]
                      + "&MachineName=" + dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"]
                     + "&ShiftId=" + ShiftId
                      + "&ShiftName=" + ShiftName
                       + "&datefrom=" + datefrom.SelectedDate.ToShortDateString()
                      + "&dateto=" + dateto.SelectedDate.ToShortDateString());
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
            if (validateSelection())
            {
                DataAccess da = new DataAccess();
                int machine = (int)dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"];

                DateTime fromDate = datefrom.SelectedDate;
                DateTime toDate = dateto.SelectedDate;
                toDate = toDate.AddDays(1);
                int ShiftId = (int)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"];
                while (fromDate < toDate)
                {
                    dt = da.GetShiftTimings(machine, ShiftId);
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        DateTime from = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["Start"]);
                        DateTime to = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["End"]);

                        dt1 = da.GetAccumulation(machine, from.ToString("yyyy-MM-dd HH:mm:ss"),
                                    to.ToString("yyyy-MM-dd HH:mm:ss"));

                    }
                    fromDate = fromDate.AddDays(1);
                }
                GenerateAccumulationReport(dt1);
            }
               
        }
        bool validateSelection()
        {

            if (datefrom.SelectedDate == DateTime.MinValue || dateto.SelectedDate == DateTime.MinValue)
            {
                Response.Write("<script>alert('Please select From and To dates...');</script>");
                return false;
            }

            if (dateto.SelectedDate < datefrom.SelectedDate)
            {
                Response.Write("<script>alert('To Date should be greater than From Date.');</script>");
                return false;
            }
            return true;
        }
        void GenerateAccumulationReport(DataTable dt1)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=ProblemAccumulation_"
                + Session["MachineName"] + ".csv");
            Response.Charset = "";
            Response.ContentType = "application/text";
            StringBuilder sBuilder = new System.Text.StringBuilder();

            sBuilder.Append("Code,Problems,Time[s],Count,Time[%]");

            sBuilder.Append("\r\n");
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                sBuilder.Append(dt1.Rows[i]["Code"] + ",");
                sBuilder.Append(dt1.Rows[i]["Problems"] + ",");
                sBuilder.Append(dt1.Rows[i]["Time"] + ",");
                sBuilder.Append(dt1.Rows[i]["Count"] + ",");
                sBuilder.Append(dt1.Rows[i]["Time[%]"] + ",");
                
                sBuilder.Append("\r\n");
            }



            Response.Output.Write(sBuilder.ToString());
            Response.Flush();
            Response.End();
        }

    }
}