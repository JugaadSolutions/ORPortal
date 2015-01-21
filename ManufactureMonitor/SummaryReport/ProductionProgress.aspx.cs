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

namespace ManufactureMonitor.SummaryReport
{
    public partial class ProductionProgress : System.Web.UI.Page
    {
        Chart Chart1;
        static int Project;
        static DataTable dt, dt1,dt2;
        static List<ShiftHistory> sh;
        List<double> OK;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR  " + Session["MachineName"];
            DataAccess da = new DataAccess();
            int machineId = Convert.ToInt32(Request.QueryString["MachineId"]);

            DateTime fromDate = DateTime.Parse(Request.QueryString["datefrom"]);
            DateTime toDate = DateTime.Parse(Request.QueryString["dateto"]);
            //toDate = toDate.AddDays(1);
            int ShiftId = Convert.ToInt32(Request.QueryString["ShiftId"]);
            String ShiftName = Request.QueryString["ShiftName"];
            Project = Convert.ToInt32(Request.QueryString["Project"]);

           
            while (fromDate <= toDate)
            {
               
                dt = da.GetShiftTimings(machineId, ShiftId);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DateTime from = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["Start"]);
                    DateTime to = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["End"]);

                    if (to < from)
                        to = to.AddDays(1);

                   List<double> OK= new List<double>();

                    dt2 = da.GetMachine(Project);
                    int machineid = (int)dt2.Rows[0]["Machine_Id"];
                    dt1 = da.GetOK(machineid, ShiftId, Project, from, to);
                    for (int j = 0; j < dt1.Rows.Count; j++)
                    {
                        double ok = (int)dt1.Rows[j]["SessionActual"] - (int)dt1.Rows[j]["Scraps"];
                        OK.Add(ok);
                    }
                
                    

                }
                fromDate = fromDate.AddDays(1);
                   
            }

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

            series.ChartType = SeriesChartType.StackedColumn;
            series.ChartArea = "MainArea";
            series.IsValueShownAsLabel = true;

            DateTime day = DateTime.Parse(Request.QueryString["datefrom"]);
            for (int i = 0; day <= toDate; day = day.AddDays(1), i++)
            {
               

                series.Points.AddXY(day.ToString("yyyy-MMM-dd"), OK);
            }


            Chart1.ChartAreas.Add(area);
            Chart1.Series.Add(series);
            Chart1.ChartAreas["MainArea"].AxisX.Interval = 1;

            Chart1.ChartAreas["MainArea"].AxisX.Title = "Date";
            Chart1.ChartAreas["MainArea"].AxisX.IsLabelAutoFit = true;

            Chart1.ChartAreas["MainArea"].AxisY.Interval = 50;

            Chart1.ChartAreas["MainArea"].AxisY.Title = "Prod'n C";

            Chart1.ChartAreas["MainArea"].AxisX.LabelStyle.Angle = -45;

            Chart1.ChartAreas["MainArea"].AxisX.MajorGrid.Enabled = false;
            Chart1.ChartAreas["MainArea"].AxisY.MajorGrid.Enabled = false;

            Chart1.Titles.Add("Production Progress Chart" + Environment.NewLine + From + " - " + To + Environment.NewLine + ShiftName);

            ReportDataPlaceHolder.Controls.Add(Chart1);
            
        }
    }
}
