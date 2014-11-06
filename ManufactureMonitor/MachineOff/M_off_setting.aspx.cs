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
    public partial class M_off_setting : System.Web.UI.Page
    {
        static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
                dt = da.GetMachines(Convert.ToInt32(Session["MachineGroup"]));
                //ListView1.DataSource = dt;
                //ListView1.DataBind();
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
            Response.Redirect("~/MachineOff/M_off_setting_show.aspx?MachineId=" + dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]
                 + "&MachineName=" + dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"]);
        }

    }
}