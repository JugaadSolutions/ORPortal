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
    public partial class StopProblemSetting_Enter : System.Web.UI.Page
    {
        static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Code"] != null)
                {
                    DataAccess da = new DataAccess();
                    dt = da.SelectSpecificProblems(Convert.ToInt32(Request.QueryString["Code"]),
                        Convert.ToInt32(Request.QueryString["MachineId"]));
                    // DataTable tb= new DataTable();
                    // Session["ss"] = tb;
                    TextBox2.Enabled = false;
                    TextBox3.Text = (dt.Rows[0]["Description"]).ToString();
                    TextBox2.Text = (dt.Rows[0]["Code"]).ToString();
                    RadioButtonList1.SelectedIndex = (int)(dt.Rows[0]["Type"]) - 1;
                }
                OperationTime2ListBox.Visible = false;
            }
            
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (Request.QueryString["Code"] == null)
            {
                DataAccess da = new DataAccess();
                bool b = da.AddSpecificProblem(TextBox3.Text, TextBox2.Text, RadioButtonList1.Text, Convert.ToInt32(Request.QueryString["MachineId"]));
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
                da.UpdateSpecificProblems(Request.QueryString["Code"], TextBox3.Text, RadioButtonList1.Text);
                Response.Write("<script>alert('Problem Updated..');if(alert){ window.location='../Index.aspx';}</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex == 1)
            {
                OperationTime2ListBox.Visible = true;
            }
            else OperationTime2ListBox.Visible = false;
        }
    }
}