using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ManufactureMonitor.DALayer;
using System.Data;



namespace ManufactureMonitor
{
    public partial class ActualState : System.Web.UI.Page
    {
        static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
                dt = da.GetMachines(Convert.ToInt32(Request.QueryString["MachineGroupId"]));
                ListView1.DataSource = dt;
                ListView1.DataBind();
            }
                
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx");
        }

        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {



            Response.Redirect("~/DisplayActualState.aspx?Id=" + dt.Rows[ListView1.SelectedIndex]["Id"]);
        }

        protected void ListView1_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {

        }

       
    }
}