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
    public partial class ProblemAccumulation_Show : System.Web.UI.Page
    {
        static DataTable dt,dt1;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR  " + Session["MachineName"];
            DataAccess da = new DataAccess();
            int machine = Convert.ToInt32(Request.QueryString["MachineId"]);

            DateTime fromDate = DateTime.Parse(Request.QueryString["datefrom"]);
            DateTime toDate = DateTime.Parse(Request.QueryString["dateto"]);
            toDate = toDate.AddDays(1);
            int ShiftId = Convert.ToInt32(Request.QueryString["ShiftId"]);
            while (fromDate < toDate)
            {
                dt = da.GetShiftTimings(machine, ShiftId);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DateTime from = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["Start"]);
                    DateTime to = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["End"]);

                    dt1 = da.GetAccumulation(machine, from.ToString("yyyy-MM-dd HH:mm:ss"),
                                to.ToString("yyyy-MM-dd HH:mm:ss"));

                }
                fromDate = fromDate.AddDays(1);
            }
            GridView1.DataSource = dt1;
            GridView1.DataBind();
        }


        protected void BackButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }
    }
}