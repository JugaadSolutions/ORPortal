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
    public partial class ProblemAccumulation : System.Web.UI.Page
    {
        static DataTable dt,dt1;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
                dt = da.GetMachines(Convert.ToInt32(Session["MachineGroup"]));
                MachineSelectionListBox.DataSource = dt.DefaultView;
                MachineSelectionListBox.DataValueField = "Machines";
                MachineSelectionListBox.DataBind();
               

            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Session["MachineGroup"]);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if( validateSelection() )
            {
                int ShiftId = -1;
                String ShiftName = "All Shifts";
                if (ShiftSelectionListBox.SelectedIndex != -1)
                {
                    ShiftId = (int)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"];
                    ShiftName = (string)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Name"];
                }
                Response.Redirect("~/ProblemAccumulation/ProblemAccumulation_Show.aspx?MachineGroupId=" + Session["MachineGroup"]
                     + "&MachineId=" + (int)dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]
                      + "&MachineName=" + dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"]
                     + "&ShiftId=" + ShiftId
                      + "&ShiftName=" + ShiftName
                       + "&datefrom=" + datefrom.SelectedDate.ToShortDateString()
                      + "&dateto=" + dateto.SelectedDate.ToShortDateString());
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

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {

        }
        bool validateSelection()
        {

            if (datefrom.SelectedDate == DateTime.MinValue || dateto.SelectedDate == DateTime.MinValue)
            {
                Response.Write("<script>alert('Please select From and To dates...');</script>");
                return false;
            }

            if (dateto.SelectedDate < datefrom.SelectedDate)
            {
                Response.Write("<script>alert('To Date should be greater than From Date.');</script>");
                return false;
            }
            return true;
        }
    }
}