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
    public partial class Scrap_show : System.Web.UI.Page
    {
        static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR  " + Session["MachineName"];
            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
                DateTime from = DateTime.Parse(Request.QueryString["From"]);
                DateTime to = DateTime.Parse(Request.QueryString["To"]);

                to = to.AddDays(1);

                dt = da.GetScrapsReport(Convert.ToInt32(Request.QueryString["MachineId"]),
                       Convert.ToInt32(Request.QueryString["ShiftId"]), from, to);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx");
        }
    }
}