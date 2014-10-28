using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ManufactureMonitor.DALayer;
using System.Data;

namespace ManufactureMonitor
{
    public partial class ProjectSetting : System.Web.UI.Page
    {
        static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
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
            Response.Redirect("../Menu.aspx");
            
        }

       
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Projects/ProjectSetting_Enter.aspx?MachineId=" 
                + dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]
                 + "&MachineName=" + dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"]);
        }
    }
}