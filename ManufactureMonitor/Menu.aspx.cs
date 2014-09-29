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
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ActualState.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ShiftHistroy1.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/ProjectAssignment.aspx");
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DisplayProject.aspx");
        }

        protected void Button20_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DisplayStopProblems.aspx?MachineGroupId=" + Request.QueryString["MachineGroup"]);
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DisplayShiftDefinition.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DisplayParameters.aspx?MachineGroupId=" + Request.QueryString["MachineGroup"]);
        }

        protected void Button19_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PasswordChange.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Scrap1.aspx");
        }

        protected void Button18_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StopProblemSetting.aspx");
        }

        protected void Button15_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StopTimes2.aspx");
        }

        protected void Button16_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ProblemAccumulation.aspx");
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ProjectSetting.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/M_off_setting.aspx");
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ORandMOR1.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ParameterSetting.aspx");
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ProjectSummary.aspx");
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ShiftDefinitionSetting.aspx");
        }

        protected void Button14_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TimeSequence1.aspx");
        }

       

    }
}