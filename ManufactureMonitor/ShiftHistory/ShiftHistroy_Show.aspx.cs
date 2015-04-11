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
    public partial class ShiftHistroy_Show : System.Web.UI.Page
    {
        DataTable dt;
        static bool summary;
        
        List<ShiftHistory> tempList;

        DataAnalyzer DZ;


        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR  " + Session["MachineName"];
            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
             

                int machineId = Convert.ToInt32(Request.QueryString["MachineId"]);

                DateTime fromDate = DateTime.Parse(Request.QueryString["from"]);
                DateTime toDate = DateTime.Parse(Request.QueryString["to"]);
                toDate = toDate.AddDays(1);
                int ShiftId = Convert.ToInt32(Request.QueryString["ShiftId"]);
                String ShiftName = Request.QueryString["ShiftName"];
                summary = Convert.ToBoolean(Request.QueryString["Summary"]);
                MainPanel.Width = new Unit("100%");

                DZ = new DataAnalyzer(machineId);

                ShiftCollection Shifts = da.getShifts(machineId);
                foreach (Shift shift in Shifts)
                {
                    shift.Breaks = da.GetBreaks(shift.ID, machineId);
                    shift.Sessions = da.getSessions(shift.ID, machineId);
                }


                while (fromDate < toDate)
                {
                    dt = da.GetShiftTimings(machineId, ShiftId);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox Duration = new TextBox();
                        Duration.TextMode = TextBoxMode.SingleLine;
                        Duration.BackColor = Color.LightGray;
                        Duration.Style.Add("text-align", "center");
                        Duration.Style.Add("margin", "10px");
                        Duration.Width = new Unit("60%");
                        Duration.Height = new Unit("30px");

                        DateTime from = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["Start"]);
                        DateTime to = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["End"]);
                        if (to < from)
                            to = to.AddDays(1);

                        Shift Shift = Shifts.getShift(from, to);
                        Shift.StartTime = from.ToString("yyyy-MM-dd HH:mm:ss");
                        Shift.EndTime = to.ToString("yyyy-MM-dd HH:mm:ss");
                        Shift.Date = from;
 
                        Duration.Text = fromDate.ToString("dd-MMM-yy") + ":" + (dt.Rows[i]["shifts"]).ToString();
                        if (!summary)
                        {
                            DZ.CalculateShiftHistory(Shift);

                            //Sh = da.GetShiftHistory(machineId, from.ToString("yyyy-MM-dd HH:mm"),
                            //    to.ToString("yyyy-MM-dd HH:mm:ss"),from.ToString("dd-MM-yyyy")
                            //    );
                        }
                        else
                        {
                            DZ.CalculateShiftHistorySummary(Shift);

                            //shSummary =  da.GetShiftHistory_Summary(machineId, from.ToString("yyyy-MM-dd HH:mm"),
                            //    to.ToString("yyyy-MM-dd HH:mm:ss"), from.ToString("dd-MM-yyyy")
                            //    );
                        }

                        #region GRID_COLUMNS
                        GridView g = new GridView();
                       
                        g.AutoGenerateColumns = false;
                        g.HeaderStyle.BackColor = Color.OrangeRed;
                        

                        BoundField b;

                        b = new BoundField();
                        b.DataField = "Date";
                        b.HeaderText = "Date";
                        g.Columns.Add(b);

                        if (!summary)
                        {

                            b = new BoundField();
                            b.DataField = "From";
                            b.HeaderText = "From";
                            g.Columns.Add(b);

                            b = new BoundField();
                            b.DataField = "To";
                            b.HeaderText = "To";
                            g.Columns.Add(b);
                        }


                        b = new BoundField();
                        b.DataField = "Project";
                        b.HeaderText = "Project/ Model";
                        g.Columns.Add(b);

                        b = new BoundField();
                        b.DataField = "CycleTime";
                        b.HeaderText = "Plan Cycle Time[s]";
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
                        b.HeaderText = "Non-Operation Time 1 / Other Than Machine Related [s]";
                        g.Columns.Add(b);

                        b = new BoundField();
                        b.DataField = "Nop2";
                        b.HeaderText = "Non-Operation Time 2 / Machine Related [s]  ";
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

                        g.HorizontalAlign = HorizontalAlign.Center;
                        g.Style.Add(HtmlTextWriterStyle.Width, "100%");
                        #endregion

                        if (!summary)
                        {
                            //g.DataSource = Sh;
                            g.DataSource = DZ.ShiftHistoryList;
                        }
                        else
                        {
                            //g.DataSource = shSummary;
                            g.DataSource = DZ.ShSummary;
                        }

                        g.RowDataBound += g_RowDataBound;
                        g.DataBind();
                    
                        MainPanel.Controls.Add(Duration);
                        MainPanel.Controls.Add(g);

                        if (g.Rows.Count > 0)
                        {

                            TextBox Total = new TextBox();
                            Total.TextMode = TextBoxMode.SingleLine;
                            Total.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FF9966");
                            Total.Style.Add("text-align", "center");

                            Total.Style.Add(HtmlTextWriterStyle.FontStyle, "Bold");
                            Total.Width = new Unit("100%");
                            Total.Height = new Unit("30px");
                            Total.Text = "Shift Total";

                            MainPanel.Controls.Add(Total);

                            #region TOTAL_GRID_COLUMNS

                            GridView g1 = new GridView();
                       

                            BoundField b1;

                            b1 = new BoundField();
                            b1.DataField = "Date";
                            b1.HeaderText = "Date";
                            g1.Columns.Add(b1);

                            if (!summary)
                            {

                                b1 = new BoundField();
                                b1.DataField = "From";
                                b1.HeaderText = "From";
                                g1.Columns.Add(b1);

                                b1 = new BoundField();
                                b1.DataField = "To";
                                b1.HeaderText = "To";
                                g1.Columns.Add(b1);
                            }


                            b1 = new BoundField();
                            b1.DataField = "Project";
                            b1.HeaderText = "Project/ Model";
                            g1.Columns.Add(b1);

                            b1 = new BoundField();
                            b1.DataField = "CycleTime";
                            b1.HeaderText = "Plan Cycle Time[s]";
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
                            b1.HeaderText = "Non-Operation Time 1 /  Other Than Machine Related [s] ";
                            g1.Columns.Add(b1);

                            b1 = new BoundField();
                            b1.DataField = "Nop2";
                            b1.HeaderText = "Non-Operation Time 2 / Machine Related [s]";
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


                            if (!summary)
                            {
                                tempList = new List<ShiftHistory>();
                                ShiftHistory temp = new ShiftHistory();
                                foreach (ShiftHistory sh in DZ.ShiftHistoryList)
                                {
                                    
                                    temp.Actual += sh.Actual;
                                    temp.Scraps += sh.Scraps;
                                    temp.LoadTime += sh.LoadTime;
                                    temp.Nop1 += sh.Nop1;
                                    temp.Nop2 += sh.Nop2;
                                    temp.Idle += sh.Idle;
                                    temp.Undefined += sh.Undefined;
                                    temp.KR += ((sh.Actual * sh.CycleTime));
                                    
                                }

                                temp.KR = Math.Round((temp.KR / temp.LoadTime) * 100, 2);
                                temp.BKR = Math.Round(((temp.LoadTime - temp.Nop2) / temp.LoadTime) * 100, 2);
                                tempList.Add(temp);

                                

                                g1.Style.Add(HtmlTextWriterStyle.Width, "100%");
                                g1.HorizontalAlign = HorizontalAlign.Center;
                                
                                g1.AutoGenerateColumns = false;

                                g1.RowDataBound += g1_RowDataBound;
                                g1.ShowHeader = false;
                                g1.DataSource = tempList;

                                g1.DataBind();

                                MainPanel.Controls.Add(g1);

                            }
                            else
                            {
                                ShiftHistory_Summary sTemp = new ShiftHistory_Summary();
                                List<ShiftHistory_Summary> sList = new List<ShiftHistory_Summary>();

                                

                                foreach (ShiftHistory sh in DZ.ShiftHistoryList)
                                {

                                    sTemp.Actual += sh.Actual;
                                    sTemp.Scraps += sh.Scraps;
                                    sTemp.LoadTime += sh.LoadTime;
                                    sTemp.Nop1 += sh.Nop1;
                                    sTemp.Nop2 += sh.Nop2;
                                    sTemp.Idle += sh.Idle;
                                    sTemp.Undefined += sh.Undefined;
                                    sTemp.KR += ((sh.Actual * sh.CycleTime));

                                }

                                sTemp.KR = Math.Round((sTemp.KR / sTemp.LoadTime) * 100, 2);
                                sTemp.BKR = Math.Round(((sTemp.LoadTime - sTemp.Nop2) / sTemp.LoadTime) * 100, 2);
                                sList.Add(sTemp);

                               

                                

                                g1.Style.Add(HtmlTextWriterStyle.Width, "100%");
                                g1.HorizontalAlign = HorizontalAlign.Center;
                                g1.AutoGenerateColumns = false;

                                g1.RowDataBound += g1_RowDataBound;
                                g1.ShowHeader = false;
                                g1.DataSource = sList;

                                g1.DataBind();

                                MainPanel.Controls.Add(g1);

                               
                                
                            }
                        }

                    }
                    fromDate = fromDate.AddDays(1);
                }
            }


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
                e.Row.Cells[10].Width = 100;
                if (!summary)
                {
                    e.Row.Cells[11].Width = 100;
                    e.Row.Cells[12].Width = 100;
                    e.Row.Cells[13].Width = 100;
                }



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
                e.Row.Cells[10].Width = 100;

                if (!summary)
                {
                    e.Row.Cells[11].Width = 100;
                    e.Row.Cells[12].Width = 100;
                    e.Row.Cells[13].Width = 100;
                    
                }
               


            }


        }

        //void g1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.Header)
        //    {
               
        //        for (int j = 0; j < tempList.Count; j++)
        //        {
        //            e.Row.Cells[j].Width = 100;
        //        }

        //    }
        //}

        protected void BackButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup="+Request.QueryString["MachineGroupId"]);
        }
        
    }
}