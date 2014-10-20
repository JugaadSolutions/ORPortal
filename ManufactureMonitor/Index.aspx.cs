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
            Response.Redirect("Menu.aspx?Machinegroup="+1);
            Session["Machinegroup"] = 1;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx?Machinegroup=" +2);
            Session["Machinegroup"] =2;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx?Machinegroup=" +3);
            Session["Machinegroup"] = 3;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/UserLogin.aspx?Source=CommonProblemSetting");
            }
            else
            {
                Response.Redirect("~/CommonProblemsSetting.aspx");
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DisplayStopProblems.aspx?Source=Common");
        }
    }
}