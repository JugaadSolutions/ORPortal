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
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR  " + Session["Machinegroupname"];
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
            if (Calendar1.SelectedDate == DateTime.MinValue || Calendar2.SelectedDate == DateTime.MinValue)
            {
                Response.Write("<script>alert('Please select From and To dates...');</script>");
                return;
            }

            if (Calendar2.SelectedDate < Calendar1.SelectedDate)
            {
                Response.Write("<script>alert('To Date should be greater than From Date.');</script>");
            }
            else
            {
                String datefrom = Calendar1.SelectedDate.ToShortDateString();
                String dateto = Calendar2.SelectedDate.ToShortDateString();
                int ShiftId = -1;
                if (ShiftSelectionListBox.SelectedIndex != -1)
                {
                    ShiftId = (int)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"];
                }
                if (MachineSelectionListBox.SelectedIndex == -1)
                    return;
                Session["MachineName"] = dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"];
                Response.Redirect("~/TimeSequence/TimeSequence1_Show.aspx?MachineId=" 
                    + dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]
                     + "&MachineName=" + dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"]
                     + "&ShiftId=" + ShiftId
                      + "&ShiftName=" + (string)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Name"]
                     + "&datefrom=" + datefrom + "&dateto=" + dateto
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

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}