using ManufactureMonitor.DALayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManufactureMonitor
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Menu.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataAccess da = new DataAccess();
            bool b=da.SetPassword(TextBox2.Text,TextBox3.Text,TextBox5.Text);
            if (b == true)
            {
                Response.Write("<script>alert('Password changed successfully....');if(alert){ window.location='../Menu.aspx'}</script>");
            }
            else
            {
                Response.Write("<script>alert('Invalid Data....');if(alert){ window.location='../Menu.aspx'}</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Menu.aspx");
        }
    }
}