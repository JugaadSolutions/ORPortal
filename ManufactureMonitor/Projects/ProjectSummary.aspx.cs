using ManufactureMonitor.DALayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManufactureMonitor
{
    public partial class ProjectSummary : System.Web.UI.Page
    {
        static DataTable dt, dt1,dt2;
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

        

        protected void MachineSelectionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataAccess da = new DataAccess();
            if (MachineSelectionListBox.SelectedIndex == -1)
                return;
            Session["MachineName"] = dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"];
            dt1 = da.GetShiftTimings(Convert.ToInt32(dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]));
            ShiftSelectionListBox.DataSource = dt1.DefaultView;
            ShiftSelectionListBox.DataValueField = "shifts";
            ShiftSelectionListBox.DataBind();

            dt2 = da.GetModels((int)dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]);
            ModelSelectionListBox.DataSource = dt2.DefaultView;
            ModelSelectionListBox.DataValueField = "Models";
            ModelSelectionListBox.DataBind();
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

        
        protected void OR_OAGraph_Click(object sender, EventArgs e)
        {

            if (validateSelection())
            {

                int ShiftId = -1;
                String ShiftName = "All Shifts";
                String Project = "";

                if (ModelSelectionListBox.SelectedIndex != -1)
                    Project = (String)dt2.Rows[ModelSelectionListBox.SelectedIndex]["Name"];
                if (ShiftSelectionListBox.SelectedIndex != -1)
                {
                    ShiftId = (int)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"];
                    ShiftName = (string)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Name"];
                }
               
                Response.Redirect("~/SummaryReport/OR_OAGraph.aspx?MachineId="
                    + dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]
                        + "&MachineName=" + dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"]
                     + "&ShiftId=" + ShiftId
                     + "&ShiftName=" + ShiftName
                     + "&datefrom=" + datefrom.SelectedDate.ToString("dd-MMM-yy")
                     + "&dateto=" + dateto.SelectedDate.ToString("dd-MMM-yy")
                      + "&Project=" + Project
                    );
            }
        }

        protected void ProdProgress_Click(object sender, EventArgs e)
        {
            if (validateSelection())
            {

                int ShiftId = -1;
                String ShiftName = "All Shifts";
                int Project = 0;

                if (ModelSelectionListBox.SelectedIndex != -1)
                    Project = (int)dt2.Rows[ModelSelectionListBox.SelectedIndex]["ID"];
                if (ShiftSelectionListBox.SelectedIndex != -1)
                {
                    ShiftId = (int)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"];
                    ShiftName = (string)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Name"];
                }
                Response.Redirect("~/SummaryReport/ProductionProgress.aspx?MachineId="
                    + dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]
                        + "&MachineName=" + dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"]
                     + "&ShiftId=" + ShiftId
                     + "&ShiftName=" + ShiftName
                     + "&datefrom=" + datefrom.SelectedDate.ToString("dd-MMM-yy")
                     + "&dateto=" + dateto.SelectedDate.ToString("dd-MMM-yy")
                      + "&Project=" + Project
                    );
            }
        }

        protected void LossHour_Click(object sender, EventArgs e)
        {
            if (validateSelection())
            {

                int ShiftId = -1;
                String ShiftName = "All Shifts";
                if (ShiftSelectionListBox.SelectedIndex != -1)
                {
                    ShiftId = (int)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"];
                    ShiftName = (string)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Name"];
                }
                Response.Redirect("~/SummaryReport/LossHourGraph.aspx?Id=" + Request.QueryString["MachineGroupId"]
                  + "&MachineId=" + (int)dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]
                   + "&MachineName=" + dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"]
                  + "&ShiftId=" + (int)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"]
                   + "&ShiftName=" + (string)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Name"]
                  + "&datefrom=" + datefrom.SelectedDate.ToShortDateString()
                  + "&dateto=" + dateto.SelectedDate.ToShortDateString());
            }
        }

        protected void ExcelImage_Click(object sender, ImageClickEventArgs e)
        {

        }

        

    }
}