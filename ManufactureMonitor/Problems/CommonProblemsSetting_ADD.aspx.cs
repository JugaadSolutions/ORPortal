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
    public partial class CommonProblemsSetting_ADD : System.Web.UI.Page
    {
        static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR";
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Code"] != null)
                {
                    DataAccess da = new DataAccess();
                    dt = da.SelectCommonProblems(Request.QueryString["Code"]);
                    // DataTable tb= new DataTable();
                    // Session["ss"] = tb;
                    TextBox2.Enabled = false;
                    TextBox3.Text = (dt.Rows[0]["Description"]).ToString();
                    TextBox2.Text = (dt.Rows[0]["Code"]).ToString();
                    RadioButtonList1.SelectedIndex =(int) (dt.Rows[0]["Type"]) -1;
                    if (RadioButtonList1.SelectedIndex == 1)
                    {
                        Operation2Selection.Visible = true;
                        Operation2Selection.SelectedIndex = (int)(dt.Rows[0]["SubType"]) - 1;
                    }
                    else
                    {
                        Operation2Selection.Visible = false;
                    }
                }
                else
                {
                    Operation2Selection.Visible = false;
                }

            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Problems/CommonProblemsSetting.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Code"] == null)
            {
                DataAccess da = new DataAccess();
                bool b = da.AddProblems(
                        TextBox3.Text, Convert.ToInt32(TextBox2.Text), RadioButtonList1.SelectedIndex+1,Operation2Selection.SelectedIndex+1);
                if (b == true)
                {
                    Response.Write("<script>alert('Problem Added Successfully..');if(alert){ window.location='../Problems/CommonProblemsSetting.aspx?MachineId=" + Request.QueryString["MachineId"] + "';}</script>");


                }
                else
                {
                    Response.Write("<script>alert('Problem code already exist..');if(alert){ window.location='../Problems/CommonProblemsSetting.aspx?MachineId=" + Request.QueryString["MachineId"] + "';}</script>");
                }
            }
            else
            {
                DataAccess da = new DataAccess();
                da.UpdateProblems(Convert.ToInt32(TextBox2.Text), TextBox3.Text, RadioButtonList1.SelectedIndex+1,Operation2Selection.SelectedIndex+1);
                Response.Write("<script>alert('Problem Updated..');if(alert){ window.location='../Problems/CommonProblemsSetting.aspx?MachineId=" + Request.QueryString["MachineId"] + "';}</script>");
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex == 1)
            {
                Operation2Selection.Visible = true;
            }
            else Operation2Selection.Visible = false;
        }
    }
}