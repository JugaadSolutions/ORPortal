﻿using ManufactureMonitor.DALayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManufactureMonitor
{
    public partial class StopTimes2 : System.Web.UI.Page
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
            if (validateSelection())
            {

                if (date.SelectedDate == DateTime.MinValue)
                    return;
                Session["MachineName"] = dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"];
                Session["Machine_Id"] = (int)dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"];
                Session["Shift_Id"] = (int)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"];
                Session["ShiftName"] = (string)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Name"];
                Session["date"] = date.SelectedDate.ToString("dd-MMM-yyyy");
                Response.Redirect("~/EnterCodeComment/StopTimes2_show.aspx?MachineId=" + (int)dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]
                     + "&MachineName=" + dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"]

                     + "&ShiftId=" + (int)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"]
                      + "&ShiftName=" + (string)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Name"]
                     + "&date=" + date.SelectedDate.ToString("dd-MMM-yyyy"));
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
        bool validateSelection()
        {

            if (date.SelectedDate == DateTime.MinValue)
            {
                Response.Write("<script>alert('Please select From and To dates...');</script>");
                return false;
            }
            return true;
        }
    }
}