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
    public partial class ShiftHistroy_Show : System.Web.UI.Page
    {
        static DataTable dt,dt1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
                int machineId = Convert.ToInt32(Request.QueryString["MachineId"]);

                DateTime fromDate = DateTime.Parse(Request.QueryString["datefrom"]);
                DateTime toDate = DateTime.Parse(Request.QueryString["dateto"]);
                toDate = toDate.AddDays(1);
                int ShiftId = Convert.ToInt32(Request.QueryString["ShiftId"]);

                while (fromDate < toDate)
                {
                    dt = da.GetShiftTimings(machineId, ShiftId);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox Duration = new TextBox();
                        Duration.TextMode = TextBoxMode.SingleLine;
                        Duration.Style.Add("text-align", "center");
                        Duration.Style.Add("margin", "10px");
                        Duration.Width = new Unit("60%");


                        DateTime from = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["Start"]);
                        DateTime to = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["End"]);

                        if (to < from)
                            to = to.AddDays(1);




                        Duration.Text = fromDate.ToShortDateString() + ":" + (dt.Rows[i]["shifts"]).ToString();
                        dt1 = da.GetShiftHistory(machineId, from.ToString("yyyy-MM-dd HH:mm:ss"),
                            to.ToString("yyyy-MM-dd HH:mm:ss"),
                            Convert.ToBoolean(Request.QueryString["Summary"]));

                        GridView g = new GridView();
                        g.AutoGenerateColumns = false;
                       
                        BoundField b = new BoundField();
                        
                        b.DataField = "From";
                        b.HeaderText = "From";

                        g.Columns.Add(b);

                        b = new BoundField();
                        b.DataField = "To";
                        b.HeaderText = "To";

                        g.Columns.Add(b);

                        b = new BoundField();
                        b.DataField = "Project";
                        b.HeaderText = "Project/Model";

                        g.Columns.Add(b);

                        b = new BoundField();
                        b.DataField = "CycleTime";
                        b.HeaderText = "Plan Cycle Time[s]";

                        g.Columns.Add(b);


                        b = new BoundField();
                        b.DataField = "Actual";
                        b.HeaderText = "OK Pieces";

                        g.Columns.Add(b);

                        b = new BoundField();
                        b.DataField = "Scraps";
                        b.HeaderText = "Scraps";

                        g.Columns.Add(b);



                        g.HorizontalAlign = HorizontalAlign.Center;
                        g.DataSource = dt1;
                        g.DataBind();
                        MainPanel.Controls.Add(Duration);
                        MainPanel.Controls.Add(g);

                    }
                    fromDate = fromDate.AddDays(1);
                }
            }


        }

        protected void BackButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup="+Request.QueryString["MachineGroupId"]);
        }
    }
}