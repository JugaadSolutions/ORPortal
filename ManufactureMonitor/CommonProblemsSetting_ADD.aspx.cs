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
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/CommonProblemsSetting.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CommonProblemsSetting.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Code"] == null)
            {
                DataAccess da = new DataAccess();
                bool b = da.AddProblems(TextBox3.Text, TextBox2.Text, RadioButtonList1.Text);
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
                da.UpdateProblems(Request.QueryString["Code"], TextBox3.Text, RadioButtonList1.Text);
                Response.Write("<script>alert('Problem Updated..');if(alert){ window.location='../Index.aspx';}</script>");
            }
        }
    }
}