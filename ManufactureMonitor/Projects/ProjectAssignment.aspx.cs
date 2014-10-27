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
    public partial class ProjectAssignment : System.Web.UI.Page
    {
        static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
                dt = da.GetMachines(Convert.ToInt32(Request.QueryString["MachineGroupId"]));
                ProjectSelectionListBox.DataSource = dt.DefaultView;
                ProjectSelectionListBox.DataValueField = "Machines";
                ProjectSelectionListBox.DataBind();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ProjectAssignment_Show.aspx?Id=" + dt.Rows[ProjectSelectionListBox.SelectedIndex]["Id"]
                + "&MachineGroupId=" + Request.QueryString["MachineGroupId"]);
        }

        protected void DontSaveButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ProjectAssignment.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }

        

       
    }
}