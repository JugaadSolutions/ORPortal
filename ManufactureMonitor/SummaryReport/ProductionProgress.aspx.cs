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
            int ShiftId = Convert.ToInt32(Request.QueryString["ShiftId"]);
            String ShiftName = Request.QueryString["ShiftName"];
            List<String> ProjectName = new List<String>();
            
            String Date = fromDate.ToString("yyyy-MM-dd");
            dt2 = da.GetModels(machineId);

            List<Series> seriesList = new List<Series>();

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                Series series = new Series((string)dt2.Rows[i]["Name"]);
                series.ChartType = SeriesChartType.StackedColumn;
                series.ChartArea = "MainArea";
                
                series.IsValueShownAsLabel = true;
                seriesList.Add(series);
            }

            while (fromDate <= toDate)
            {
               
                dt = da.GetShiftTimings(machineId, ShiftId);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DateTime from = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["Start"]);
                    DateTime to = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["End"]);

                    if (to < from)
                        to = to.AddDays(1);

                   
                   
                   for (int k = 0; k < dt2.Rows.Count; k++)
                   {
                       int Project = (int)dt2.Rows[k]["ID"];
                       String Name = (string)dt2.Rows[k]["Name"];
                       int ok = da.GetOK(machineId, ShiftId, Project, from, to);
                       seriesList[k].Points.AddXY(from.ToString("dd-MM-yyyy"), ok);
                       ProjectName.Add(Name);
                       
                   }
                   
                }
                
                fromDate = fromDate.AddDays(1);
                   
            }

            Chart1 = new Chart();
            Chart1.ImageLocation = @"~/Charts/ProdProgress";
            Chart1.ImageStorageMode = ImageStorageMode.UseImageLocation;
            Chart1.ImageType = ChartImageType.Png;
            Chart1.Width = 500;
            Chart1.Height = 500;

            String From = Request.QueryString["datefrom"];
            String To = Request.QueryString["dateto"];

            ChartArea area = new ChartArea("MainArea");
            

          

            
            Chart1.ChartAreas.Add(area);

            foreach( Series s in seriesList )
                Chart1.Series.Add(s);

            Chart1.ChartAreas["MainArea"].AxisX.Interval = 1;

            Chart1.ChartAreas["MainArea"].AxisX.Title = "Date";
            Chart1.ChartAreas["MainArea"].AxisX.IsLabelAutoFit = true;

            Chart1.ChartAreas["MainArea"].AxisY.Interval = 10;

            Chart1.ChartAreas["MainArea"].AxisY.Title = "Production Count";

            Chart1.ChartAreas["MainArea"].AxisX.LabelStyle.Angle = -45;

            Chart1.ChartAreas["MainArea"].AxisX.MajorGrid.Enabled = false;
            Chart1.ChartAreas["MainArea"].AxisY.MajorGrid.Enabled = true;
            Chart1.Legends.Add(new Legend("ProjectName") { Docking = Docking.Right });
            Chart1.Titles.Add("Production Progress Chart" + Environment.NewLine + From + " - " + To + Environment.NewLine + ShiftName);
            
            ReportDataPlaceHolder.Controls.Add(Chart1);
            
        }
    }
}
