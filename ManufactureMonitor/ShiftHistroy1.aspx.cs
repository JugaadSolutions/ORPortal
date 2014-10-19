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
    public partial class ShiftHistroy1 : System.Web.UI.Page
    {
        static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
                dt = da.GetMachines(Convert.ToInt32(Request.QueryString["MachineGroupId"]));
                MachineSelectionDropDown.DataSource = dt.DefaultView;
                MachineSelectionDropDown.DataValueField = "Machines";
                MachineSelectionDropDown.DataBind();
                if (MachineSelectionDropDown.SelectedIndex == -1)
                    return;
                dt = da.GetShifts(Convert.ToInt32(dt.Rows[MachineSelectionDropDown.SelectedIndex]["Id"]));
                ShiftSelectionDropDown.DataSource = dt.DefaultView;
                ShiftSelectionDropDown.DataValueField = "shifts";
                ShiftSelectionDropDown.DataBind();
                
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ShiftHistroy_Show.aspx?MachineGroupId=" + Request.QueryString["MachineGroupId"]
                 + "&MachineId=" + MachineSelectionDropDown.SelectedIndex
                 + "&ShiftId=" + ShiftSelectionDropDown.SelectedIndex);
        }
    }
}