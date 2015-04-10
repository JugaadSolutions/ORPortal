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
using System.Web.UI.HtmlControls;
using System.Configuration;

namespace ManufactureMonitor
{
    public partial class ORandMOR1_Show : System.Web.UI.Page
    {
        static String Project = "";
          static DataTable dt,dt1;
        static List<ShiftHistory> sh;
        static List<ShiftHistory_Summary> shProject;
        protected void Page_Load(object sender, EventArgs e)
        {

            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR  "+Session["MachineName"];
            
            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
                int machineId = Convert.ToInt32(Request.QueryString["MachineId"]);
                String MachineName = Request.QueryString["MachineName"];
                DateTime fromDate = DateTime.Parse(Request.QueryString["datefrom"]);
                DateTime toDate = DateTime.Parse(Request.QueryString["dateto"]);
                //toDate = toDate.AddDays(1);
                int ShiftId = Convert.ToInt32(Request.QueryString["ShiftId"]);
                String ShiftName = Request.QueryString["ShiftName"];
                Project = Request.QueryString["Project"];

                while (fromDate <= toDate)
                {
                    



                    TextBox Duration = new TextBox();
                    Duration.TextMode = TextBoxMode.SingleLine;
                    Duration.BackColor = Color.LightGray;

                    Duration.Style.Add("text-align", "center");
                    Duration.Font.Bold = true;
                    Duration.Font.Name = "Arial";
                    Duration.Font.Size = 12;
                    Duration.Style.Add("margin", "10px");
                    Duration.Width = new Unit("60%");
                    Duration.Height = new Unit("60px");
                    Duration.Text = "OR and OA Accumulation- " + ((Project == String.Empty) ? "" : "Project" + Project)
                                + " ShiftDate: " + fromDate.ToString("dd-MMM-yyyy") + Environment.NewLine
                                + "  Shift:  " + ShiftName;


                    
                    sh = new List<ShiftHistory>();

                    ShiftHistory cumulative = new ShiftHistory();
                    List<ShiftHistory> cumulativeList = new List<ShiftHistory>();

                    dt = da.GetShiftTimings(machineId, ShiftId);

                    #region GRID_COLUMNS
                    GridView g = new GridView();
                    g.AutoGenerateColumns = false;
                    g.HeaderStyle.BackColor = Color.OrangeRed;
                    g.Style.Add(HtmlTextWriterStyle.Width, "100%");
                    g.HorizontalAlign = HorizontalAlign.Center;
                    BoundField b;
                    b = new BoundField();
                    b.DataField = "Date";
                    b.HeaderText = "Date";
                    g.Columns.Add(b);

                    b = new BoundField();
                    b.DataField = "Actual";
                    b.HeaderText = "Actual Pieces";
                    g.Columns.Add(b);

                    b = new BoundField();
                    b.DataField = "Scraps";
                    b.HeaderText = "Scraps";
                    g.Columns.Add(b);

                    b = new BoundField();
                    b.DataField = "LoadTime";
                    b.HeaderText = "Load Time/ Available Time [s]";
                    g.Columns.Add(b);


                    b = new BoundField();
                    b.DataField = "Nop1";
                    b.HeaderText = "Non-Operation Time 1 / Machine Related [s] ";
                    g.Columns.Add(b);

                    b = new BoundField();
                    b.DataField = "Nop2";
                    b.HeaderText = "Non-Operation Time 2 / Other Than Machine Related [s] ";
                    g.Columns.Add(b);

                    b = new BoundField();
                    b.DataField = "Undefined";
                    b.HeaderText = "Undefined [s] ";
                    g.Columns.Add(b);

                    b = new BoundField();
                    b.DataField = "Idle";
                    b.HeaderText = "Idle Time/ Exclude Hour [s] ";
                    g.Columns.Add(b);

                    b = new BoundField();
                    b.DataField = "KR";
                    b.HeaderText = "KADOURITSU/ Operation Ratio [%] ";
                    g.Columns.Add(b);

                    b = new BoundField();
                    b.DataField = "BKR";
                    b.HeaderText = "BEKADOURITSU/ Operational Availability [%] ";
                    g.Columns.Add(b);
                    #endregion
                    List<ShiftHistory> tempList = new List<ShiftHistory>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        ShiftHistory temp = new ShiftHistory();
                        

                        DateTime from = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["Start"]);
                        DateTime to = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["End"]);

                        if (to < from)
                            to = to.AddDays(1);

                        temp.Date = from.ToString("dd-MMM-yyyy");


                        sh = da.GetShiftHistory(machineId, from.ToString("yyyy-MM-dd HH:mm:ss"),
                                to.ToString("yyyy-MM-dd HH:mm:ss"), from.ToString("dd-MM-yyyy")
                                );

                        cumulativeList.AddRange(sh);

                        foreach (ShiftHistory s in sh)
                        {
                            if (Project != "")
                            {
                                if (s.Project != Project)
                                    continue;
                            }
                            //temp.CycleTime += s.CycleTime;
                            temp.Actual += s.Actual;
                            temp.KR += s.CycleTime * s.Actual;
                            temp.Scraps += s.Scraps;
                            temp.LoadTime += s.LoadTime;
                            temp.Nop1 += s.Nop1;
                            temp.Nop2 += s.Nop2;
                            temp.Idle += s.Idle;
                            temp.Undefined += s.Undefined;
                        }

                        double kr = (temp.KR / temp.LoadTime) * 100;

                        temp.KR = Math.Round(kr, 2);

                        double bkr = ((temp.LoadTime - temp.Nop2) / temp.LoadTime) * 100;
                        temp.BKR = Math.Round(bkr, 2);


                        tempList.Add(temp);

                      




                    }

                    MainPanel.Controls.Add(Duration);


                    g.RowDataBound += g_RowDataBound;
                    g.DataSource = tempList;
                    g.DataBind();

                    MainPanel.Controls.Add(g);

                    foreach (ShiftHistory s in cumulativeList)
                    {
                        if (Project != "")
                        {
                            if (s.Project != Project)
                                continue;
                        }
                        //temp.CycleTime += s.CycleTime;
                        cumulative.Actual += s.Actual;
                        cumulative.KR += s.CycleTime * s.Actual;
                        cumulative.Scraps += s.Scraps;
                        cumulative.LoadTime += s.LoadTime;
                        cumulative.Nop1 += s.Nop1;
                        cumulative.Nop2 += s.Nop2;
                        cumulative.Idle += s.Idle;
                        cumulative.Undefined += s.Undefined;
                    }

                    
                  
                    cumulative.KR = (cumulative.KR / cumulative.LoadTime) * 100;

                    cumulative.KR = Math.Round(cumulative.KR, 2);

                    cumulative.BKR = ((cumulative.LoadTime - cumulative.Nop2) / cumulative.LoadTime) * 100;
                    cumulative.BKR = Math.Round(cumulative.BKR, 2);






                    cumulativeList.Clear();
                    cumulativeList.Add(cumulative);





                    #region GRID_COLUMNS

                    GridView g1 = new GridView();
                    g1.Style.Add(HtmlTextWriterStyle.Width, "100%");
                    g1.HorizontalAlign = HorizontalAlign.Center;
                    BoundField b1;

                    b1 = new BoundField();
                    b1.DataField = "Date";
                    b1.HeaderText = "Date";
                    g1.Columns.Add(b1);

                    b1 = new BoundField();
                    b1.DataField = "Actual";
                    b1.HeaderText = "Actual Pieces";
                    g1.Columns.Add(b1);

                    b1 = new BoundField();
                    b1.DataField = "Scraps";
                    b1.HeaderText = "Scraps";
                    g1.Columns.Add(b1);

                    b1 = new BoundField();
                    b1.DataField = "LoadTime";
                    b1.HeaderText = "Load Time/ Available Time [s]";
                    g1.Columns.Add(b1);


                    b1 = new BoundField();
                    b1.DataField = "Nop1";
                    b1.HeaderText = "Non-Operation Time 1 / Machine Related [s] ";
                    g1.Columns.Add(b1);

                    b1 = new BoundField();
                    b1.DataField = "Nop2";
                    b1.HeaderText = "Non-Operation Time 2 / Other Than \n Machine Related [s] ";
                    g1.Columns.Add(b1);

                    b1 = new BoundField();
                    b1.DataField = "Undefined";
                    b1.HeaderText = "Undefined [s] ";
                    g1.Columns.Add(b1);

                    b1 = new BoundField();
                    b1.DataField = "Idle";
                    b1.HeaderText = "Idle Time/ Exclude Hour [s] ";
                    g1.Columns.Add(b1);

                    b1 = new BoundField();
                    b1.DataField = "KR";
                    b1.HeaderText = "KADOURITSU/ Operation Ratio [%] ";
                    g1.Columns.Add(b1);

                    b1 = new BoundField();
                    b1.DataField = "BKR";
                    b1.HeaderText = "BEKADOURITSU/ Operational Availability [%] ";
                    g1.Columns.Add(b1);
                    #endregion


                    TextBox Total = new TextBox();
                    Total.TextMode = TextBoxMode.SingleLine;
                    Total.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FF9966");
                    Total.Style.Add("text-align", "center");

                    Total.Style.Add(HtmlTextWriterStyle.FontStyle, "Bold");
                    Total.Width = new Unit("100%");
                    Total.Height = new Unit("30px");
                    Total.Text = "Cumulative";

                    MainPanel.Controls.Add(Total);

                   






                    g1.AutoGenerateColumns = false;

                    g1.RowDataBound += g1_RowDataBound;
                    g1.ShowHeader = false;
                    g1.DataSource = cumulativeList;

                    g1.DataBind();

                    MainPanel.Controls.Add(g1);
                    fromDate = fromDate.AddDays(1);
                }

                
            }

        }

        protected void BackButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }


         void g_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Width = 100;
                e.Row.Cells[1].Width = 100;
                e.Row.Cells[2].Width = 100;
                e.Row.Cells[3].Width = 100;
                e.Row.Cells[4].Width = 100;
                e.Row.Cells[5].Width = 100;
                e.Row.Cells[6].Width = 100;
                e.Row.Cells[7].Width = 100;
                e.Row.Cells[8].Width = 100;
                e.Row.Cells[9].Width = 100;
                  
            }


        }


        void g1_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Width = 100;
                e.Row.Cells[1].Width = 100;
                e.Row.Cells[2].Width = 100;
                e.Row.Cells[3].Width = 100;
                e.Row.Cells[4].Width = 100;
                e.Row.Cells[5].Width = 100;
                e.Row.Cells[6].Width = 100;
                e.Row.Cells[7].Width = 100;
                e.Row.Cells[8].Width = 100;
                e.Row.Cells[9].Width = 100;
               
                


            }


        }

    }
}