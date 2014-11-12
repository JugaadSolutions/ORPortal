using ManufactureMonitor.DALayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManufactureMonitor.Projects
{
    public partial class ProjectAssignment1 : System.Web.UI.Page
    {
        static DataTable dt;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (MachineSelectionListBox.SelectedIndex == -1)
                return;
            Session["MachineName"] = dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"];
            Response.Redirect("~/Projects/ProjectAssignment.aspx?MachineId=" + dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]
                 + "&MachineName=" + dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"]
                + " &MachineGroupId=" +Session["MachineGroup"]);
       
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Session["MachineGroupId"]);
        }
    }
}