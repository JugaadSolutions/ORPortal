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
        static DateTime from;
        static DateTime to;
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

            if (validateSelection1())
            {
                from = Convert.ToDateTime(From.ToString());
                to = Convert.ToDateTime(To.ToString());
                if (validateSelection2())
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
                    Response.Redirect("~/ShiftHistory/ShiftHistroy_Show.aspx?MachineId="
                        + dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"] + "&MachineName=" + dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"]
                         + "&ShiftId=" + ShiftId
                         + "&ShiftName=" + ShiftName
                         + "&from=" + from + "&to=" + to
                         + "&Summary=" + Convert.ToBoolean(CheckBoxList1.Items[0].Selected));
                }
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
            if (validateSelection1())
            {

                DataAccess da = new DataAccess();
                String From = datepicker1.Text;
                String To = datepicker2.Text;
                DateTime from = Convert.ToDateTime(From.ToString());
                DateTime to = Convert.ToDateTime(To.ToString());
                if (validateSelection2())
                {
                    to = to.AddDays(1);
                    int machineId = (int)dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"];
                    summary = CheckBoxList1.Items[0].Selected;
                    while (from < to)
                    {

                        if (!summary)
                        {

                            Sh = da.GetShiftHistory(machineId, from.ToString("yyyy-MM-dd HH:mm:ss"),
                                to.ToString("yyyy-MM-dd HH:mm:ss")
                                );

                            GenerateShiftHistoryReport(Sh);
                        }
                        else
                        {
                            shSummary = da.GetShiftHistory_Summary(machineId, from.ToString("yyyy-MM-dd HH:mm:ss"),
                                to.ToString("yyyy-MM-dd HH:mm:ss")
                                );

                            GenerateShiftHistorySummaryReport(shSummary);
                        }
                    }
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
        bool validateSelection1()
        {

            if (From == ""  || To == "")
            {
                Response.Write("<script>alert('Please select From and To dates...');</script>");
                return false;
            }

            
            return true;
        }
        bool validateSelection2()
        {
            if (to < from)
            {
                Response.Write("<script>alert('To Date should be greater than From Date.');</script>");
                return false;
            }
            return true;
        }
    }
}