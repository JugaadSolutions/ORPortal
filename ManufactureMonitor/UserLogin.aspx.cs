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
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataAccess da = new DataAccess();
            bool b =da.Login(TextBox2.Text,TextBox3.Text);
            Session["User"] = TextBox2.Text;
            if (b == true)
            {
                switch (Request.QueryString["Source"])
                {
                    case "ChangePassword":

                        Response.Redirect("~/ChangePassword.aspx?MachineGroupId=" + Request.QueryString["MachineGroupId"]);
                            break;
                        
                    case "StopProblemSetting":
                        
                            Response.Redirect("~/StopProblemSetting.aspx?MachineGroupId=" + Request.QueryString["MachineGroupId"]);
                            break;
                    case "ProjectAssignment":
                            Response.Redirect("~/ProjectAssignment.aspx?MachineGroupId=" + Request.QueryString["MachineGroupId"]);
                            break;
                    case "M_off_setting":
                            Response.Redirect("~/M_off_Setting.aspx?MachineGroupId=" + Request.QueryString["MachineGroupId"]);
                            break;
                    case "ParameterSetting":
                            Response.Redirect("~/ParameterSetting.aspx?MachineGroupId=" + Request.QueryString["MachineGroupId"]);
                            break;
                    case "ProjectSetting":
                            Response.Redirect("~/ProjectSetting.aspx?MachineGroupId=" + Request.QueryString["MachineGroupId"]);
                            break;
                    case"ShiftDefinitionSetting":
                            Response.Redirect("~/ShiftDefintionSetting1.aspx?MachineGroupId=" + Request.QueryString["MachineGroupId"]);
                            break;
                    
                            

                }
                
            }
            else
            {
                
                Response.Write("<Script>alert('Invalid Login')</script>");
            }
        
        }
    }
}