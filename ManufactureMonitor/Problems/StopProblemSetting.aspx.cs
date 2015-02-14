using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ManufactureMonitor.DALayer;
using System.Data;
using System.Data.OleDb;

namespace ManufactureMonitor
{
    public partial class StopProblemSetting : System.Web.UI.Page
    {
        static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR  " + Session["MachineName"];
            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
                dt = da.GetSpecificProblems(Convert.ToInt32(Request.QueryString["MachineId"]));
                ShiftSelectionListBox.DataSource = dt.DefaultView;
                ShiftSelectionListBox.DataValueField = "Description";
                ShiftSelectionListBox.DataBind();
            }   
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx");
        }

       
        protected void Delete_Click(object sender, EventArgs e)
        {
            if (ShiftSelectionListBox.SelectedIndex == -1)
                return;
            DataAccess da = new DataAccess();
            da.DeleteSProblem((Int32)dt.Rows[ShiftSelectionListBox.SelectedIndex]["Code"]);
            Response.Write("<script>alert('Problem Deleted Successfully..');if(alert){ window.location='../Problems/StopProblemSetting.aspx?MachineId=" + Request.QueryString["MachineId"] + "';}</script>");
       
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            if (ShiftSelectionListBox.SelectedIndex == -1)
                return;
            Response.Redirect("~/Problems/StopProblemSetting_Enter.aspx?Code=" + dt.Rows[ShiftSelectionListBox.SelectedIndex]["Code"]
                + "&MachineId=" + Request.QueryString["MachineId"]);
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Problems/StopProblemSetting_Enter.aspx?MachineId=" + Request.QueryString["MachineId"]);
        }

        
    }
}