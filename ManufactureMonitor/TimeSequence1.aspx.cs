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
    public partial class TimeSequence1 : System.Web.UI.Page
    {
        static DataTable dt,dt1;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
                dt = da.GetMachines(Convert.ToInt32(Request.QueryString["MachineGroupId"]));
                MachineSelectionListBox.DataSource = dt.DefaultView;
                MachineSelectionListBox.DataValueField = "Machines";
                MachineSelectionListBox.DataBind();
               

            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Calendar2.SelectedDate < Calendar1.SelectedDate)
            {
                Response.Write("<script>alert('Invalid Date...');</script>");
            }
            else
            {
                String datefrom = Calendar1.SelectedDate.ToShortDateString();
                String dateto = Calendar2.SelectedDate.ToShortDateString();

                Response.Redirect("~/TimeSequence1_Show.aspx?MachineGroupId=" + Request.QueryString["MachineGroupId"]
                    + "&MachineId=" + dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]
                     + "&ShiftId=" + dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"] + "&datefrom=" + datefrom + "&dateto=" + dateto
                     +"&SpeedLoss="+CheckBoxList1.Items[0].Selected);
            }
        }

        protected void MachineSelectionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataAccess da = new DataAccess(); 
            if (MachineSelectionListBox.SelectedIndex == -1)
                return;
            dt1 = da.GetShiftTimings(Convert.ToInt32(dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]));
            ShiftSelectionListBox.DataSource = dt1.DefaultView;
            ShiftSelectionListBox.DataValueField = "shifts";
            ShiftSelectionListBox.DataBind();
        }
    }
}