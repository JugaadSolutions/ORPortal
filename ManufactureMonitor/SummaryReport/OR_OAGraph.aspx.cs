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
    public partial class OR_OAGraph : System.Web.UI.Page
    {
        //static DataTable dt;
        Chart Chart1;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR  " + Session["MachineName"];
            if (!Page.IsPostBack)
            {
                String ShiftName = Request.QueryString["ShiftName"];
                Chart1 = new Chart();
                Chart1.ImageLocation = @"~/Charts";
                Chart1.ImageStorageMode = ImageStorageMode.UseImageLocation;
                Chart1.ImageType = ChartImageType.Png;
                Chart1.Width = 800;
                Chart1.Height = 500;
                ChartArea area = new ChartArea("MainArea");
                Series series = new Series("Series1");
               
                series.ChartType = SeriesChartType.Line;
                
                series.ChartArea = "MainArea";
                series.IsValueShownAsLabel = true;

                Series series2 = new Series("Series2");
                series2.ChartType = SeriesChartType.Line;
                series2.ChartArea = "MainArea";
                //Series series3 = new Series("Series3");
                //series3.ChartType = SeriesChartType.Point;
                //series3.ChartArea = "MainArea";

                //Series series4 = new Series("Series4");
                //series4.ChartType = SeriesChartType.Point;
                //series4.ChartArea = "MainArea";
                String From = Request.QueryString["datefrom"];
                String To = Request.QueryString["dateto"];
                DateTime from = Convert.ToDateTime(Request.QueryString["datefrom"]);
                DateTime to = Convert.ToDateTime(Request.QueryString["dateto"]);

                int per = 0;
                DateTime day = from;
                

                for (; day <= to; day = day.AddDays(1))
                {
                    series.Points.AddXY(day.ToString("yyyy-MMM-dd"), 100);       
                    series2.Points.AddXY(day.ToString("yyyy-MMM-dd"), 90);
                    //series3.Points.AddXY(day.ToString("yyyy-MMM-dd"), 100);
                }


                Chart1.ChartAreas.Add(area);
                Chart1.Series.Add(series);
                Chart1.Series.Add(series2);
                Chart1.ChartAreas["MainArea"].AxisY.LineColor = System.Drawing.Color.Red;

                Chart1.ChartAreas["MainArea"].AxisX.Interval = 1;
                
                Chart1.ChartAreas["MainArea"].AxisX.Title = "Date";
                Chart1.ChartAreas["MainArea"].AxisX.IsLabelAutoFit = true;

                Chart1.ChartAreas["MainArea"].AxisY.Interval = 10;

                Chart1.ChartAreas["MainArea"].AxisY.Title = "Percentage";
                Chart1.ChartAreas["MainArea"].AxisX.LabelStyle.Angle = -45;
    
                Chart1.ChartAreas["MainArea"].AxisX.MajorGrid.Enabled = false;
                Chart1.ChartAreas["MainArea"].AxisY.MajorGrid.Enabled = false;
                


                Chart1.Titles.Add("OR & OA Graph"+ " "+ From+" - "+To+" "+ ShiftName);
                
             

                ReportDataPlaceHolder.Controls.Add(Chart1);
            }
        }
    }
}