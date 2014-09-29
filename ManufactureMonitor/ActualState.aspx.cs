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
        protected void Page_Load(object sender, EventArgs e)
        {
            DataAccess da = new DataAccess();
            DataTable dt = da.GetMachineName(Convert.ToInt32(Request.QueryString["MachineGroupId"]));
            ListView1.DataSource= dt;
            ListView1.DataBind();
                
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx");
        }

       
    }
}