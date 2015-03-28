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
                int ShiftId = -1;
                string ShiftName = "All Shifts";
                if (ShiftSelectionListBox.SelectedIndex != -1)
                {
                    ShiftId = (int)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"];
                    ShiftName = (string)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Name"];
                }
                if (MachineSelectionListBox.SelectedIndex == -1)
                    return;
                Session["MachineName"] = dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"];
                Response.Redirect("~/MachineInputs/InputFromMachines_Show.aspx?MachineId="
                    + (int)dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]
                     + "&MachineName=" + dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"]
                     + "&ShiftId=" + ShiftId
                      + "&ShiftName=" + ShiftName
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

            int ShiftId = -1;
            if (ShiftSelectionListBox.SelectedIndex != -1)
            {
                ShiftId = (int)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"];
            }

            DataAccess da = new DataAccess();
            DataTable ShiftTable = da.GetShiftTimings(machineId, ShiftId);

            if (validateSelection())
            {
                StringBuilder sBuilder = new System.Text.StringBuilder();
                sBuilder.Append("Time,Time Between Pulses[s] ");

                sBuilder.Append("\r\n");
            

                for (int i = 0; i < ShiftTable.Rows.Count; i++)
                {
                    String from = date.SelectedDate.ToString("dd-MMM-yyyy") + " " + ShiftTable.Rows[i]["Start"];
                    String to = date.SelectedDate.ToString("dd-MMM-yyyy") + " " + ShiftTable.Rows[i]["End"];

                     dt2 = da.GetMachineInputs(machineId,
                        from, to);

                     for (int k = 0; k < dt2.Rows.Count; k++)
                     {

                         sBuilder.Append(dt2.Rows[k]["Time"] + ",");
                         sBuilder.Append(dt2.Rows[k]["Duration"] + ",");
                         sBuilder.Append("\r\n");
                     }

                         

                         
                     
                }

               
                GenerateInputReport(sBuilder);
            }
            
           
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
        void GenerateInputReport(StringBuilder sBuilder)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Inputs_from_Machines_"
                + Session["MachineName"] + ".csv");
            Response.Charset = "";
            Response.ContentType = "application/text";
            

           
            
            
            Response.Output.Write(sBuilder.ToString());
            Response.Flush();
            Response.End();
        }
    }
}