﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ManufactureMonitor.DALayer;
using System.Data;

namespace ManufactureMonitor
{
    public partial class DisplayParameters : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR" + Session["Machinegroupname"];
            DataAccess da = new DataAccess();

            DataTable dt = da.GetParameters(Convert.ToInt32(Session["MachineGroup"]));
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void BackButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx" );
        }

        
    }
}