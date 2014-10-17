using ManufactureMonitor.DALayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ManufactureMonitor
{
    public partial class ShiftDefinitionSetting : System.Web.UI.Page
    {
        static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
                dt = da.GetShifts(Convert.ToInt32(Request.QueryString["MachineId"]));
                ShiftSelectionListBox.DataSource = dt.DefaultView;
                ShiftSelectionListBox.DataValueField = "shifts";
                ShiftSelectionListBox.DataBind();
            }
           
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ShiftSetting_Add.aspx?MachineGroupId=" + Request.QueryString["MachineGroupId"] +
                  "&MachineId=" + Request.QueryString["MachineId"]);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (ShiftSelectionListBox.SelectedIndex == -1)
                return;
            Response.Redirect("~/ShiftSetting_Timepoints.aspx?MachineGroupId=" + Request.QueryString["MachineGroupId"]
                + "&MachineId=" + Request.QueryString["MachineId"] + "&ShiftId=" + dt.Rows[ShiftSelectionListBox.SelectedIndex]["Id"]);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (ShiftSelectionListBox.SelectedIndex == -1)
                return;
            Response.Redirect("~/ShiftSetting_Add.aspx?MachineGroupId=" + Request.QueryString["MachineGroupId"] 
                + "&ShiftId=" + dt.Rows[ShiftSelectionListBox.SelectedIndex]["Id"]+"&MachineId=" + Request.QueryString["MachineId"]);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (ShiftSelectionListBox.SelectedIndex == -1)
                return;
            DataAccess da = new DataAccess();
            da.DeleteShift((Int32)dt.Rows[ShiftSelectionListBox.SelectedIndex]["Id"], Convert.ToInt32(Request.QueryString["MachineGroupId"]));
            Response.Write("<script>alert('Problem Deleted Successfully..');if(alert){ window.location='../Menu.aspx';}</script>");
       
           // Response.Redirect("~/ShiftSetting_Add.aspx?MachineGroupId=" + Request.QueryString["MachineGroupId"]);
        }
    }
}