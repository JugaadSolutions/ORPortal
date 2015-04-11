using ManufactureMonitor.DALayer;
using ManufactureMonitor.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace ManufactureMonitor
{
    public partial class PAGraph : System.Web.UI.Page
    {
        static DataTable dt, dt1;
        Dictionary<int, List<TimeSequence>> ProblemAccumulation;
        Chart Chart1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ((Label)Master.FindControl("MasterPageLabel")).Text = "OR  " + Session["MachineName"];
                DataAccess da = new DataAccess();
                int machine = Convert.ToInt32(Request.QueryString["MachineId"]);

                DateTime f,fromDate = DateTime.Parse(Request.QueryString["datefrom"]);
                DateTime tod, toDate = DateTime.Parse(Request.QueryString["dateto"]);
                f = fromDate; tod = toDate;
                toDate = toDate.AddDays(1);
                int ShiftId = Convert.ToInt32(Request.QueryString["ShiftId"]);
                String ShiftName = Request.QueryString["ShiftName"];

                List<ProblemAccumulationRecord> PARList = new List<ProblemAccumulationRecord>();
                ProblemAccumulation = new Dictionary<int, List<TimeSequence>>();

                ShiftCollection shifts = da.getShifts(machine);
                while (fromDate < toDate)
                {
                    dt = da.GetShiftTimings(machine, ShiftId);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        
                        DateTime from = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["Start"]);
                        DateTime to = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["End"]);

                        Shift shift = shifts.getShift(from, to);
                        shift.Breaks = da.getBreaks(shift.ID, machine);
                        shift.Sessions = da.getSessions(shift.ID, machine);

                        List<TimeSequence> ts =
                            da.GetStopDetails(machine, shift, from.ToString("yyyy-MM-dd HH:mm:ss"),
                            to.ToString("yyyy-MM-dd HH:mm:ss"), from.ToString("dd-MM-yyyy"),
                            true);

                        foreach (TimeSequence t in ts)
                        {
                            if (ProblemAccumulation.ContainsKey(t.ProblemCode))
                            {
                                ProblemAccumulation[t.ProblemCode].Add(t);
                            }
                            else
                            {
                                ProblemAccumulation.Add(t.ProblemCode, new List<TimeSequence>());
                                ProblemAccumulation[t.ProblemCode].Add(t);
                            }
                        }




                        

                      


                    }
                    fromDate = fromDate.AddDays(1);
                }

                foreach (KeyValuePair<int, List<TimeSequence>> kv in ProblemAccumulation)
                {
                    double problemDuration = 0;

                    foreach (TimeSequence tsq in kv.Value)
                    {
                        problemDuration += tsq.GetDuration();
                    }

                    ProblemAccumulationRecord par = new ProblemAccumulationRecord();
                    par.TimeDuration = problemDuration;
                    par.ProblemCode = kv.Value[0].ProblemCode;
                    par.ProblemDescription = kv.Value[0].Problem;
                    par.Count = kv.Value.Count;

                    PARList.Add(par);
                }

                  double TotalDuration = 0;
                    foreach (ProblemAccumulationRecord p in PARList)
                    {
                        TotalDuration += p.TimeDuration;
                    }

                    foreach (ProblemAccumulationRecord p in PARList)
                    {
                        p.TimePercentage = (p.TimeDuration / TotalDuration) ;
                    }


                Chart1 = new Chart();
                Chart1.ImageLocation = @"~/Images/OROAGraph";
                Chart1.ImageStorageMode = ImageStorageMode.UseImageLocation;
                Chart1.ImageType = ChartImageType.Png;
                Chart1.Width = 1000;
                Chart1.Height = 500;
                ChartArea area = new ChartArea("MainArea");
                Series series = new Series("Series1");


                series.ChartType = SeriesChartType.Pie;

                series.ChartArea = "MainArea";
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "0.00%";
                Random r = new Random(1);
                foreach (ProblemAccumulationRecord p in PARList)
                {
                   // DataPoint pt = new DataPoint(p.ProblemDescription,p.TimePercentage);

                    


                    series.Points.AddXY(p.ProblemDescription + " -- " + Math.Round((p.TimePercentage)*100,2).ToString()+"%" , p.TimePercentage);
                }

                Chart1.ChartAreas.Add(area);
                Chart1.Series.Add(series);

                Chart1.Series["Series1"]["PointWidth"] = "0.1";
                Chart1.ChartAreas["MainArea"].Area3DStyle.Enable3D = true;
                Chart1.Series["Series1"]["PieLabelStyle"] = "Outside";
                Chart1.Series["Series1"].Points[0]["Exploded"] = "true";
               
                Chart1.Legends.Add(new Legend("Default") { Docking = Docking.Right });
                Chart1.Legends[0].Enabled = true;

                Chart1.Titles.Add("Problem Accumulation"
                    + Environment.NewLine + f.ToString("dd-MM-yyyy") + " - " 
                    + tod.ToString("dd-MM-yyyy") + Environment.NewLine + ShiftName);

                PieChartPlaceHolder.Controls.Add(Chart1);
            }

        }
    }
}