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
    public partial class ShiftSetting_Add : System.Web.UI.Page
    {
        static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
             
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["ShiftId"] != null)
                {
                    DataAccess da = new DataAccess();
                    dt = da.SelectShift(Convert.ToInt32(Request.QueryString["ShiftId"]));
                    TextBox2.Text = (dt.Rows[0]["SHours"]).ToString();
                    TextBox3.Text = (dt.Rows[0]["SMinutes"]).ToString();
                    TextBox4.Text = (dt.Rows[0]["EHours"]).ToString();
                    TextBox5.Text = (dt.Rows[0]["EMinutes"]).ToString();
                    dt = da.Selectday(Convert.ToInt32(Request.QueryString["ShiftId"]), Convert.ToInt32(Request.QueryString["MachineId"]));
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if ((bool)dt.Rows[0][i] == true )
                        {
                            CheckBoxList1.Items[i].Selected = true;
                        }
                    }
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ShiftId"] == null)
            {
                DataAccess da = new DataAccess();
                bool b = da.AddProblems(TextBox3.Text, TextBox2.Text, CheckBoxList1.Text);
                if (b == true)
                {
                    Response.Write("<script>alert('Shift Added Successfully..');if(alert){ window.location='../Menu.aspx');}</script>");


                }
                //else
                //{
                //    Response.Write("<script>alert('Shift Already Exit..');if(alert){ window.location='../Menu.aspx?MachineGroupId='" + Request.QueryString["MachineGroupId"] + ";}</script>");
                //}
            }
            else
            {
                DataAccess da = new DataAccess();
                DateTime start = new DateTime(2014,01,01,Convert.ToInt32(TextBox2.Text),Convert.ToInt32(TextBox3.Text),0);

                DateTime end = new DateTime(2014, 01, 01, Convert.ToInt32(TextBox4.Text), Convert.ToInt32(TextBox5.Text), 0);

                if (end < start)
                {
                    end.AddDays(1);
                }


                da.UpdateShiftday(Convert.ToInt32(Request.QueryString["MachineId"]),
                    Convert.ToInt32(Request.QueryString["ShiftId"]), CheckBoxList1.Items[0].Selected,
                    CheckBoxList1.Items[1].Selected,CheckBoxList1.Items[2].Selected,
                    CheckBoxList1.Items[3].Selected,CheckBoxList1.Items[4].Selected,
                    CheckBoxList1.Items[5].Selected,CheckBoxList1.Items[6].Selected);
                da.UpdateShift(Convert.ToInt32(Request.QueryString["MachineId"]),start.ToString(),end.ToString());

                    Response.Write("<script>alert('Shift Added Successfully..');if(alert){ window.location='../Menu.aspx');}</script>");
                   
            }
        }
            protected void Button2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }
        
    }
}