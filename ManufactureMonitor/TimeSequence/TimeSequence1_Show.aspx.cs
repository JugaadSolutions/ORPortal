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
    
    public partial class TimeSequence1_Show : System.Web.UI.Page
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
                        dt1 = da.GetStopDetails(machineId, ShiftId, from.ToString("yyyy-MM-dd HH:mm:ss"),
                            to.ToString("yyyy-MM-dd HH:mm:ss"),
                            Convert.ToBoolean(Request.QueryString["SpeedLoss"]));

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
                        b.DataField = "Duration[s]";
                        b.HeaderText = "Duration[s]";

                        g.Columns.Add(b);

                        b = new BoundField();
                        b.DataField = "StopType";
                        b.HeaderText = "Stop Type";

                        g.Columns.Add(b);


                        b = new BoundField();
                        b.DataField = "Problem";
                        b.HeaderText = "Problem";

                        g.Columns.Add(b);

                        b = new BoundField();
                        b.DataField = "Comment";
                        b.HeaderText = "Comment";

                        g.Columns.Add(b);



                        g.HorizontalAlign = HorizontalAlign.Center;
                        g.DataSource = dt1;
                        g.DataBind();
                        Panel1.Controls.Add(Duration);
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



        protected void Export_Click(object sender, EventArgs e)
        {
            //using (XLWorkbook wb = new XLWorkbook())
            //{
            //    wb.Worksheets.Add(ds);
            //    wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            //    wb.Style.Font.Bold = true;

            //    Response.Clear();
            //    Response.Buffer = true;
            //    Response.Charset = "";
            //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //    Response.AddHeader("content-disposition", "attachment;filename=Summary_Rpt.xlsx");

            //    using (MemoryStream MyMemoryStream = new MemoryStream())
            //    {
            //        wb.SaveAs(MyMemoryStream);
            //        MyMemoryStream.WriteTo(Response.OutputStream);

            //        Response.Flush();
            //        Response.End();
            //    }
            //}
        }
    }
}