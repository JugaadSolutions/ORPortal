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
    public partial class Scrap1 : System.Web.UI.Page
    {
        static DataTable dt, dt1,dt2;
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
            Response.Redirect("../Menu.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int shift =  ShiftSelectionListBox.SelectedIndex == -1 ? 0 : (int)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"];
            

            Response.Redirect("~/Scraps/Scrap_entry.aspx?MachineId=" + (int)dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]
                 + "&ShiftId=" + shift +"&From=" +Calendar1.SelectedDate.ToString("dd-MMM-yyyy")
                 + "&To=" + Calendar2.SelectedDate.ToString("dd-MMM-yyyy"));
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            int shift = ShiftSelectionListBox.SelectedIndex == -1 ? 0 : (int)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"];
            

            Response.Redirect("~/Scraps/Scrap_show.aspx?MachineId=" + (int)dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]
                 + "&ShiftId=" + shift + "&From=" + Calendar1.SelectedDate.ToString("dd-MMM-yyyy")
                 + "&To=" + Calendar2.SelectedDate.ToString("dd-MMM-yyyy"));
        }

    }
}