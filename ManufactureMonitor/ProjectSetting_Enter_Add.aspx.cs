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
    public partial class ProjectSetting_Enter_Add : System.Web.UI.Page
    {
        static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["ProjectId"] != null)
                {
                    DataAccess da = new DataAccess();
                    dt = da.SelectProject(Convert.ToInt32(Request.QueryString["ProjectId"]),
                        Convert.ToInt32(Request.QueryString["MachineId"]));
                    
                    TextBox2.Text = (dt.Rows[0]["Projects"]).ToString();
                    TextBox4.Text = (dt.Rows[0]["Time"]).ToString();
                    
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ProjectId"] == null)
            {
                DataAccess da = new DataAccess();
                int ProjectId = da.AddProjects(TextBox2.Text,float.Parse(TextBox4.Text));
                if (ProjectId == -1)
                {
                    Response.Write("<script>alert('Error while Adding Shift!!');</script>");
                }
                bool b = da.AddProjectId(ProjectId,Convert.ToInt32(Request.QueryString["MachineId"]));
                if (b == true)
                {
                    Response.Write("<script>alert('Problem Added Successfully..');if(alert){ window.location='../Index.aspx';}</script>");


                }
                else
                {
                    Response.Write("<script>alert('Problem code already exist..');if(alert){ window.location='../Index.aspx';}</script>");
                }
            }
            else
            {
                DataAccess da = new DataAccess();
                da.UpdateProjects(Convert.ToInt32(Request.QueryString["ProjectId"]), TextBox2.Text, float.Parse(TextBox4.Text));
                Response.Write("<script>alert('Problem Updated..');if(alert){ window.location='../Index.aspx';}</script>");
            }
        }

        protected void DontSaveButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }
    }
}