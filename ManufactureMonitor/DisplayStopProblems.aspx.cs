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
    public partial class DisplayStopProblems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();

                DataTable dt = da.DisplaySpecificProblems(Convert.ToInt32(Request.QueryString["MachineId"]));
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            
        }

        protected void BackButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            int no_rows = GridView1.Rows.Count;

            for (int i = 0; i < no_rows; i++)
            {
                GridView1.Rows[i].Cells[0].Width = new Unit("40%");
                GridView1.Rows[i].Cells[1].Width = new Unit("10%");
                GridView1.Rows[i].Cells[2].Width = new Unit("5%");
                GridView1.Rows[i].Cells[3].Width = new Unit("5%");
                GridView1.Rows[i].Cells[4].Width = new Unit("5%");
            }
        }
        
    }
}