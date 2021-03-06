﻿using ManufactureMonitor.DALayer;
using ManufactureMonitor.Entity;
using OfficeOpenXml;
using OfficeOpenXml.Style;
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
    
    public partial class TimeSequence1_Show : System.Web.UI.Page
    {
        static DataTable dt;
        static List<DataTable> dts;
        static List<TimeSequence> Ts;
        static List<String> fileNames;
        static List<String> sheetNames;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR  " + Session["MachineName"];
            if (!Page.IsPostBack)
            {
                DataAccess da = new DataAccess();
                int machineId = Convert.ToInt32(Request.QueryString["MachineId"]);

                dts = new List<DataTable>();
             

                DateTime fromDate = DateTime.Parse(Request.QueryString["datefrom"]);
                DateTime toDate = DateTime.Parse(Request.QueryString["dateto"]);
                toDate = toDate.AddDays(1);
                int ShiftId = Convert.ToInt32(Request.QueryString["ShiftId"]);

                ShiftCollection shifts = new ShiftCollection();

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

                        Shift shift = shifts.getShift(from, to);
                        shift.Breaks = da.getBreaks(shift.ID, machineId);
                        shift.Sessions = da.getSessions(shift.ID, machineId);

                        if (to < from)
                            to = to.AddDays(1);




                        Duration.Text = fromDate.ToShortDateString() + ":" + (dt.Rows[i]["shifts"]).ToString();
                        Ts = da.GetStopDetails(machineId, shift, from.ToString("yyyy-MM-dd HH:mm:ss"),
                            to.ToString("yyyy-MM-dd HH:mm:ss"),from.ToString("dd-MM-yyyy"),
                            Convert.ToBoolean(Request.QueryString["SpeedLoss"]));

                     
                        

                        

                        GridView g = new GridView();
                        g.AutoGenerateColumns = false;
                        g.HeaderStyle.BackColor = Color.OrangeRed;
                        g.Style.Add(HtmlTextWriterStyle.Width, "50%");
                        g.HorizontalAlign = HorizontalAlign.Center;

                        BoundField b = new BoundField();
                        b.DataField = "From";
                        b.HeaderText = "From";

                        g.Columns.Add(b);

                        b = new BoundField();
                        b.DataField = "To";
                        b.HeaderText = "To";

                        g.Columns.Add(b);

                        b = new BoundField();
                        b.DataField = "Duration";
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
                        g.DataSource = Ts;
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



        //protected void Export_Click(object sender, EventArgs e)
        //{
        //    using (ExcelPackage pck = new ExcelPackage())
        //    {
        //        int i = 0;
        //        foreach (DataTable d in dts)
        //        {
        //            if (d.Rows.Count <= 0) {  continue; }
        //            //Create the worksheet
        //            ExcelWorksheet ws = pck.Workbook.Worksheets.Add(sheetNames[i]);

        //            //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1
        //            ws.Cells["A1"].LoadFromDataTable(d, true);

        //            //Format the header for column 1-3
        //            using (ExcelRange rng = ws.Cells["A1:F1"])
        //            {
        //                rng.Style.Font.Bold = true;
        //                rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
        //                rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
        //                rng.Style.Font.Color.SetColor(Color.White);
        //            }

        //            ////Example how to Format Column 1 as numeric 
        //            //using (ExcelRange col = ws.Cells[2,1,d.Rows.Count+1,2])
        //            //{
        //            //    col.Style.Numberformat.Format = "HH:mm:ss";
        //            //    //col.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
        //            //}

        //            i++;
        //        }
        //        //Write it back to the client
        //        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //        Response.AddHeader("content-disposition", "attachment;  filename=" + fileNames[0]+".xlsx");
        //        Response.BinaryWrite(pck.GetAsByteArray());
        //    }
        //}

       
    }
}