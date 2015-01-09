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
    public partial class M_off_setting_show : System.Web.UI.Page
    {
        DataTable dt;
        static int MachineId;
        static int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR  " + Session["MachineName"];
            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
                MachineId = Convert.ToInt32(Session["MachineId"]);
                dt = da.GetOffInfo(MachineId);

                CodeDropDown.DataSource = dt;
                CodeDropDown.DataValueField = "Description";
                CodeDropDown.DataBind();
                CodeDropDown.SelectedIndex = -1;
                //Session["Code"] = CodeDropDown.SelectedItem.Value;

                bool b = da.getOffMachine(MachineId);
                if (b == true)
                {
                    StopImage.Visible = true;
                    M_Off_Imm.Text = "Cancel Machine OFF Immediately";
                    DropDownPanel.Visible = false;
                }
                else
                {
                    StopImage.Visible = false;
                    M_Off_Imm.Text = "Machine OFF Immediately";
                    DropDownPanel.Visible = true;
                    Session["Code"] = CodeDropDown.SelectedItem.Value;
                    String Selected = CodeDropDown.SelectedItem.Value;
                    String[] words = Selected.Split(':');
                    Code = Convert.ToInt32(words[0]);
                }
            }
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx");
        }

      

        
        protected void Timer1_Tick(object sender, EventArgs e)
        {

            DataAccess da = new DataAccess();
            //MachineId = Convert.ToInt32(Session["MachineId"]);
            
            dt = da.GetOffInfo(MachineId);

            CodeDropDown.DataSource = dt;
            CodeDropDown.DataValueField = "Description";
            CodeDropDown.DataBind();
            CodeDropDown.SelectedIndex = -1;
            //Session["Code"] = CodeDropDown.SelectedItem.Value;

            bool b = da.getOffMachine(MachineId);
            if (b == true)
            {
                StopImage.Visible = true;
                M_Off_Imm.Text = "Cancel Machine OFF Immediately";
                DropDownPanel.Visible = false;
               
            }
            else
            {
                StopImage.Visible = false;
                M_Off_Imm.Text = "Machine OFF Immediately";
                DropDownPanel.Visible = true;
                Session["Code"] = CodeDropDown.SelectedItem.Value;
                String Selected = CodeDropDown.SelectedItem.Value;
                String[] words = Selected.Split(':');
                Code = Convert.ToInt32(words[0]);
            }

        }

        protected void CMOffRetro_Click(object sender, EventArgs e)
        {
            String from = from1.Text + ":" + from2.Text;
            String to = To1.Text + ":" + To2.Text;
            DateTime Time1 = DateTime.Parse(Date.SelectedDate.ToString("yyyy-MM-dd") + " " + from);
            DateTime Time2 = DateTime.Parse(Date.SelectedDate.ToString("yyyy-MM-dd") + " " + to);
            DataAccess da = new DataAccess();
            da.SetCM_Off_Retro(MachineId, Time1, Time2);
            from1.Text = "";
            from2.Text = "";
            To1.Text = "";
            To2.Text = "";
            Response.Redirect("~/MachineOff/M_off_setting_show.aspx");
        }

        protected void MOffRetro_Click(object sender, EventArgs e)
        {
            String from = from1.Text+":"+from2.Text;
            String to = To1.Text + ":" + To2.Text;

            DateTime Time1 = DateTime.Parse(Date.SelectedDate.ToString("yyyy-MM-dd") + " " + from);
            DateTime Time2 = DateTime.Parse(Date.SelectedDate.ToString("yyyy-MM-dd") + " " + to);
            DataAccess da = new DataAccess();
            da.SetM_Off_Retro(MachineId,Time1,Time2);
            from1.Text = "";
            from2.Text = "";
            To1.Text = "";
            To2.Text = "";
            Response.Redirect("~/MachineOff/M_off_setting_show.aspx");
        }

        protected void MachimeSelection_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MachineOff/M_off_setting.aspx");
        }

        protected void M_Off_Imm_Click(object sender, EventArgs e)
        {
            
            String ExeTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            String TimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DataAccess da = new DataAccess();
            da.SetM_Off_Imm(MachineId,Code,ExeTime,TimeStamp);
            from1.Text = "";
            from2.Text = "";
            To1.Text = "";
            To2.Text = "";
            Response.Redirect("~/MachineOff/M_off_setting_show.aspx");
        }

        
    }
}