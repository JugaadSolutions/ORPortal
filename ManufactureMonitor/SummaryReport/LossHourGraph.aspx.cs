using ManufactureMonitor.DALayer;
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
        Chart ch;
        protected void Page_Load(object sender, EventArgs e)
        {
            //int machineId = Convert.ToInt32(Request.QueryString["MachineId"]);
            //int machineGroup = Convert.ToInt32(Request.QueryString["Id"]);
            // DataAccess da = new DataAccess();
            //dt = da.GetMachines(machineGroup,machineId);

            //double[] yvalues ={75,10,5,10};

            //ch = new Chart();
            //ch.Width = 600;
            //ch.Height = 500;
            //ch.ImageLocation = "~/Charts";
            //ch.ImageStorageMode = ImageStorageMode.UseImageLocation;
            //ch.ImageType = ChartImageType.Png;

            //ChartArea area = new ChartArea("MainArea");
            //Series series = new Series((string)dt.Rows[0]["Name"]);
            
          
            //series.ChartType = SeriesChartType.StackedColumn;
            //series.ChartArea = "MainArea";
            //series.IsValueShownAsLabel = true;


            //System.Web.UI.DataVisualization.Charting.DataPoint dataPoint = new System.Web.UI.DataVisualization.Charting.DataPoint();
            //dataPoint.SetValueXY("First",75);


            //System.Web.UI.DataVisualization.Charting.DataPoint dataPoint1 = new System.Web.UI.DataVisualization.Charting.DataPoint();
            //dataPoint.SetValueXY("Second",15);
            //series.Points.Add(dataPoint);
            //series.Points.Add(dataPoint1);

            //ch.ChartAreas.Add(area);
            //ch.Series.Add(series);
            //ch.ChartAreas["MainArea"].AxisX.Title = "Line Name";
            //ch.ChartAreas["MainArea"].AxisY.Title = "% Loss";
            //ch.ChartAreas["MainArea"].AxisX.IsLabelAutoFit = true;

            //ch.Titles.Add("Loss Hour - " +Environment.NewLine+ dt.Rows[0]["Name"] +"-"+
            //    Request.QueryString["datefrom"] + "-" + Request.QueryString["dateto"]);

            //ChartHolder.Controls.Add(ch);

            ////


            ////System.Web.UI.DataVisualization.Charting.DataPoint dataPoint = new System.Web.UI.DataVisualization.Charting.DataPoint();
            ////dataPoint.AxisLabel = (String)dt.Rows[0]["Name"];

            ////dataPoint.YValues = yvalues;


            //Chart1.Series["LossHour"].Points.Add(dataPoint);
           
        }
    }
}