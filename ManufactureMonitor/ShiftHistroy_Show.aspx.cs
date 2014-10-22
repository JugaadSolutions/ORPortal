using ManufactureMonitor.DALayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManufactureMonitor
{
    public partial class ShiftHistroy_Show : System.Web.UI.Page
    {
        static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataAccess da = new DataAccess();
             int machineId = Convert.ToInt32(Request.QueryString["MachineId"]);
 
            int ShiftId  = Convert.ToInt32( Request.QueryString["ShiftId"]);
           

            dt = da.GetShiftTimings(machineId,ShiftId);


            MachineSelectedLabel.Text = (dt.Rows[0]["shifts"]).ToString();
            


        }

        protected void BackButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup="+Request.QueryString["MachineGroupId"]);
        }
    }
}