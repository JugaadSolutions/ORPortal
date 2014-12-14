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
            ((Label)Master.FindControl("MasterPageLabel")).Text = " OR  "+Session["MachineName"];
            DataTable dt,dt1,dt2;
            if (!Page.IsPostBack)
            {
                
                DataAccess da = new DataAccess();

                dt = da.GetSchedule(Convert.ToInt32(Request.QueryString["MachineId"]));
                GridView1.DataSource = dt;
                GridView1.DataBind();
                dt1 = da.GetShiftDays(Convert.ToInt32(Request.QueryString["MachineId"]));
                FirstShiftTextBox.Text = "Shift: 6:30-15:00 , "+ dt1.Rows[0]["Days"];
                SecondShiftTextBox.Text = "Shift: 15:00-23:00 , " + dt1.Rows[1]["Days"];
                ThirdShiftTextBox.Text = "Shift: 23:00-6:30 , " + dt1.Rows[2]["Days"];
                for (int i = 1; i < 4; i++)
                {
                    dt2=da.GetSession(Convert.ToInt32(Request.QueryString["MachineId"]), i);
                    if (i == 1)
                    {
                        FirstShiftGrid.DataSource = dt2;
                        FirstShiftGrid.DataBind();
                    }
                    else
                    {
                        if (i == 2)
                        {
                            SecondShiftGrid.DataSource = dt2;
                            SecondShiftGrid.DataBind();
                        }
                        else
                        {
                            ThirdShiftGrid.DataSource = dt2;
                            ThirdShiftGrid.DataBind();
                        }
                    }
                }
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