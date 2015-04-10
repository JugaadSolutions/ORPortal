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
    public partial class ORandMOR1 : System.Web.UI.Page
    {
        static DataTable dt, dt1,dt2;
        static List<ShiftHistory> sh;
        static String Project = "";
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (validateSelection())
            {
                String Project = "";
               
                if (ModelSelectionListBox.SelectedIndex != -1)
                    Project = (String)dt2.Rows[ModelSelectionListBox.SelectedIndex]["Name"];

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
                
                Response.Redirect("~/OR_OA/ORandMOR1_Show.aspx?MachineGroup=" + Session["MachineGroup"]
                    + "&MachineId=" + (int)dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]
                     + "&MachineName=" + dt.Rows[MachineSelectionListBox.SelectedIndex]["Machines"]
                     + "&ShiftId=" + ShiftId
                      + "&ShiftName=" + ShiftName
                      + "&datefrom=" + datefrom.SelectedDate.ToString("dd-MMM-yy")
                      + "&dateto=" + dateto.SelectedDate.ToString("dd-MMM-yy")
                      +"&Project="+Project);
                
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
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


            dt2 = da.GetModels((int)dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"]);
            ModelSelectionListBox.DataSource = dt2.DefaultView;
            ModelSelectionListBox.DataValueField = "Models";
            ModelSelectionListBox.DataBind();
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (validateSelection())
            {
               
                DateTime fromDate = datefrom.SelectedDate;
                DateTime toDate = dateto.SelectedDate;
                int machineId = (int)dt.Rows[MachineSelectionListBox.SelectedIndex]["Id"];
                int ShiftId = -1;

                if (ShiftSelectionListBox.SelectedIndex != -1)
                {
                    ShiftId = (int)dt1.Rows[ShiftSelectionListBox.SelectedIndex]["Id"];

                }
                DataAccess da = new DataAccess();

                StringBuilder sBuilder = new System.Text.StringBuilder();

                sBuilder.Append("Date,Actual Pieces,Scraps,Load Time/ Available Time [s],Non-Operation Time 1 / Machine Related [s] ,Non-Operation Time 2 / Other Than Machine Related [s],Undefined [s],Idle Time/ Exclude Hour [s],KADOURITSU/ Operation Ratio [%] ,BEKADOURITSU/ Operational Availability [%] ");

                sBuilder.Append("\r\n");


                while (fromDate <= toDate)
                {




                   

                    sh = new List<ShiftHistory>();

                    ShiftHistory cumulative = new ShiftHistory();
                    List<ShiftHistory> cumulativeList = new List<ShiftHistory>();

                    dt = da.GetShiftTimings(machineId, ShiftId);

                   
                    List<ShiftHistory> tempList = new List<ShiftHistory>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        ShiftHistory temp = new ShiftHistory();


                        DateTime from = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["Start"]);
                        DateTime to = DateTime.Parse(fromDate.ToString("yyyy-MM-dd") + " " + dt.Rows[i]["End"]);

                        if (to < from)
                            to = to.AddDays(1);

                        temp.Date = from.ToString("dd-MMM-yyyy");


                        sh = da.GetShiftHistory(machineId, from.ToString("yyyy-MM-dd HH:mm:ss"),
                                to.ToString("yyyy-MM-dd HH:mm:ss"), from.ToString("dd-MM-yyyy")
                                );

                        cumulativeList.AddRange(sh);

                        foreach (ShiftHistory s in sh)
                        {
                            if (Project != "")
                            {
                                if (s.Project != Project)
                                    continue;
                            }
                            //temp.CycleTime += s.CycleTime;
                            temp.Actual += s.Actual;
                            temp.KR += s.CycleTime * s.Actual;
                            temp.Scraps += s.Scraps;
                            temp.LoadTime += s.LoadTime;
                            temp.Nop1 += s.Nop1;
                            temp.Nop2 += s.Nop2;
                            temp.Idle += s.Idle;
                            temp.Undefined += s.Undefined;
                        }

                        double kr = (temp.KR / temp.LoadTime) * 100;

                        temp.KR = Math.Round(kr, 2);

                        double bkr = ((temp.LoadTime - temp.Nop2) / temp.LoadTime) * 100;
                        temp.BKR = Math.Round(bkr, 2);


                        tempList.Add(temp);






                    }

                    foreach (ShiftHistory s in cumulativeList)
                    {
                        if (Project != "")
                        {
                            if (s.Project != Project)
                                continue;
                        }
                        //temp.CycleTime += s.CycleTime;
                        cumulative.Actual += s.Actual;
                        cumulative.KR += s.CycleTime * s.Actual;
                        cumulative.Scraps += s.Scraps;
                        cumulative.LoadTime += s.LoadTime;
                        cumulative.Nop1 += s.Nop1;
                        cumulative.Nop2 += s.Nop2;
                        cumulative.Idle += s.Idle;
                        cumulative.Undefined += s.Undefined;
                    }



                    cumulative.KR = (cumulative.KR / cumulative.LoadTime) * 100;

                    cumulative.KR = Math.Round(cumulative.KR, 2);

                    cumulative.BKR = ((cumulative.LoadTime - cumulative.Nop2) / cumulative.LoadTime) * 100;
                    cumulative.BKR = Math.Round(cumulative.BKR, 2);






                    cumulativeList.Clear();
                    cumulativeList.Add(cumulative);


                    
                    for (int i = 0; i < tempList.Count; i++)
                    {
                        sBuilder.Append(tempList[i].Date + ",");
                        sBuilder.Append(tempList[i].Actual + ",");
                        sBuilder.Append(tempList[i].Scraps + ",");
                        sBuilder.Append(tempList[i].LoadTime + ",");
                        sBuilder.Append(tempList[i].Nop1 + ",");
                        sBuilder.Append(tempList[i].Nop2 + ",");
                        sBuilder.Append(tempList[i].Undefined + ",");
                        sBuilder.Append(tempList[i].Idle + ",");
                        sBuilder.Append(tempList[i].KR + ",");
                        sBuilder.Append(tempList[i].BKR + ",");
                        sBuilder.Append("\r\n");
                    }

                }
                GenerateAccumulationReport(sBuilder);
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
        void GenerateAccumulationReport(StringBuilder sBuilder)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=OR_OA_Accumulation_"
                + Session["MachineName"] + ".csv");
            Response.Charset = "";
            Response.ContentType = "application/text";
           
            Response.Output.Write(sBuilder.ToString());
            Response.Flush();
            Response.End();
        }
    }
}