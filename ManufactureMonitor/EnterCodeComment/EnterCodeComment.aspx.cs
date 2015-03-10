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
    public partial class EnterCodeComment : System.Web.UI.Page
    {
        static DataTable dt,dt1;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR  " + Session["MachineName"];
            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
                dt = da.GetStopsInfo(Convert.ToInt32(Request.QueryString["Machine_Id"]));

                CodeSelection.DataSource = dt;
                CodeSelection.DataValueField = "Description";
                CodeSelection.DataBind();
                CodeSelection.SelectedIndex = -1;

                
               
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("StopTimes2.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataAccess da = new DataAccess();
            da.UpdateStopInfo(Convert.ToInt32(Request.QueryString["SlNo"]),
                (int)dt.Rows[CodeSelection.SelectedIndex]["Code"],Request.QueryString["Type"],
                TextBox2.Text, Convert.ToInt32(Request.QueryString["Machine_Id"]));

            Response.Write("<script>alert('Action Completed Successfully..');if(alert){ window.location='../EnterCodeComment/StopTimes2_show.aspx';}</script>");
        }
    }
}