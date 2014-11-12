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
    public partial class ProjectSetting_Enter : System.Web.UI.Page
    {
        static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR  " + Session["MachineName"];
            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
                dt = da.GetProjects(Convert.ToInt32(Request.QueryString["MachineId"]));
                ProjectSelectionListBox.DataSource = dt.DefaultView;
                ProjectSelectionListBox.DataValueField = "Projects";
                ProjectSelectionListBox.DataBind();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Menu.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Projects/ProjectSetting_Enter_Add.aspx?MachineId=" + Request.QueryString["MachineId"] 
                +"&ProjectId="+dt.Rows[ProjectSelectionListBox.SelectedIndex]["Id"]);
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Projects/ProjectSetting_Enter_Add.aspx?MachineId=" + Request.QueryString["MachineId"]);
        
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            if (ProjectSelectionListBox.SelectedIndex == -1)
                return;
            Response.Redirect("~/Projects/ProjectSetting_Enter_Add.aspx?MachineId=" + Request.QueryString["MachineId"]
                + "&ProjectId=" + dt.Rows[ProjectSelectionListBox.SelectedIndex]["Id"]);
        
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            if (ProjectSelectionListBox.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                DataAccess da = new DataAccess();
                da.DeleteProject((int)dt.Rows[ProjectSelectionListBox.SelectedIndex]["Id"]);
                da.DeleteProjectId((int)dt.Rows[ProjectSelectionListBox.SelectedIndex]["Id"],
                    Convert.ToInt32(Request.QueryString["MachineId"]));
                Response.Write("<script>alert('Problem Deleted Successfully..');if(alert){ window.location='../Menu.aspx';}</script>");
            }
       
        }
    }
}