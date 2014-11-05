using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManufactureMonitor
{
    public partial class M_off_setting_show : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StopImage.Visible = false;
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MachineOff/CancelMachineOff.aspx");
        }
    }
}