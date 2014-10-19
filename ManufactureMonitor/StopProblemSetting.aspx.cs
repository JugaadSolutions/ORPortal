﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ManufactureMonitor.DALayer;
using System.Data;

namespace ManufactureMonitor
{
    public partial class StopProblemSetting : System.Web.UI.Page
    {
        static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
                dt = da.GetSpecificProblems(Convert.ToInt32(Request.QueryString["MachineId"]));
                ShiftSelectionListBox.DataSource = dt.DefaultView;
                ShiftSelectionListBox.DataValueField = "Description";
                ShiftSelectionListBox.DataBind();
            }   
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }

       

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StopProblemSetting_Enter.aspx?MachineGroupId=" + Request.QueryString["MachineGroupId"]
                + "&MachineId=" + Request.QueryString["MachineId"]);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (ShiftSelectionListBox.SelectedIndex == -1)
                return;
            Response.Redirect("~/StopProblemSetting_Enter.aspx?Code=" + dt.Rows[ShiftSelectionListBox.SelectedIndex]["Code"]
                + "&MachineGroupId=" + Request.QueryString["MachineGroupId"] + "&MachineId=" + Request.QueryString["MachineId"]);
        }
    }
}