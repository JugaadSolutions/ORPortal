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
                dt = da.GetShifts(Convert.ToInt32(Session["MachineGroup"]));
                ShiftSelectionListBox.DataSource = dt.DefaultView;
                ShiftSelectionListBox.DataValueField = "shifts";
                ShiftSelectionListBox.DataBind();
            }
           
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Shifts/ShiftSetting_Add.aspx" +
                  "?MachineId=" + Request.QueryString["MachineId"]);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (ShiftSelectionListBox.SelectedIndex == -1)
                return;
            Response.Redirect("~/Shifts/ShiftSetting_Timepoints.aspx?MachineId=" + Request.QueryString["MachineId"] + "&ShiftId=" 
                + dt.Rows[ShiftSelectionListBox.SelectedIndex]["Id"]
                 + "&ShiftName=" + (string)dt.Rows[ShiftSelectionListBox.SelectedIndex]["Name"]);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (ShiftSelectionListBox.SelectedIndex == -1)
                return;
            Response.Redirect("~/Shifts/ShiftSetting_Add.aspx?ShiftId=" 
                + dt.Rows[ShiftSelectionListBox.SelectedIndex]["Id"]
                 + "&ShiftName=" + (string)dt.Rows[ShiftSelectionListBox.SelectedIndex]["Name"]
                +"&MachineId=" + Request.QueryString["MachineId"]);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (ShiftSelectionListBox.SelectedIndex == -1)
                return;

            DataAccess da = new DataAccess();
            da.DeleteBreaks(Convert.ToInt32(Request.QueryString["MachineId"]),
                (int) dt.Rows[ShiftSelectionListBox.SelectedIndex]["Id"]);

            da.DeleteShift((Int32)dt.Rows[ShiftSelectionListBox.SelectedIndex]["Id"], 
                Convert.ToInt32(Session["MachineGroup"]));

            da.DeleteSession(Convert.ToInt32(Request.QueryString["MachineId"]),
                (int)dt.Rows[ShiftSelectionListBox.SelectedIndex]["Id"]);

            Response.Write("<script>alert('Shift Deleted Successfully..');if(alert){ window.location='../Menu.aspx';}</script>");
       
           // Response.Redirect("~/ShiftSetting_Add.aspx?MachineGroupId=" + Session["MachineGroup"]);
        }
    }
}