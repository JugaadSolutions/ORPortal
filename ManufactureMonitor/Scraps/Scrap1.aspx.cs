﻿using ManufactureMonitor.DALayer;
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
    public partial class Scrap1 : System.Web.UI.Page
    {
        static DataTable dt, dt1;
        static int machine;
        static int shiftid;
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
                TotalPanel.Visible = false;
                
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Menu.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (validateSelection())
            {
                if (MachineSelectionListBox.SelectedIndex == -1)
                    return;
                Session["MachineName"] = dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"];
                shiftid = ShiftSelectionListBox.SelectedIndex == -1 ? -1 : Convert.ToInt32(dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"]);


                Response.Redirect("~/Scraps/Scrap_entry.aspx?MachineId=" + (int)dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]
                     + "&MachineName=" + dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"]
                     + "&ShiftId=" + shiftid + "&From=" + Calendar1.SelectedDate.ToString("dd-MMM-yyyy")
                     + "&To=" + Calendar2.SelectedDate.ToString("dd-MMM-yyyy"));
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
            machine =Convert.ToInt32(dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]);
            



        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (validateSelection())
            {
                int shiftid = ShiftSelectionListBox.SelectedIndex == -1 ? 0 : Convert.ToInt32(dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"]);


                Response.Redirect("~/Scraps/Scrap_show.aspx?MachineId=" + (int)dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]
                     + "&ShiftId=" + shiftid
                     + "&ShiftName=" + (string)dt1.Rows[MachineSelectionListBox.SelectedIndex]["Name"]
                     + "&From=" + Calendar1.SelectedDate.ToString("dd-MMM-yyyy")
                     + "&To=" + Calendar2.SelectedDate.ToString("dd-MMM-yyyy"));
            }
        }
        bool validateSelection()
        {

            if (Calendar1.SelectedDate == DateTime.MinValue || Calendar2.SelectedDate == DateTime.MinValue)
            {
                Response.Write("<script>alert('Please select From and To dates...');</script>");
                return false;
            }

            if (Calendar2.SelectedDate < Calendar1.SelectedDate)
            {
                Response.Write("<script>alert('To Date should be greater than From Date.');</script>");
                return false;
            }
            return true;
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (validateSelection())
            {
                DateTime fromDate = DateTime.Parse(Calendar1.SelectedDate.ToString("dd-MMM-yyyy"));
                DateTime toDate = DateTime.Parse(Calendar2.SelectedDate.ToString("dd-MMM-yyyy"));
               
                DataAccess da = new DataAccess();
                toDate = toDate.AddDays(1);

                int ShiftId = -1;
                if (ShiftSelectionListBox.SelectedIndex != -1)
                {
                    ShiftId = (int)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"];
                }

                int machineId = Convert.ToInt32(dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]);
                 StringBuilder sBuilder = new System.Text.StringBuilder();

                 sBuilder.Append("Date,OKPieces,Rejection,[%]Rejection");

                 sBuilder.Append("\r\n");
            
                 while (fromDate < toDate)
                 {
                     DataTable ShiftTimingsTable = da.GetShiftTimings(machineId, ShiftId);
                     for (int j = 0; j < ShiftTimingsTable.Rows.Count; j++)
                     {
                         DateTime from = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + ShiftTimingsTable.Rows[j]["Start"]);
                         DateTime to = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + ShiftTimingsTable.Rows[j]["End"]);

                         if (to < from)
                             to = to.AddDays(1);


                         dt = da.GetScrapsReport(machineId,  from, to);

                         for (int i = 0; i < dt.Rows.Count; i++)
                         {
                             sBuilder.Append(dt.Rows[i]["Date"] + ",");
                             sBuilder.Append(dt.Rows[i]["Actual"] + ",");
                             sBuilder.Append(dt.Rows[i]["Scraps"] + ",");
                             sBuilder.Append(dt.Rows[i]["Rejection"] + ",");
                             sBuilder.Append("\r\n");
                             

                         }
                     }
                     fromDate = fromDate.AddDays(1);
                 }
              
                GenerateScrapReport( sBuilder );
            }
                
        }
        void GenerateScrapReport(StringBuilder sBuilder )
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Scraps_"
                + Session["MachineName"] + ".csv");
            Response.Charset = "";
            Response.ContentType = "application/text";
            



            Response.Output.Write(sBuilder.ToString());
            Response.Flush();
            Response.End();
        }
    }
}