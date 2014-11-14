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
                //List<ShiftHistory> tempList = new List<ShiftHistory>();
                dt = da.GetScrapsReport(Convert.ToInt32(Request.QueryString["MachineId"]),
                       Convert.ToInt32(Request.QueryString["ShiftId"]), from, to);
                if (dt.Rows.Count > 0)
                {
                    for (int j = 2; j < dt.Columns.Count; j++)
                    {
                        int i = dt.Rows.Count - 1;
                        ActualTotal.Text += dt.Rows[i][j];
                        j = j + 1;
                        ScrapsTotal.Text += dt.Rows[i][j];
                        j = j + 1;
                        RejectionTotal.Text += dt.Rows[i][j];
                    }


                }
                else
                {
                    TotalPanel.Visible = false;
                }

                    GridView1.DataSource = dt;
                GridView1.DataBind();

            //    TextBox Total = new TextBox();
            //    Total.TextMode = TextBoxMode.SingleLine;
            //    Total.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FF9966");
            //    Total.Style.Add("text-align", "center");

            //    Total.Style.Add(HtmlTextWriterStyle.FontStyle, "Bold");
            //    Total.Width = new Unit("100%");
            //    Total.Height = new Unit("30px");
            //    Total.Text = "Cumulative";

            //    MainPanel.Controls.Add(Total);

            //    GridView g1 = new GridView();
            //    g1.Style.Add(HtmlTextWriterStyle.Width, "100%");
            //    g1.HorizontalAlign = HorizontalAlign.Center;
            //    BoundField b1;

            //    b1 = new BoundField();
            //    b1.DataField = "Date";
            //    b1.HeaderText = "Date";
            //    g1.Columns.Add(b1);

            //    b1 = new BoundField();
            //    b1.DataField = "Actual";
            //    b1.HeaderText = "OK Pieces";
            //    g1.Columns.Add(b1);

            //    b1 = new BoundField();
            //    b1.DataField = "Scraps";
            //    b1.HeaderText = "Scraps";
            //    g1.Columns.Add(b1);

            //    b1 = new BoundField();
            //    b1.DataField = "LoadTime";
            //    b1.HeaderText = "Load Time/ Available Time [s]";
            //    g1.Columns.Add(b1);


            //    b1 = new BoundField();
            //    b1.DataField = "Nop1";
            //    b1.HeaderText = "Non-Operation Time 1 / Machine Related [s] ";
            //    g1.Columns.Add(b1);

            //    b1 = new BoundField();
            //    b1.DataField = "Nop2";
            //    b1.HeaderText = "Non-Operation Time 2 / Other Than \n Machine Related [s] ";
            //    g1.Columns.Add(b1);

            //    b1 = new BoundField();
            //    b1.DataField = "Undefined";
            //    b1.HeaderText = "Undefined [s] ";
            //    g1.Columns.Add(b1);

            //    b1 = new BoundField();
            //    b1.DataField = "Idle";
            //    b1.HeaderText = "Idle Time/ Exclude Hour [s] ";
            //    g1.Columns.Add(b1);

            //    b1 = new BoundField();
            //    b1.DataField = "KR";
            //    b1.HeaderText = "KADOURITSU/ Operation Ratio [%] ";
            //    g1.Columns.Add(b1);

            //    b1 = new BoundField();
            //    b1.DataField = "BKR";
            //    b1.HeaderText = "BEKADOURITSU/ Operational Availability [%] ";
            //    g1.Columns.Add(b1);

            //    ShiftHistory cumulative = new ShiftHistory();
            //    List<ShiftHistory> cumulativeList = new List<ShiftHistory>();

            //    foreach (ShiftHistory s in tempList)
            //    {
            //        cumulative.CycleTime += s.CycleTime;
            //        cumulative.Actual += s.Actual;
            //        cumulative.Scraps += s.Scraps;
            //        cumulative.LoadTime += s.LoadTime;
            //        cumulative.Nop1 += s.Nop1;
            //        cumulative.Nop2 += s.Nop2;
            //        cumulative.Idle += s.Idle;
            //        cumulative.Undefined += s.Undefined;
            //        cumulative.KR += ((s.Actual * s.CycleTime));
            //        cumulative.BKR += ((s.LoadTime - s.Nop1));
            //    }
            //    cumulative.KR = Math.Round(((cumulative.CycleTime * cumulative.Actual) / cumulative.LoadTime) * 100, 2);
            //    cumulative.BKR = Math.Round(((cumulative.LoadTime - cumulative.Nop1) / cumulative.LoadTime) * 100, 2);

            //    cumulativeList.Add(cumulative);

            //    g1.AutoGenerateColumns = false;

            //    g1.RowDataBound += g1_RowDataBound;
            //    g1.ShowHeader = false;
            //    g1.DataSource = cumulativeList;

            //    g1.DataBind();

            //    MainPanel.Controls.Add(g1);


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