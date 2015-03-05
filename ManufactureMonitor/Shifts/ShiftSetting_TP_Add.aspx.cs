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
    public partial class ShiftSetting_TP_Add : System.Web.UI.Page
    {
        static DataTable dt;
        static bool IsEdit = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR  " + Session["MachineName"];
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Session"] != null 
                    && Convert.ToInt32 (Request.QueryString["Session"] ) > 0)
                {
                    DataAccess da = new DataAccess();
                    dt = da.SelectSession(Convert.ToInt32(Request.QueryString["Session"]));


                    TextBox2.Text = (dt.Rows[0]["SHours"]).ToString();
                    TextBox3.Text = (dt.Rows[0]["SMinutes"]).ToString();
                    TextBox4.Text = (dt.Rows[0]["EHours"]).ToString();
                    TextBox5.Text = (dt.Rows[0]["EMinutes"]).ToString();

                    IsEdit = true;  //editing existing shift
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Menu.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (SessionNameDropDown.SelectedIndex == 0 || TextBox2.Text==" " || TextBox3.Text==" " || TextBox4.Text==" " || TextBox5.Text==" ")
                return;
              DataAccess da = new DataAccess();

            List<String> Start = new List<String>();
            List<String> End = new List<String>();

            Start.Add("2014-01-01 " + TextBox2.Text + ":" + TextBox3.Text);
            End.Add("2014-01-01 " + TextBox4.Text + ":" + TextBox5.Text);

          
            
            DateTime start;
            DateTime end;
            if ((DateTime.TryParse(Start[0], out start) == false) || (DateTime.TryParse(End[0], out end) == false))
            {
                Response.Write("<script>alert('Invalid Data. Please Check.');</script>");

            }
            else    // if data is valid
            {
                if (end < start)
                    end = end.AddDays(1);

                int Shift_Id=0;
                if (IsEdit == false)     // if adding a new session
                {

                    if (Shift_Id == -1)
                    {
                        Response.Write("<script>alert('Error while Adding Shift!!');</script>");
                    }
                    bool b1 = da.GetSessionName(Convert.ToInt32(Request.QueryString["MachineId"]),Convert.ToInt32( Request.QueryString["Shift_Id"]),SessionNameDropDown.SelectedValue);
                    if(b1==true)
                    {
                        bool b2=da.AddSession(Convert.ToInt32(Request.QueryString["MachineId"]),Convert.ToInt32( Request.QueryString["Shift_Id"]),
                            start, end, SessionNameDropDown.SelectedValue);
                        if (b2 == true)
                        {
                            Response.Write("<script>alert('Action Completed Successfully..');if(alert){ window.location='../Menu.aspx';}</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Action Failed..');if(alert){ window.location='../Menu.aspx';}</script>");
                        }
                    }
                    else
                    {
                        
                        Response.Write("<script>alert('Session already exists. Please use Edit option to make changes');if(alert){ window.location='../Menu.aspx';}</script>");
                    }
                }

                else
                {
                    

                    da.UpdateSession(Convert.ToInt32(Request.QueryString["MachineId"]),
                        Convert.ToInt32(Request.QueryString["ShiftId"]),Convert.ToInt32(Request.QueryString["Session"]),
                    start.ToString("yyyy-MM-dd HH:mm:ss")
                        , end.ToString("yyyy-MM-dd HH:mm:ss"));

                    Response.Write("<script>alert('Action Completed Successfully..');if(alert){ window.location='../Menu.aspx';}</script>");
                }

            }
               
                


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Menu.aspx");
        }
    }
}