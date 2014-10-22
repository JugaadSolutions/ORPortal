using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManufactureMonitor
{
    public partial class OR_OAGraph : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Chart1.Series["OR"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
            Chart1.Series["OA"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
        }
    }
}