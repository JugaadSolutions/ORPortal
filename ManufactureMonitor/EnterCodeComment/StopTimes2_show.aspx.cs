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
    public partial class StopTimes2_show : System.Web.UI.Page
    {
        static DataTable dt,dt1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
                int machineId = Convert.ToInt32(Request.QueryString["MachineId"]);




                DateTime fromDate = DateTime.Parse(Request.QueryString["date"]);
             
                
                int ShiftId = Convert.ToInt32(Request.QueryString["ShiftId"]);


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
                dt1 = da.GetStopDetails(machineId, ShiftId, from.ToString("yyyy-MM-dd HH:mm:ss"),
                    to.ToString("yyyy-MM-dd HH:mm:ss"),
                    Convert.ToBoolean(Request.QueryString["SpeedLoss"]));

                GridView1.DataSource = dt1;
                GridView1.DataBind();


            }

        }
            

               
        
        

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Menu.aspx");
        }
    }
}