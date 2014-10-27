using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManufactureMonitor
{
    public partial class Index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Machinegroup"] = 1;
            Response.Redirect("Menu.aspx");
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["Machinegroup"] = 2;
            Response.Redirect("Menu.aspx");
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["Machinegroup"] = 3;
            Response.Redirect("Menu.aspx");
           
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/Users/UserLogin.aspx?Source=CommonProblemSetting");
            }
            else
            {
                Response.Redirect("~/Problems/CommonProblemsSetting.aspx");
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Problems/DisplayStopProblems.aspx?Source=Common");
        }
    }
}