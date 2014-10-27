using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using ManufactureMonitor.DALayer;
using System.Data;
using ManufactureMonitor.Entity;

namespace ManufactureMonitor
{
    public partial class ParameterSetting_Show : System.Web.UI.Page
    {
        static DataTable dt;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
                dt= da.GetMachineParameters(Convert.ToInt32(Request.QueryString["Id"]));
                TextBox2.Text = (dt.Rows[0]["TOS"]).ToString();
                TextBox3.Text = (dt.Rows[0]["Pulses"]).ToString();
                TextBox4.Text = (dt.Rows[0]["Pieces"]).ToString();
                TextBox5.Text = (dt.Rows[0]["Rmin"]).ToString();
                TextBox6.Text = (dt.Rows[0]["Rmax"]).ToString();
                TextBox7.Text = (dt.Rows[0]["Omin"]).ToString();
                TextBox8.Text = (dt.Rows[0]["Omax"]).ToString();
                TextBox9.Text = (dt.Rows[0]["Gmin"]).ToString();
                TextBox10.Text = (dt.Rows[0]["Gmax"]).ToString();
                TextBox11.Text = (dt.Rows[0]["MPDuration"]).ToString();
                TextBox12.Text = (dt.Rows[0]["StopCloseDuration"]).ToString();
            }
            

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Menu.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataAccess da = new DataAccess();
            int machine = Convert.ToInt32(Request.QueryString["Id"]);
             da.UpdateParameters(machine,
                Convert.ToDouble(TextBox2.Text), TextBox3.Text, TextBox4.Text,
                Convert.ToDouble(TextBox5.Text), Convert.ToDouble(TextBox6.Text), 
                Convert.ToDouble(TextBox7.Text), Convert.ToDouble(TextBox8.Text),
                Convert.ToDouble(TextBox9.Text), Convert.ToDouble(TextBox10.Text),
                Convert.ToDouble(TextBox11.Text), Convert.ToDouble(TextBox12.Text));
             Response.Write("<script>alert('Parameters Updated...');if(alert){ window.location='../Menu.aspx';}</script>");
             //Response.Redirect("~/Parameters/ParameterSetting.aspx?Id="+ Request.QueryString["Id"]);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Menu.aspx");
        }

       

    }
}