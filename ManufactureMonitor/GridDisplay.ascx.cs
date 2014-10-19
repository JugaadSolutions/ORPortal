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
    public partial class GridDisplay : System.Web.UI.UserControl
    {
        static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "DENSO";

            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();

                DataTable dt = da.DisplaySpecificProblems(Convert.ToInt32(Request.QueryString["MachineId"]));
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}