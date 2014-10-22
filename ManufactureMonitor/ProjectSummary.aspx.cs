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

            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
                dt = da.GetMachines(Convert.ToInt32(Request.QueryString["MachineGroupId"]));
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
            Response.Redirect("~/ProjectSummary_Show.aspx?Id=" + Request.QueryString["MachineGroupId"]
                 +"&MachineId="+(int)dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]
                 + "&ShiftId=" + (int)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"]);
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

            dt2 = da.GetModels((int)dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]);
            ModelSelectionListBox.DataSource = dt2.DefaultView;
            ModelSelectionListBox.DataValueField = "Models";
            ModelSelectionListBox.DataBind();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/LossHourGraph.aspx?Id=" + Request.QueryString["MachineGroupId"]
                 + "&MachineId=" + (int)dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]
                 + "&ShiftId=" + (int)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"] 
                 + "&datefrom=" + datefrom.SelectedDate.ToShortDateString() + "&dateto=" + dateto.SelectedDate.ToShortDateString());
        }
    }
}