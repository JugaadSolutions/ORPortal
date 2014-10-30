using ManufactureMonitor.DALayer;
using ManufactureMonitor.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManufactureMonitor
{
    public partial class ShiftHistroy_Show : System.Web.UI.Page
    {
        static DataTable dt,dt1;
        static List<ShiftHistory> Sh;
        static List<ShiftHistory_Summary> shSummary;
        static bool summary;
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

                summary = Convert.ToBoolean(Request.QueryString["Summary"]);
                


                while (fromDate < toDate)
                {
                    dt = da.GetShiftTimings(machineId, ShiftId);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox Duration = new TextBox();
                        Duration.TextMode = TextBoxMode.SingleLine;
                        Duration.BackColor = Color.LightGray;
                        Duration.Style.Add("text-align", "center");
                        Duration.Style.Add("margin", "10px");
                        Duration.Width = new Unit("60%");


                        DateTime from = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["Start"]);
                        DateTime to = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["End"]);

                        if (to < from)
                            to = to.AddDays(1);

                        Duration.Text = fromDate.ToString("dd-MMM-yy") + ":" + (dt.Rows[i]["shifts"]).ToString();
                        if (!summary)
                        {


                            Sh = da.GetShiftHistory(machineId, from.ToString("yyyy-MM-dd HH:mm:ss"),
                                to.ToString("yyyy-MM-dd HH:mm:ss")
                                );
                        }
                        else
                        {
                            shSummary =  da.GetShiftHistory_Summary(machineId, from.ToString("yyyy-MM-dd HH:mm:ss"),
                                to.ToString("yyyy-MM-dd HH:mm:ss")
                                );
                        }

                        GridView g = new GridView();
                        g.RowDataBound += g_RowDataBound;
                        g.AutoGenerateColumns = false;
                        g.HeaderStyle.BackColor = Color.OrangeRed;
                        

                        BoundField b;
                        if (!summary)
                        {

                            b = new BoundField();
                            b.DataField = "From";
                            b.HeaderText = "From";

                            g.Columns.Add(b);

                            b = new BoundField();
                            b.DataField = "To";
                            b.HeaderText = "To";
                            g.Columns.Add(b);
                        }

                       

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

                        b = new BoundField();
                        b.DataField = "LoadTime";
                        b.HeaderText = "Load Time/Available Time [s]";

                        g.Columns.Add(b);


                        b = new BoundField();
                        b.DataField = "Nop1";
                        b.HeaderText = "Non-Operation Time 1 / Machine Related [s] ";

                        g.Columns.Add(b);

                        b = new BoundField();
                        b.DataField = "Nop2";
                        b.HeaderText = "Non-Operation Time 2 / Other Than Machine Related [s] ";

                        g.Columns.Add(b);

                        b = new BoundField();
                        b.DataField = "Undefined";
                        b.HeaderText = "Undefined [s] ";

                        g.Columns.Add(b);

                        b = new BoundField();
                        b.DataField = "Idle";
                        b.HeaderText = "Idle Time/Exclude Hour [s] ";

                        g.Columns.Add(b);

                        b = new BoundField();
                        b.DataField = "KR";
                        b.HeaderText = "KADOURITSU/Operation Ratio [%] ";

                        g.Columns.Add(b);

                        b = new BoundField();
                        b.DataField = "BKR";
                        b.HeaderText = "BEKADOURITSU/Operational Availability [%] ";

                        g.Columns.Add(b);

                        g.HorizontalAlign = HorizontalAlign.Center;
                        if (!summary)
                        {
                            g.DataSource = Sh;
                        }
                        else
                            g.DataSource = shSummary;

                        g.DataBind();
                        MainPanel.Controls.Add(Duration);
                        MainPanel.Controls.Add(g);

                        if (g.Rows.Count > 0)
                        {

                            TextBox Total = new TextBox();
                            Total.TextMode = TextBoxMode.SingleLine;
                            Total.BackColor = Color.OrangeRed;
                            Total.Style.Add("text-align", "center");

                            Total.Style.Add(HtmlTextWriterStyle.FontStyle, "Bold");
                            Total.Width = new Unit("100%");

                            Total.Text = "Shift Total";

                            MainPanel.Controls.Add(Total);
                            if (!summary)
                            {
                                List<ShiftHistory> tempList = new List<ShiftHistory>();
                                ShiftHistory temp = new ShiftHistory();
                                foreach (ShiftHistory sh in Sh)
                                {
                                    temp.Actual += sh.Actual;
                                    temp.Scraps += sh.Scraps;
                                    temp.LoadTime += sh.LoadTime;
                                    temp.Nop1 += sh.Nop1;
                                    temp.Nop2 += sh.Nop2;
                                    temp.Idle += sh.Idle;
                                    temp.Undefined += sh.Undefined;
                                    temp.KR += ((sh.Actual * sh.CycleTime));
                                    temp.BKR += ((sh.LoadTime - sh.Nop1));
                                }

                                temp.KR = Math.Round((temp.KR / temp.LoadTime) * 100, 2);
                                temp.BKR = Math.Round((temp.BKR / temp.LoadTime) * 100, 2);
                                tempList.Add(temp);

                                GridView g1 = new GridView();

                                g1.Style.Add(HtmlTextWriterStyle.Width, "100%");
                                g1.RowDataBound += g1_RowDataBound;
                                g1.ShowHeader = false;
                                g1.DataSource = tempList;
                                g1.DataBind();

                                MainPanel.Controls.Add(g1);


                            }
                            else
                            {
                                ShiftHistory_Summary sTemp = ShiftHistory_Summary.ShiftHistory_SummaryTotal(shSummary);
                                List<ShiftHistory_Summary> sList = new List<ShiftHistory_Summary>();

                                sList.Add(sTemp);

                                GridView g1 = new GridView();

                                g1.Style.Add(HtmlTextWriterStyle.Width, "100%");
                                g1.RowDataBound += g1_RowDataBound;
                                g1.ShowHeader = false;
                                g1.DataSource = sList;
                                g1.DataBind();

                                MainPanel.Controls.Add(g1);

                            }
                        }

                    }
                    fromDate = fromDate.AddDays(1);
                }
            }


        }

        void g_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Width = new Unit("6%");
                e.Row.Cells[1].Width = new Unit("6%");
                e.Row.Cells[2].Width = new Unit("28%");
                e.Row.Cells[3].Width = new Unit("6%");
                e.Row.Cells[4].Width = new Unit("6%");
                e.Row.Cells[5].Width = new Unit("6%");
                e.Row.Cells[6].Width = new Unit("6%");
                e.Row.Cells[7].Width = new Unit("6%");
                e.Row.Cells[8].Width = new Unit("6%");
                e.Row.Cells[9].Width = new Unit("6%");
                e.Row.Cells[10].Width = new Unit("6%");
                if (!summary)
                {
                    e.Row.Cells[11].Width = new Unit("6%");
                    e.Row.Cells[12].Width = new Unit("6%");
                }
               


            }


        }

        void g1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                foreach (TableCell c in e.Row.Cells)
                    c.Width = new Unit("7.7%");
            }
        }

        protected void BackButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup="+Request.QueryString["MachineGroupId"]);
        }
    }
}