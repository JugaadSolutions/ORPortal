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
    
    public partial class TimeSequence1_Show : System.Web.UI.Page
    {
        static DataTable dt,dt1;
        protected void Page_Load(object sender, EventArgs e)
        {

            DataAccess da = new DataAccess();
            int machineId = Convert.ToInt32(Request.QueryString["MachineId"]);

           
           

            DateTime fromDate = DateTime.Parse(Request.QueryString["datefrom"]);
            DateTime toDate = DateTime.Parse(Request.QueryString["dateto"]);
            toDate = toDate.AddDays(1);

            while (fromDate < toDate )
            {
                TextBox Duration = new TextBox();
                Duration.TextMode = TextBoxMode.SingleLine;
                Duration.Style.Add("text-align", "center");
                Duration.Style.Add("margin", "10px");
                Duration.Width = new Unit("60%");

              


                int ShiftId = Convert.ToInt32(Request.QueryString["ShiftId"]);


                dt = da.GetShiftTimings(machineId, ShiftId);
                Duration.Text = fromDate.ToShortDateString() +":"+ (dt.Rows[0]["shifts"]).ToString();
                dt1 = da.GetStopDetails(machineId, ShiftId, fromDate.ToShortDateString(), toDate.ToShortDateString(),
                    Convert.ToBoolean(Request.QueryString["SpeedLoss"]));

                GridView g = new GridView();
                g.AutoGenerateColumns = true;
                g.HorizontalAlign = HorizontalAlign.Center;
                g.DataSource = dt1;
                g.DataBind();
                Panel1.Controls.Add(Duration);
                Panel1.Controls.Add(g);
                fromDate = fromDate.AddDays(1);
            }

               
        }

        protected void BackButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }
    }
}