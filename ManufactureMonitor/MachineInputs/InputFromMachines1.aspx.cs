using ManufactureMonitor.DALayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManufactureMonitor
{
    public partial class InputFromMachines1 : System.Web.UI.Page
    {
        static DataTable dt,dt1,dt2;
        static List<String> inputs;
        
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

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (validateSelection())
            {

                if (MachineSelectionListBox.SelectedIndex == -1)
                    return;
                Session["MachineName"] = dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"];
                Response.Redirect("~/MachineInputs/InputFromMachines_Show.aspx?MachineId="
                    + (int)dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]
                     + "&MachineName=" + dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"]
                     + "&ShiftId=" + (int)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"]
                      + "&ShiftName=" + (string)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Name"]
                     + "&date=" + date.SelectedDate.ToString("dd-MMM-yyyy"));
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

            Response.Redirect("../Menu.aspx");
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
            int machineId = (int)dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"];
            int ShiftId = (int)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"];
            if (validateSelection())
            {
                DataAccess da = new DataAccess();
                dt2 = da.GetMachineInputs((int)dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"],
                          (int)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"], date.SelectedDate.ToString("dd-MMM-yyyy"));
            }
            
            GenerateInputReport(dt2);
        }
        bool validateSelection()
        {
            
            
            if (date.SelectedDate == DateTime.MinValue)
            {
                Response.Write("<script>alert('Please select From and To dates...');</script>");
                return false;
            }
            return true;
        }
        void GenerateInputReport(DataTable dt2)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Inputs_from_Machines_"
                + Session["MachineName"] + ".csv");
            Response.Charset = "";
            Response.ContentType = "application/text";
            StringBuilder sBuilder = new System.Text.StringBuilder();

            sBuilder.Append("TimeStamp,Time Between Pulses[s] ");
            string[,] styles = { { "custom", "m/d/yyyy h:mm:ss;" } };
            sBuilder.Append("\r\n");
            
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                for (int j = 0; j < dt2.Columns.Count; j++)
                {

                    sBuilder.Append(dt2.Rows[i][j] + ",");
                    
                }
                
                sBuilder.Append("\r\n");
            }
            
            Response.Output.Write(sBuilder.ToString());
            Response.Flush();
            Response.End();
        }
    }
}