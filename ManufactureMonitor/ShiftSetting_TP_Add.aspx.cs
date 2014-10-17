using ManufactureMonitor.DALayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManufactureMonitor
{
    public partial class ShiftSetting_TP_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             
            //if (!Page.IsPostBack)
            //{
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataAccess da = new DataAccess();

            String End = "2014-01-01 " + TextBox2.Text + ":" + TextBox3.Text;
            


        }
    }
}