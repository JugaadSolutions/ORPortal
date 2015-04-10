using ManufactureMonitor.DALayer;
using ManufactureMonitor.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManufactureMonitor
{
    public partial class ProblemAccumulation_Show : System.Web.UI.Page
    {
        static DataTable dt, dt1;
        Dictionary<int, List<TimeSequence>> ProblemAccumulation;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ((Label)Master.FindControl("MasterPageLabel")).Text = "OR  " + Session["MachineName"];
                DataAccess da = new DataAccess();
                int machine = Convert.ToInt32(Request.QueryString["MachineId"]);

                DateTime fromDate = DateTime.Parse(Request.QueryString["datefrom"]);
                DateTime toDate = DateTime.Parse(Request.QueryString["dateto"]);
                toDate = toDate.AddDays(1);
                int ShiftId = Convert.ToInt32(Request.QueryString["ShiftId"]);


                while (fromDate < toDate)
                {
                    dt = da.GetShiftTimings(machine, ShiftId);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ProblemAccumulation = new Dictionary<int, List<TimeSequence>>();
                        DateTime from = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["Start"]);
                        DateTime to = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["End"]);
                        String text = "StopTime Problem Accumulation " + fromDate.ToString("dd-MM-yyyy") + " -Shift " + dt.Rows[i]["Start"].ToString() + " - " + dt.Rows[i]["End"].ToString();
                        TextBox Duration = new TextBox();
                        Duration.TextMode = TextBoxMode.SingleLine;
                        Duration.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FF9966");
                        Duration.Style.Add("text-align", "center");

                        Duration.Style.Add(HtmlTextWriterStyle.FontStyle, "Bold");
                        Duration.Width = new Unit("100%");
                        Duration.Height = new Unit("30px");
                        Duration.Text = text;

                        Panel1.Controls.Add(Duration);

                        List<TimeSequence> ts =
                            da.GetStopDetails(machine, ShiftId, from.ToString("yyyy-MM-dd HH:mm:ss"),
                            to.ToString("yyyy-MM-dd HH:mm:ss"), from.ToString("dd-MM-yyyy"),
                            true);

                        foreach (TimeSequence t in ts)
                        {
                            if (ProblemAccumulation.ContainsKey(t.ProblemCode))
                            {
                                ProblemAccumulation[t.ProblemCode].Add(t);
                            }
                            else
                            {
                                ProblemAccumulation.Add(t.ProblemCode, new List<TimeSequence>());
                                ProblemAccumulation[t.ProblemCode].Add(t);
                            }
                        }




                        List<ProblemAccumulationRecord> PARList = new List<ProblemAccumulationRecord>();

                        foreach (KeyValuePair<int, List<TimeSequence>> kv in ProblemAccumulation)
                        {
                            double problemDuration = 0;

                            foreach (TimeSequence tsq in kv.Value)
                            {
                                problemDuration += tsq.GetDuration();
                            }

                            ProblemAccumulationRecord par = new ProblemAccumulationRecord();
                            par.TimeDuration = problemDuration;
                            par.ProblemCode = kv.Value[0].ProblemCode;
                            par.ProblemDescription = kv.Value[0].Problem;
                            par.Count = kv.Value.Count;

                            PARList.Add(par);
                        }
                        double TotalDuration = 0;
                        foreach (ProblemAccumulationRecord p in PARList)
                        {
                            TotalDuration += p.TimeDuration;
                        }

                        foreach (ProblemAccumulationRecord p in PARList)
                        {
                            p.TimePercentage = Math.Round((p.TimeDuration / TotalDuration) * 100, 2);
                        }

                        GridView g = new GridView();
                        g.AutoGenerateColumns = false;
                        BoundField b = new BoundField();
                        b.DataField = "ProblemCode";
                        b.HeaderText = "Code";

                        g.Columns.Add(b);

                        b = new BoundField();
                        b.DataField = "ProblemDescription";
                        b.HeaderText = "Problem";

                        g.Columns.Add(b);

                        b = new BoundField();
                        b.DataField = "TimeDuration";
                        b.HeaderText = "Time[s]";

                        g.Columns.Add(b);

                        b = new BoundField();
                        b.DataField = "TimePercentage";
                        b.HeaderText = "Time[%]";

                        g.Columns.Add(b);


                        b = new BoundField();
                        b.DataField = "Count";
                        b.HeaderText = "Count";

                        g.Columns.Add(b);

                        g.HorizontalAlign = HorizontalAlign.Center;
                        g.DataSource = PARList;
                        g.DataBind();

                        Panel1.Controls.Add(g);


                    }
                    fromDate = fromDate.AddDays(1);
                }
            }
        }

        protected void BackButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }
    }


}