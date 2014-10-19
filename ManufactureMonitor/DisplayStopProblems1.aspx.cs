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
    public partial class DisplayStopProblems1 : System.Web.UI.Page
    {
        static DataTable dt;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (MachineSelectionListBox.SelectedIndex == -1)
                return;
            Response.Redirect("~/DisplayStopProblems.aspx?MachineGroupId=" + Request.QueryString["MachineGroupId"]
                +"&MachineId="+dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroupId=" + Request.QueryString["MachineGroupId"]);
        }
    }
}