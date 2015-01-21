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

namespace ManufactureMonitor
{
    public partial class LossHourGraph : System.Web.UI.Page
    {
        static DataTable dt, dt1;
        Dictionary<int, List<TimeSequence>> ProblemAccumulation;
        Chart Chart1,Chart2;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR  " + Session["MachineName"];
            DataAccess da = new DataAccess();
            int machine = Convert.ToInt32(Request.QueryString["MachineId"]);

            DateTime fromDate = DateTime.Parse(Request.QueryString["datefrom"]);
            DateTime toDate = DateTime.Parse(Request.QueryString["dateto"]);
            //toDate = toDate.AddDays(1);
            int ShiftId = Convert.ToInt32(Request.QueryString["ShiftId"]);
            String ShiftName = Request.QueryString["ShiftName"];
            ProblemAccumulation = new Dictionary<int, List<TimeSequence>>();
            while (fromDate <= toDate)
            {
                dt = da.GetShiftTimings(machine, ShiftId);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DateTime from = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["Start"]);
                    DateTime to = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["End"]);

                    List<TimeSequence> ts =
                        da.GetStopDetails(machine, ShiftId, from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"), true);

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

            List<ProblemAccumulationRecord> PARList = new List<ProblemAccumulationRecord>();

            foreach (KeyValuePair<int, List<TimeSequence>> kv in ProblemAccumulation)
            {
                double problemDuration = 0;

                foreach (TimeSequence ts in kv.Value)
                {
                    problemDuration += ts.GetDuration();
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
                p.TimePercentage = Math.Round((p.TimeDuration / TotalDuration) * 100, 2);
            }

            /*Graph of Detail Column Chart*/

            Chart1 = new Chart();
            Chart1.ImageLocation = @"~/Charts";
            Chart1.ImageStorageMode = ImageStorageMode.UseImageLocation;
            Chart1.ImageType = ChartImageType.Png;
            Chart1.Width = 1000;
            Chart1.Height = 500;
            
            String From = Request.QueryString["datefrom"];
            String To = Request.QueryString["dateto"];

            ChartArea area = new ChartArea("MainArea");
            Series series = new Series("Series1");

            series.ChartType = SeriesChartType.Column;
            series.ChartArea = "MainArea";
            series.IsValueShownAsLabel = true;
            foreach (ProblemAccumulationRecord par in PARList)
            {
                series.Points.AddXY(par.ProblemDescription,par.TimeDuration);
            }

            
            Chart1.ChartAreas.Add(area);
            Chart1.Series.Add(series);
            Chart1.ChartAreas["MainArea"].AxisX.Interval = 1;

            Chart1.ChartAreas["MainArea"].AxisX.Title = "Problems";
            Chart1.ChartAreas["MainArea"].AxisX.IsLabelAutoFit = true;

            Chart1.ChartAreas["MainArea"].AxisY.Interval = 1000;

            Chart1.ChartAreas["MainArea"].AxisY.Title = "Time in Sec";

            Chart1.ChartAreas["MainArea"].AxisX.LabelStyle.Angle = -45;

            Chart1.ChartAreas["MainArea"].AxisX.MajorGrid.Enabled = false;
            Chart1.ChartAreas["MainArea"].AxisY.MajorGrid.Enabled = false;

            Chart1.Titles.Add("Loss Time" + Environment.NewLine + From + " - " + To + Environment.NewLine + ShiftName);

            ReportDataPlaceHolder.Controls.Add(Chart1);
            
            
            
            /*Graph of  Stacked column*/
            
            Chart2 = new Chart();
            Chart2.ImageLocation = @"~/Charts_1";
            Chart2.ImageStorageMode = ImageStorageMode.UseImageLocation;
            Chart2.ImageType = ChartImageType.Png;
            Chart2.Width = 500;
            Chart2.Height = 500;

            ChartArea area1 = new ChartArea("MainArea1");
            Series series1 = new Series("Series2");

            series1.ChartType = SeriesChartType.StackedColumn;
            series1.ChartArea = "MainArea1";
            series1.IsValueShownAsLabel = true;
            DateTime day = DateTime.Parse(Request.QueryString["datefrom"]);

            series1.Points.AddXY("", 100);
          

            Chart2.ChartAreas.Add(area1);
            Chart2.Series.Add(series1);
            Chart2.ChartAreas["MainArea1"].AxisX.Interval = 1;

            Chart2.ChartAreas["MainArea1"].AxisX.Title = "CHE Front old line";
            Chart2.ChartAreas["MainArea1"].AxisX.IsLabelAutoFit = true;

            Chart2.ChartAreas["MainArea1"].AxisY.Interval = 10;

            Chart2.ChartAreas["MainArea1"].AxisY.Title = " ";

            Chart2.ChartAreas["MainArea1"].AxisX.LabelStyle.Angle = -45;

            Chart2.ChartAreas["MainArea1"].AxisX.MajorGrid.Enabled = false;
            Chart2.ChartAreas["MainArea1"].AxisY.MajorGrid.Enabled = false;
            StackedDataPlaceHolder.Controls.Add(Chart2);
            
           
        }
        
    }
}