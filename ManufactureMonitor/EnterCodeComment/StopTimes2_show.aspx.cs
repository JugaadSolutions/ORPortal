using ManufactureMonitor.DALayer;
using ManufactureMonitor.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManufactureMonitor
{
    public partial class StopTimes2_show : System.Web.UI.Page
    {
        static DataTable dt,dt1;
        static List<TimeSequence> Ts;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR  " + Session["MachineName"];
            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
                int machineId = Convert.ToInt32(Session["Machine_Id"]);




                DateTime fromDate = DateTime.Parse(Session["date"].ToString());
             
                
                int ShiftId = Convert.ToInt32(Session["Shift_Id"]);


                dt = da.GetShiftTimings(machineId, ShiftId);

                TextBox Duration = new TextBox();
                Duration.TextMode = TextBoxMode.SingleLine;
                Duration.Style.Add("text-align", "center");
                Duration.Style.Add("margin", "10px");
                Duration.Width = new Unit("60%");


                DateTime from = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[0]["Start"]);
                DateTime to = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[0]["End"]);

                if (to < from)
                    to = to.AddDays(1);




                Duration.Text = fromDate.ToShortDateString() + ":" + (dt.Rows[0]["shifts"]).ToString();
                Ts= da.GetStopDetails(machineId, ShiftId, from.ToString("yyyy-MM-dd HH:mm:ss"),
                    to.ToString("yyyy-MM-dd HH:mm:ss"),
                    Convert.ToBoolean(Request.QueryString["SpeedLoss"]));

                GridView1.DataSource = Ts;
                GridView1.DataBind();


            }

        }
            

               
        
        

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Menu.aspx");
        }
    }
}