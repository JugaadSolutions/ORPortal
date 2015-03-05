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
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR  " + Session["MachineName"];
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
            Response.Redirect("~/Menu.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (SessionSelectionListBox.SelectedIndex == -1)
                return;
            Response.Redirect("~/Shifts/ShiftSetting_TP_Add.aspx?MachineId=" + Request.QueryString["MachineId"] 
                + "&ShiftId=" + Request.QueryString["ShiftId"] +"&Session=" +dt.Rows[SessionSelectionListBox.SelectedIndex]["Id"] );
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Shifts/ShiftDefinitionSetting.aspx?MachineId=" + Request.QueryString["MachineId"]);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (SessionSelectionListBox.SelectedIndex == -1)
                return;
            DataAccess da = new DataAccess();
            da.DeleteTimepoints(Convert.ToInt32(Request.QueryString["MachineId"]), Convert.ToInt32(Request.QueryString["ShiftId"]),(int) dt.Rows[SessionSelectionListBox.SelectedIndex]["Id"]);
            Response.Write("<script>alert('TimePoints Deleted Successfully..');if(alert){ window.location='../Menu.aspx';}</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("~/Shifts/ShiftSetting_TP_Add.aspx?MachineId=" + Request.QueryString["MachineId"] 
                + "&Shift_Id=" + Request.QueryString["ShiftId"]);
        }
    }
}