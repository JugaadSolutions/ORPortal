using ManufactureMonitor.DALayer;
using ManufactureMonitor.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
                int machineId = Convert.ToInt32(Request.QueryString["MachineId"]);
                DateTime fromDate = DateTime.Parse(Request.QueryString["From"]);
                DateTime toDate = DateTime.Parse(Request.QueryString["To"]);
                toDate = toDate.AddDays(1);
                int ShiftId = Convert.ToInt32(Request.QueryString["ShiftId"]);
                

                while (fromDate < toDate)
                {
                    DataTable ShiftTimingsTable = da.GetShiftTimings(machineId, ShiftId);
                    for (int i = 0; i < ShiftTimingsTable.Rows.Count; i++)
                    {
                        TextBox Duration = new TextBox();
                        Duration.TextMode = TextBoxMode.SingleLine;
                        Duration.Style.Add("text-align", "center");
                        Duration.Style.Add("margin", "10px");
                        Duration.Width = new Unit("60%");


                        DateTime from = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + ShiftTimingsTable.Rows[i]["Start"]);
                        DateTime to = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + ShiftTimingsTable.Rows[i]["End"]);

                        if (to < from)
                            to = to.AddDays(1);

                   
                        dt = da.GetScrapsReport(Convert.ToInt32(Request.QueryString["MachineId"]),
                                from, to);

                        Duration.Text = fromDate.ToShortDateString() + ":" + (ShiftTimingsTable.Rows[i]["shifts"]).ToString();


                        GridView g = new GridView();
                        g.AutoGenerateColumns = false;
                        g.HeaderStyle.BackColor = Color.OrangeRed;
                        g.Style.Add(HtmlTextWriterStyle.Width, "50%");
                        g.HorizontalAlign = HorizontalAlign.Center;

                        BoundField b = new BoundField();
                        b.DataField = "Date";
                        b.HeaderText = "Date";

                        g.Columns.Add(b);

                        b = new BoundField();
                        b.DataField = "Actual";
                        b.HeaderText = "Total Pieces";


                        g.Columns.Add(b);

                        b = new BoundField();
                        b.DataField = "Scraps";
                        b.HeaderText = "Rejection";

                        g.Columns.Add(b);

                        b = new BoundField();
                        b.DataField = "Rejection";
                        b.HeaderText = "[%] Rejection";

                        g.Columns.Add(b);

                        g.HorizontalAlign = HorizontalAlign.Center;
                        g.DataSource = dt;
                        g.DataBind();
                        Panel1.Controls.Add(Duration);
                        Panel1.Controls.Add(g);
                       
                    }

                    fromDate = fromDate.AddDays(1);
                }
              

              



            }
            
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx");
        }
     //void g_RowDataBound(object sender, GridViewRowEventArgs e)
     //   {


     //       if (e.Row.RowType == DataControlRowType.DataRow)
     //       {
     //           e.Row.Cells[0].Width = 100;
     //           e.Row.Cells[1].Width = 100;
     //           e.Row.Cells[2].Width = 100;
     //           e.Row.Cells[3].Width = 100;
     //           e.Row.Cells[4].Width = 100;
     //           e.Row.Cells[5].Width = 100;
     //           e.Row.Cells[6].Width = 100;
     //           e.Row.Cells[7].Width = 100;
     //           e.Row.Cells[8].Width = 100;
     //           e.Row.Cells[9].Width = 100;
                  
     //       }


     //   }


     //   void g1_RowDataBound(object sender, GridViewRowEventArgs e)
     //   {


     //       if (e.Row.RowType == DataControlRowType.DataRow)
     //       {
     //           e.Row.Cells[0].Width = 100;
     //           e.Row.Cells[1].Width = 100;
     //           e.Row.Cells[2].Width = 100;
     //           e.Row.Cells[3].Width = 100;
     //           e.Row.Cells[4].Width = 100;
     //           e.Row.Cells[5].Width = 100;
     //           e.Row.Cells[6].Width = 100;
     //           e.Row.Cells[7].Width = 100;
     //           e.Row.Cells[8].Width = 100;
     //           e.Row.Cells[9].Width = 100;
               
                


     //       }


     //   }
    }
}