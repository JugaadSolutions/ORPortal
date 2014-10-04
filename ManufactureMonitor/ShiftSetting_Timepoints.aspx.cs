using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManufactureMonitor
{
    public partial class ShiftSetting_Timepoints : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ShiftSetting_TP_Add.aspx?MachineGroupId=" + Request.QueryString["MachineGroupId"]);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ShiftDefinitionSetting.aspx?MachineGroupId=" + Request.QueryString["MachineGroupId"]);
        }
    }
}