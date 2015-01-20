using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace ManufactureMonitor.MachineOff
{
    public partial class CancelMachineOff : System.Web.UI.Page
    {
        Chart Chart2;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR  " + Session["MachineName"];
            
            /*Graph of  Stacked column*/
            
        }

       

       
    }
}