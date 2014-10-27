﻿using ManufactureMonitor.DALayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ManufactureMonitor
{
    public partial class ShiftDefintionSetting1 : System.Web.UI.Page
    {
        static DataTable dt;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
           // Session["Id"] = dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"];
            Response.Redirect("~/Shifts/ShiftDefinitionSetting.aspx?MachineId=" 
                + dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"] );
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Menu.aspx");
        }
    }
}