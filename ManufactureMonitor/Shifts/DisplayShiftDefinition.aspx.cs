using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ManufactureMonitor.DALayer;
using System.Data;


namespace ManufactureMonitor
{
    public partial class DisplayShiftDefinition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR";
            if (!Page.IsPostBack)
            {
                
                DataAccess da = new DataAccess();

                DataTable dt = da.GetSchedule(Convert.ToInt32(Session["MachineGroup"]));
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void BackButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx");
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            int no_rows = GridView1.Rows.Count;

            for (int i = 0; i < no_rows; i++)
            {
                GridView1.Rows[i].Cells[0].Width = new Unit("30px");
                GridView1.Rows[i].Cells[1].Width = new Unit("30px");
                GridView1.Rows[i].Cells[2].Width = new Unit("30px");
                GridView1.Rows[i].Cells[3].Width = new Unit("30px");
                GridView1.Rows[i].Cells[4].Width = new Unit("30px");
                GridView1.Rows[i].Cells[5].Width = new Unit("30px");
                GridView1.Rows[i].Cells[6].Width = new Unit("30px");
                GridView1.Rows[i].Cells[7].Width = new Unit("30px");
                GridView1.Rows[i].Cells[8].Width = new Unit("30px");
                GridView1.Rows[i].Cells[9].Width = new Unit("30px");
                GridView1.Rows[i].Cells[10].Width = new Unit("30px");
                GridView1.Rows[i].Cells[11].Width = new Unit("30px");
                GridView1.Rows[i].Cells[12].Width = new Unit("30px");
                GridView1.Rows[i].Cells[13].Width = new Unit("30px");
                GridView1.Rows[i].Cells[14].Width = new Unit("30px");
                GridView1.Rows[i].Cells[15].Width = new Unit("30px");
                GridView1.Rows[i].Cells[16].Width = new Unit("30px");
                GridView1.Rows[i].Cells[17].Width = new Unit("30px");
                GridView1.Rows[i].Cells[18].Width = new Unit("30px");

            }

            
        }
        
    }
}