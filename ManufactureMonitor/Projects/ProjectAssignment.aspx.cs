using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ManufactureMonitor.DALayer;
using System.Data;

namespace ManufactureMonitor
{
    public partial class ProjectAssignment : System.Web.UI.Page
    {
        static DataTable dt,dt1;
        int curProject;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                
                updateProjectStatus();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            
            DataAccess da = new DataAccess();
            int newProject=(int)dt.Rows[ProjectSelectionListBox.SelectedIndex]["Id"];
            curProject = (int)dt1.Rows[0][1];
            bool b = da.SetProject(Convert.ToInt32(Request.QueryString["MachineId"]),
                curProject, newProject);
            if (b == true)
            {
                updateProjectStatus();

                Response.Write("<script>alert('Project Updated Successfully..');if(alert){ window.location='../Projects/ProjectAssignment.aspx?MachineId='"+Request.QueryString["MachineId"]+";}</script>");
            }
            else
            {
                Response.Write("<script>alert('Project Update failed..')</script>");
            }
        }

        protected void DontSaveButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Projects/ProjectAssignment1.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]
                );
        }

        void updateProjectStatus()
        {

            DataAccess da = new DataAccess();
            
            dt = da.GetNewProjects(Convert.ToInt32(Request.QueryString["MachineId"]));
            ProjectSelectionListBox.DataSource = dt.DefaultView;
            ProjectSelectionListBox.DataValueField = "Projects";
            ProjectSelectionListBox.DataBind();
            dt1 = da.CurrentProject(Convert.ToInt32(Request.QueryString["MachineId"]));
            ProjectAssignedLabel.Text = (String)dt1.Rows[0][0];
            curProject = (int)dt1.Rows[0][1];
        }
       
    }
}