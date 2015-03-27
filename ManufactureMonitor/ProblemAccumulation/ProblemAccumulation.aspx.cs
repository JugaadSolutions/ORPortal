using ManufactureMonitor.DALayer;
using ManufactureMonitor.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManufactureMonitor
{
    public partial class ProblemAccumulation : System.Web.UI.Page
    {
        static DataTable dt,dt1,dt2;
        Dictionary<int, List<TimeSequence>> PAccumulation;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR  " + Session["Machinegroupname"];
            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
                dt = da.GetMachines(Convert.ToInt32(Session["MachineGroup"]));
                MachineSelectionListBox.DataSource = dt.DefaultView;
                MachineSelectionListBox.DataValueField = "Machines";
                MachineSelectionListBox.DataBind();
                

            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Session["MachineGroup"]);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if( validateSelection() )
            {
                int ShiftId = -1;
                String ShiftName = "All Shifts";
                if (ShiftSelectionListBox.SelectedIndex != -1)
                {
                    ShiftId = (int)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"];
                    ShiftName = (string)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Name"];
                }
                if (MachineSelectionListBox.SelectedIndex == -1)
                    return;
                Session["MachineName"] = dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"];
                Response.Redirect("~/ProblemAccumulation/ProblemAccumulation_Show.aspx?MachineGroupId=" + Session["MachineGroup"]
                     + "&MachineId=" + (int)dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]
                      + "&MachineName=" + dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"]
                     + "&ShiftId=" + ShiftId
                      + "&ShiftName=" + ShiftName
                       + "&datefrom=" + datefrom.SelectedDate.ToShortDateString()
                      + "&dateto=" + dateto.SelectedDate.ToShortDateString());
            }

        }

        protected void MachineSelectionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataAccess da = new DataAccess();
            if (MachineSelectionListBox.SelectedIndex == -1)
                return;
            dt1 = da.GetShiftTimings(Convert.ToInt32(dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]));
            ShiftSelectionListBox.DataSource = dt1.DefaultView;
            ShiftSelectionListBox.DataValueField = "shifts";
            ShiftSelectionListBox.DataBind();
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (validateSelection())
            {
                DataAccess da = new DataAccess();
                int machine = (int)dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"];

                DateTime fromDate = datefrom.SelectedDate;
                DateTime toDate = dateto.SelectedDate;
                toDate = toDate.AddDays(1);
                int ShiftId = -1;

                if (ShiftSelectionListBox.SelectedIndex != -1)
                {
                    ShiftId = (int)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"];

                }
                PAccumulation = new Dictionary<int, List<TimeSequence>>();
                List<ProblemAccumulationRecord> PARList = new List<ProblemAccumulationRecord>();
                while (fromDate < toDate)
                {
                    dt = da.GetShiftTimings(machine, ShiftId);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DateTime from = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["Start"]);
                        DateTime to = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["End"]);

                        List<TimeSequence> ts =
                            da.GetStopDetails(machine, ShiftId, from.ToString("yyyy-MM-dd HH:mm:ss"),
                            to.ToString("yyyy-MM-dd HH:mm:ss"), from.ToString("dd-MM-yyyy"),
                            true);

                        foreach (TimeSequence t in ts)
                        {
                            if (PAccumulation.ContainsKey(t.ProblemCode))
                            {
                                PAccumulation[t.ProblemCode].Add(t);
                            }
                            else
                            {
                                PAccumulation.Add(t.ProblemCode, new List<TimeSequence>());
                                PAccumulation[t.ProblemCode].Add(t);
                            }
                        }

                    }
                    fromDate = fromDate.AddDays(1);
                }

                

                foreach (KeyValuePair<int, List<TimeSequence>> kv in PAccumulation)
                {
                    double problemDuration = 0;

                    foreach (TimeSequence ts in kv.Value)
                    {
                        problemDuration += ts.GetDuration();
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
                GenerateAccumulationReport(PARList);
            }

            
        }
        bool validateSelection()
        {

            if (datefrom.SelectedDate == DateTime.MinValue || dateto.SelectedDate == DateTime.MinValue)
            {
                Response.Write("<script>alert('Please select From and To dates...');</script>");
                return false;
            }

            if (dateto.SelectedDate < datefrom.SelectedDate)
            {
                Response.Write("<script>alert('To Date should be greater than From Date.');</script>");
                return false;
            }
            return true;
        }
        void GenerateAccumulationReport(List<ProblemAccumulationRecord> PARList)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=ProblemAccumulation_"
                + Session["MachineName"] + ".csv");
            Response.Charset = "";
            Response.ContentType = "application/text";
            StringBuilder sBuilder = new System.Text.StringBuilder();

            sBuilder.Append("Code,Problem,Time[s],Time[%],Count,");

            sBuilder.Append("\r\n");
            for (int i = 0; i < PARList.Count; i++)
            {
                sBuilder.Append(PARList[i].ProblemCode + ",");
                sBuilder.Append(PARList[i].ProblemDescription+ ",");
                sBuilder.Append(PARList[i].TimeDuration + ",");
                sBuilder.Append(PARList[i].TimePercentage + ",");
                sBuilder.Append(PARList[i].Count + ",");
                
                sBuilder.Append("\r\n");
            }



            Response.Output.Write(sBuilder.ToString());
            Response.Flush();
            Response.End();
        }

    }
}