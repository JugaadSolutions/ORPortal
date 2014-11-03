using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManufactureMonitor
{
    public partial class Menu : System.Web.UI.Page
    {
        //static string MachineGroupId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["User"] = TextBox1.Text;
            //MachineGroupId = Session["MachineGroup"];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
                Response.Redirect("~/ActualState/ActualState.aspx" );
            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ShiftHistory/ShiftHistroy1.aspx" );
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/Users/UserLogin.aspx?Source=ProjectAssignment" );
            }
            else
            {
                Response.Redirect("~/Projects/ProjectAssignment1.aspx"  );
            }
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Projects/DisplayProject1.aspx"  );
        }

        protected void Button20_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Problems/DisplayStopProblems1.aspx"  );
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Shifts/DisplayShiftDefinition.aspx"  );
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Parameters/DisplayParameters.aspx"  );
        }

        protected void Button19_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Users/ChangePassword.aspx"  );
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Scraps/Scrap1.aspx"  );
        }

        protected void Button18_Click(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/Users/UserLogin.aspx?Source=StopProblemSetting"  );
            }
            else
            {
                Response.Redirect("~/Problems/StopProblemSetting1.aspx"  );
            }
        }

        protected void Button15_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EnterCodeComment/StopTimes2.aspx"  );
        }

        protected void Button16_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ProblemAccumulation/ProblemAccumulation.aspx"  );
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/Users/UserLogin.aspx?Source=ProjectSetting"  );
            }
            else
            {
                Response.Redirect("~/Projects/ProjectSetting.aspx"  );
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/Users/UserLogin.aspx?Source=M_off_setting"  );
            }
            else
            {
                Response.Redirect("~/MachineOff/M_off_setting.aspx"  );
            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/OR_OA/ORandMOR1.aspx"  );
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/Users/UserLogin.aspx?Source=ParameterSetting");
            }
            else
            {
                Response.Redirect("~/Parameters/ParameterSetting.aspx"  );
            }
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Projects/ProjectSummary.aspx"  );
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/Users/UserLogin.aspx?Source=ShiftDefinitionSetting"  );
            }
            else
            {
                Response.Redirect("~/Shifts/ShiftDefintionSetting1.aspx"  );
            }

        }

        protected void Button14_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TimeSequence/TimeSequence1.aspx"  );
        }

        protected void Button17_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MachineInputs/InputFromMachines1.aspx"  );
        }

       

    }
}