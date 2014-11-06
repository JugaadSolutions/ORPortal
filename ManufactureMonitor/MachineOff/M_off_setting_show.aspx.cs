using ManufactureMonitor.DALayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManufactureMonitor
{
    public partial class M_off_setting_show : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
                int MachineId = Convert.ToInt32(Request.QueryString["MachineId"]);


                bool b = da.getOffMachine(MachineId);
                if (b == true)
                {
                    StopImage.Visible = true;
                    Button2.Text = "Cancel Machine OFF Immediately";
                }
                else
                {
                    StopImage.Visible = false;
                    Button2.Text = "Machine OFF Immediately";
                }
            }
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MachineOff/CancelMachineOff.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MachineOff/M_off_setting.aspx");
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {

            DataAccess da = new DataAccess();
            int MachineId = Convert.ToInt32(Request.QueryString["MachineId"]);


            bool b = da.getOffMachine(MachineId);
            if (b == true)
            {
                StopImage.Visible = true;
                Button2.Text = "Cancel Machine OFF Immediately";
            }
            else
            {
                StopImage.Visible = false;
                Button2.Text = "Machine OFF Immediately";
            }

        }

        
    }
}