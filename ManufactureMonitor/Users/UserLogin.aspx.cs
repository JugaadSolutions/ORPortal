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
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR  " + Session["Machinegroupname"];
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            String source = Request.QueryString["Source"];
            if (source == "CommonProblemSetting")
            {
                Response.Redirect("~/Index.aspx");
            }
            else
            {
                Response.Redirect("~/Menu.aspx");
            }
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

                        Response.Redirect("~/Users/ChangePassword.aspx"   );
                            break;
                        
                    case "StopProblemSetting":
                        
                            Response.Redirect("~/Problems/StopProblemSetting1.aspx"   );
                            break;
                    case "ProjectAssignment":
                            Response.Redirect("~/Projects/ProjectAssignment1.aspx"   );
                            break;
                    case "M_off_setting":
                            Response.Redirect("~/MachineOff/M_off_Setting.aspx"   );
                            break;
                    case "ParameterSetting":
                            Response.Redirect("~/Parameters/ParameterSetting.aspx"   );
                            break;
                    case "ProjectSetting":
                            Response.Redirect("~/Projects/ProjectSetting.aspx"   );
                            break;
                    case"ShiftDefinitionSetting":
                            Response.Redirect("~/Shifts/ShiftDefintionSetting1.aspx"   );
                            break;
                    case "CommonProblemSetting":
                            Response.Redirect("~/Problems/CommonProblemsSetting.aspx");
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