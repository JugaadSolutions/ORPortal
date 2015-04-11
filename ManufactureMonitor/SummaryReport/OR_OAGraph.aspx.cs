using ManufactureMonitor.DALayer;
using ManufactureMonitor.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization;

namespace ManufactureMonitor
{
    public partial class OR_OAGraph : System.Web.UI.Page
    {
        //static DataTable dt;
        Chart Chart1;
        static String Project = "";
        static DataTable dt;
        DataAnalyzer DZ;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR  " + Session["MachineName"];
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

                List<ShiftHistory> tempList = new List<ShiftHistory>();

                 DZ = new DataAnalyzer(machineId);

                ShiftCollection Shifts = da.getShifts(machineId);
                foreach (Shift shift in Shifts)
                {
                    shift.Breaks = da.GetBreaks(shift.ID, machineId);
                    shift.Sessions = da.getSessions(shift.ID, machineId);
                }

                while (fromDate <= toDate)
                {
                    ShiftHistory temp = new ShiftHistory();
                    dt = da.GetShiftTimings(machineId, ShiftId);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {



                        DateTime from = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["Start"]);
                        DateTime to = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["End"]);

                        if (to < from)
                            to = to.AddDays(1);

                        temp.Date = from.ToString("dd-MMM-yyyy");

                         Shift Shift = Shifts.getShift(from, to);
                        Shift.StartTime = from.ToString("yyyy-MM-dd HH:mm:ss");
                        Shift.EndTime = to.ToString("yyyy-MM-dd HH:mm:ss");
                        Shift.Date = from;

                        DZ.CalculateShiftHistory(Shift);

                        foreach (ShiftHistory s in DZ.ShiftHistoryList)
                        {
                            if (Project != "")
                            {
                                if (s.Project != Project)
                                    continue;
                            }
                            //temp.CycleTime += s.CycleTime;
                            temp.Actual += s.Actual;
                            temp.Scraps += s.Scraps;
                            temp.OK += s.Actual - s.Scraps;
                            temp.KR += s.CycleTime * (s.Actual - s.Scraps) ;
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
                    fromDate = fromDate.AddDays(1);

                }
                ShiftHistory cumulative = new ShiftHistory();
                List<ShiftHistory> cumulativeList = new List<ShiftHistory>();

                foreach (ShiftHistory s in tempList)
                {
                    cumulative.CycleTime += s.CycleTime;
                    cumulative.Actual += s.Actual;
                    cumulative.Scraps += s.Scraps;
                    cumulative.LoadTime += s.LoadTime;
                    cumulative.Nop1 += s.Nop1;
                    cumulative.Nop2 += s.Nop2;
                    cumulative.Idle += s.Idle;
                    cumulative.Undefined += s.Undefined;
                    cumulative.KR += ((s.Actual * s.CycleTime));
                   
                }
                cumulative.KR = Math.Round(((cumulative.CycleTime * cumulative.Actual) / cumulative.LoadTime) * 100, 2);
                cumulative.BKR = Math.Round(((cumulative.LoadTime - cumulative.Nop2) / cumulative.LoadTime) * 100, 2);
                cumulativeList.Add(cumulative);
               
                Chart1 = new Chart();
                Chart1.ImageLocation = @"~/Images/OROAGraph";
                Chart1.ImageStorageMode = ImageStorageMode.UseImageLocation;
                Chart1.ImageType = ChartImageType.Png;
                Chart1.Width = 1000;
                Chart1.Height = 500;
                ChartArea area = new ChartArea("MainArea");
                Series series = new Series("Series1");
               
                series.ChartType = SeriesChartType.Line;
                
                series.ChartArea = "MainArea";
                series.IsValueShownAsLabel = true;
                

                Series series2 = new Series("Series2");
                series2.ChartType = SeriesChartType.Line;
                series2.ChartArea = "MainArea";
                series2.IsValueShownAsLabel = true;
                Series OR = new Series("OR");
                OR.ChartType = SeriesChartType.Line;
                OR.ChartArea = "MainArea";
                OR.IsValueShownAsLabel = true;

                Series OA = new Series("OA");
                OA.ChartType = SeriesChartType.Line;
                OA.ChartArea = "MainArea";
                OA.IsValueShownAsLabel = true;

                String From = Request.QueryString["datefrom"];
                String To = Request.QueryString["dateto"];
                series2.BorderDashStyle = ChartDashStyle.Dash;
                series.BorderDashStyle = ChartDashStyle.Dash;
                series.BorderWidth = 3;
                series2.BorderWidth = 3;
                
                //int per = 0;
                DateTime day = DateTime.Parse(Request.QueryString["datefrom"]);
                

                for (int i=0;  day <= toDate; day = day.AddDays(1),i++)
                {
                    series.Points.AddXY(day.ToString("yyyy-MMM-dd"), 100);       
                    series2.Points.AddXY(day.ToString("yyyy-MMM-dd"), 90);
                    
                        OR.Points.AddXY(day.ToString("yyyy-MMM-dd"), tempList[i].KR);
                        OA.Points.AddXY(day.ToString("yyyy-MMM-dd"), tempList[i].BKR);
                    
                }


                Chart1.ChartAreas.Add(area);
                Chart1.Series.Add(series);
                Chart1.Series.Add(series2);
                Chart1.Series.Add(OR);
                Chart1.Series.Add(OA);
                Chart1.ChartAreas["MainArea"].AxisY.LineColor = System.Drawing.Color.Red;

                Chart1.ChartAreas["MainArea"].AxisX.Interval = 1;
                
                Chart1.ChartAreas["MainArea"].AxisX.Title = "Date";
                Chart1.ChartAreas["MainArea"].AxisX.IsLabelAutoFit = true;

                Chart1.ChartAreas["MainArea"].AxisY.Interval = 10;

                Chart1.ChartAreas["MainArea"].AxisY.Title = "Percentage";
                Chart1.ChartAreas["MainArea"].AxisX.LabelStyle.Angle = -45;
    
                Chart1.ChartAreas["MainArea"].AxisX.MajorGrid.Enabled = false;
                Chart1.ChartAreas["MainArea"].AxisY.MajorGrid.Enabled = false;
                


                Chart1.Titles.Add("OR & OA Graph"+Environment.NewLine+ From+" - "+To+Environment.NewLine+ ShiftName);
                
             

                ReportDataPlaceHolder.Controls.Add(Chart1);
            }
        }
    }
}