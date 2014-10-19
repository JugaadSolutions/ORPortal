using ManufactureMonitor.DALayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManufactureMonitor
{
    public partial class ShiftSetting_Timepoints : System.Web.UI.Page
    {
        static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
                dt = da.GetSessions(Convert.ToInt32(Request.QueryString["ShiftId"]),Convert.ToInt32(Request.QueryString["MachineId"]));
                SessionSelectionListBox.DataSource = dt.DefaultView;
                SessionSelectionListBox.DataValueField = "End";
                SessionSelectionListBox.DataBind();
            }
           
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ShiftSetting_TP_Add.aspx?MachineGroupId=" + Request.QueryString["MachineGroupId"]
                 + "&MachineId=" + Request.QueryString["MachineId"] + "&ShiftId=" + Request.QueryString["ShiftId"]);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ShiftDefinitionSetting.aspx?MachineGroupId=" + Request.QueryString["MachineGroupId"]
                + "&MachineId=" + Request.QueryString["MachineId"]);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('TimePoints Deleted Successfully..');if(alert){ window.location='../Menu.aspx';}</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ShiftSetting_TP_Add.aspx?MachineGroupId=" + Request.QueryString["MachineGroupId"]);
        }
    }
}