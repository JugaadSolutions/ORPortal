using ManufactureMonitor.DALayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManufactureMonitor
{
    public partial class InputFromMachines_Show : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR  " + Session["MachineName"];
            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
                int machineId = Convert.ToInt32(Request.QueryString["MachineId"]);
                int ShiftId = Convert.ToInt32(Request.QueryString["ShiftId"]);


                DataTable ShiftTable = da.GetShiftTimings(machineId, ShiftId);

                for (int i = 0; i < ShiftTable.Rows.Count; i++)
                {
                    TextBox Duration = new TextBox();
                    Duration.TextMode = TextBoxMode.SingleLine;
                    Duration.Style.Add("text-align", "center");
                    Duration.Style.Add("margin", "10px");
                    Duration.Width = new Unit("60%");
                    Duration.Text = Request.QueryString["date"]+":" + (ShiftTable.Rows[i]["shifts"]).ToString();

                    String from = Request.QueryString["date"] + " " + ShiftTable.Rows[i]["Start"];
                    String to = Request.QueryString["date"] + " " + ShiftTable.Rows[i]["End"];

                    DataTable dt = da.GetMachineInputs(machineId,
                        from,to);


                    GridView g = new GridView();
                    g.AutoGenerateColumns = false;
                    g.HeaderStyle.BackColor = Color.OrangeRed;
                    g.Style.Add(HtmlTextWriterStyle.Width, "50%");
                    g.HorizontalAlign = HorizontalAlign.Center;
                    BoundField b = new BoundField();
                    b.DataField = "Time";
                    b.HeaderText = "Time";

                    g.Columns.Add(b);

                    b = new BoundField();
                    b.DataField = "Duration";
                    b.HeaderText = "Time Between Pulses[s]";
                    g.Columns.Add(b);

                    g.DataSource = dt;
                    g.DataBind();

                    MainPanel.Controls.Add(Duration);
                    MainPanel.Controls.Add(g);

                    
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
    }
}