using ManufactureMonitor.DALayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManufactureMonitor.Scraps
{
    public partial class Scrap_entry : System.Web.UI.Page
    {
        static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR  " + Session["MachineName"];
            if (!Page.IsPostBack)
            {
                showGrid();
               
                TextBox1.Text += Request.QueryString["From"] +"   To   "+ Request.QueryString["To"];
            }

        }

        void showGrid()
        {
            DataAccess da = new DataAccess();
            DateTime from = DateTime.Parse(Request.QueryString["From"]);
            DateTime to = DateTime.Parse(Request.QueryString["To"]);

            to = to.AddDays(1);

            dt = da.GetScrapsEntry(Convert.ToInt32(Request.QueryString["MachineId"]),
                   Convert.ToInt32(Request.QueryString["ShiftId"]),from,to);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx");
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataAccess da = new DataAccess();
            GridViewRow gr = this.GridView1.Rows[GridView1.EditIndex];
            TextBox sc = (TextBox)gr.Cells[2].FindControl("ScrapTextbox");
            int scrapvalue;
            if (int.TryParse(sc.Text, out scrapvalue) == false) return;


            da.updateScraps((int)dt.Rows[GridView1.EditIndex]["ProjectTracker_Id"], scrapvalue);
            GridView1.EditIndex = -1;
            showGrid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridViewRow gr = this.GridView1.Rows[GridView1.EditIndex];
            //TextBox sc = (TextBox)gr.Cells[2].FindControl("ScrapTextbox");
            //sc.Focus();
            showGrid();
        }
    }
}