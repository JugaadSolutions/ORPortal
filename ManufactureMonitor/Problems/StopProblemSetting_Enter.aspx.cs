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
        public int machineId;
        protected void Page_Load(object sender, EventArgs e)
        {
            machineId =  Convert.ToInt32(Request.QueryString["MachineId"]);
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Code"] != null)
                {

                    DataAccess da = new DataAccess();
                    dt = da.SelectSpecificProblems(Convert.ToInt32(Request.QueryString["Code"]),
                       machineId);
                    // DataTable tb= new DataTable();
                    // Session["ss"] = tb;
                    TextBox2.Enabled = false;
                    TextBox3.Text = (dt.Rows[0]["Description"]).ToString();
                    TextBox2.Text = (dt.Rows[0]["Code"]).ToString();
                    RadioButtonList1.SelectedIndex = (int)(dt.Rows[0]["Type"]) - 1;
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
            Response.Redirect("../Menu.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (Request.QueryString["Code"] == null )
            {
                DataAccess da = new DataAccess();
                int machine = Convert.ToInt32(Request.QueryString["MachineId"]);
                bool b = da.AddSpecificProblem(TextBox3.Text, TextBox2.Text, 
                    RadioButtonList1.Text,machine,Operation2Selection.SelectedIndex );
                if (b == true)
                {
                    //String message = "Problem Added Successfully..";
                    //Page page = HttpContext.Current.CurrentHandler as Page;
                    //page.ClientScript.RegisterStartupScript(typeof(Page), "Test", "alertRedirect();");
                    Response.Write("<script>alert('Problem Added Successfully..');if(alert){ window.location='../Problems/StopProblemSetting_Enter.aspx?MachineId=" + Request.QueryString["MachineId"] + "';}</script>");


                }
                else
                {
                    Response.Write("<script>alert('Problem code already exist..');if(alert){ window.location='../Problems/StopProblemSetting_Enter.aspx?MachineId=" + Request.QueryString["MachineId"] + "';}</script>");
                }
            }
            else
            {
                DataAccess da = new DataAccess();
                da.UpdateSpecificProblems(Request.QueryString["Code"], 
                    TextBox3.Text, RadioButtonList1.SelectedIndex+1,Operation2Selection.SelectedIndex+1);

                Response.Write(
                    "<script>alert('Problem Updated..');if(alert){ window.location='../Problems/StopProblemSetting.aspx?MachineId=" + Request.QueryString["MachineId"] + "';}</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Menu.aspx");
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