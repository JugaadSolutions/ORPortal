using ManufactureMonitor.DALayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManufactureMonitor
{
    public partial class InputFromMachines_Show : System.Web.UI.Page
    {
        static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
                dt = da.GetMachineInputs(Convert.ToInt32(Request.QueryString["MachineId"]),
                    Convert.ToInt32(Request.QueryString["ShiftId"]), Request.QueryString["date"]);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }

        //protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        //{
        //    Response.ClearContent();
        //    Response.Buffer = true;
        //    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Inputs.xls"));
        //    Response.ContentType = "application/ms-excel";
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter htw = new HtmlTextWriter(sw);
        //    GridView1.GridLines = GridLines.Both;
        //    GridView1.HeaderStyle.Font.Bold = true; 
        //    GridView1.RenderControl(htw);
        //    Response.Write(sw.ToString());
        //    Response.End();
        //}

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
    }
}