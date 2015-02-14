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
    public partial class CommonProblemsSetting : System.Web.UI.Page
    {
        static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR";
            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
                dt = da.GetCommonProblems();
                ProblemSelectionListBox.DataSource = dt.DefaultView;
                ProblemSelectionListBox.DataValueField = "Description";
                ProblemSelectionListBox.DataBind();
            }
           
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Problems/CommonProblemsSetting_ADD.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (ProblemSelectionListBox.SelectedIndex == -1)
                return;
            else
            {
            Response.Redirect("~/Problems/CommonProblemsSetting_ADD.aspx?Code="
                + dt.Rows[ProblemSelectionListBox.SelectedIndex]["Code"]);
            }


        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (ProblemSelectionListBox.SelectedIndex == -1)
                return;
            DataAccess da = new DataAccess();
            da.DeleteProblem((Int32)dt.Rows[ProblemSelectionListBox.SelectedIndex]["Code"]);
            Response.Write("<script>alert('Problem Deleted Successfully..');if(alert){ window.location='../Problems/CommonProblemsSetting.aspx?MachineId=" + Request.QueryString["MachineId"] + "';}</script>");
        }
    }
}