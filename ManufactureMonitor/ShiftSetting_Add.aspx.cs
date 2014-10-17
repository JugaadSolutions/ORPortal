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
    public partial class ShiftSetting_Add : System.Web.UI.Page
    {
        static DataTable dt;
        static bool IsEdit = false;
        protected void Page_Load(object sender, EventArgs e)
        {
             
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["ShiftId"] != null)
                {
                    DataAccess da = new DataAccess();
                    dt = da.SelectShift(Convert.ToInt32(Request.QueryString["ShiftId"]));
                    TextBox2.Text = (dt.Rows[0]["SHours"]).ToString();
                    TextBox3.Text = (dt.Rows[0]["SMinutes"]).ToString();
                    TextBox4.Text = (dt.Rows[0]["EHours"]).ToString();
                    TextBox5.Text = (dt.Rows[0]["EMinutes"]).ToString();
                    dt = da.SelectBreak(Convert.ToInt32(Request.QueryString["ShiftId"]), Convert.ToInt32(Request.QueryString["MachineId"]));
                    if (dt.Rows.Count > 0)
                    {
                        TextBox6.Text = (dt.Rows[0]["SHours"]) == DBNull.Value ? "" : (dt.Rows[0]["SHours"]).ToString();
                        TextBox7.Text = (dt.Rows[0]["SMinutes"]) == DBNull.Value ? "" : (dt.Rows[0]["SMinutes"]).ToString();
                        TextBox26.Text = (dt.Rows[0]["EHours"]) == DBNull.Value ? "" : (dt.Rows[0]["EHours"]).ToString();
                        TextBox27.Text = (dt.Rows[0]["EMinutes"]) == DBNull.Value ? "" : (dt.Rows[0]["EMinutes"]).ToString();
                    }
                    if (dt.Rows.Count > 1)
                    {
                        
                        TextBox10.Text = (dt.Rows[1]["SHours"]) == DBNull.Value ? "" : (dt.Rows[1]["SHours"]).ToString();
                        TextBox11.Text = (dt.Rows[1]["SMinutes"]) == DBNull.Value ? "" : (dt.Rows[1]["SMinutes"]).ToString();
                        TextBox12.Text = (dt.Rows[1]["EHours"]) == DBNull.Value ? "" : (dt.Rows[1]["EHours"]).ToString();
                        TextBox13.Text = (dt.Rows[1]["EMinutes"]) == DBNull.Value ? "" : (dt.Rows[1]["EMinutes"]).ToString();
                    }
                    if (dt.Rows.Count > 2)
                    {
                        TextBox14.Text = (dt.Rows[2]["SHours"]) == DBNull.Value ? "" : (dt.Rows[2]["SHours"]).ToString();
                        TextBox15.Text = (dt.Rows[2]["SMinutes"]) == DBNull.Value ? "" : (dt.Rows[2]["SMinutes"]).ToString();
                        TextBox16.Text = (dt.Rows[2]["EHours"]) == DBNull.Value ? "" : (dt.Rows[2]["EHours"]).ToString();
                        TextBox17.Text = (dt.Rows[2]["EMinutes"]) == DBNull.Value ? "" : (dt.Rows[2]["EMinutes"]).ToString();
                        
                    }
                    if (dt.Rows.Count > 3)
                    {
                        TextBox18.Text = (dt.Rows[3]["SHours"]) == DBNull.Value ? "" : (dt.Rows[3]["SHours"]).ToString();
                        TextBox19.Text = (dt.Rows[3]["SMinutes"]) == DBNull.Value ? "" : (dt.Rows[3]["SMinutes"]).ToString();
                        TextBox20.Text = (dt.Rows[3]["EHours"]) == DBNull.Value ? "" : (dt.Rows[3]["EHours"]).ToString();
                        TextBox21.Text = (dt.Rows[3]["EMinutes"]) == DBNull.Value ? "" : (dt.Rows[3]["EMinutes"]).ToString();
                       
                    }
                    if (dt.Rows.Count > 3)
                    {

                        TextBox22.Text = (dt.Rows[4]["SHours"]) == DBNull.Value ? "" : (dt.Rows[4]["SHours"]).ToString();
                        TextBox23.Text = (dt.Rows[4]["SMinutes"]) == DBNull.Value ? "" : (dt.Rows[4]["SMinutes"]).ToString();
                        TextBox24.Text = (dt.Rows[4]["EHours"]) == DBNull.Value ? "" : (dt.Rows[4]["EHours"]).ToString();
                        TextBox25.Text = (dt.Rows[4]["EMinutes"]) == DBNull.Value ? "" : (dt.Rows[4]["EMinutes"]).ToString();
                    }
                    
                    dt = da.Selectday(Convert.ToInt32(Request.QueryString["ShiftId"]), Convert.ToInt32(Request.QueryString["MachineId"]));
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if ((bool)dt.Rows[0][i] == true )
                        {
                            CheckBoxList1.Items[i].Selected = true;
                        }
                    }
                    IsEdit = true;  //editing existing shift
                }
             
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            DataAccess da = new DataAccess();

            List<String> Start = new List<String>();
            List<String> End = new List<String>();

            Start.Add("2014-01-01 " + TextBox2.Text + ":" + TextBox3.Text);
            End.Add("2014-01-01 " + TextBox4.Text + ":" + TextBox5.Text);

            List<String> BreakStart = new List<String>();
            List<String> BreakEnd = new List<String>();

            String[] Tags = { "FIRST REST", "SECOND REST", "THIRD REST", "FOURTH REST", "FIFTH REST" };
            BreakStart.Add("2014-01-01 " + TextBox6.Text + ":" + TextBox7.Text); BreakEnd.Add("2014-01-01 " + TextBox26.Text + ":" + TextBox27.Text);
            BreakStart.Add("2014-01-01 " + TextBox10.Text + ":" + TextBox11.Text); BreakEnd.Add("2014-01-01 " + TextBox12.Text + ":" + TextBox13.Text);
            BreakStart.Add("2014-01-01 " + TextBox14.Text + ":" + TextBox15.Text); BreakEnd.Add("2014-01-01 " + TextBox16.Text + ":" + TextBox17.Text);
            BreakStart.Add("2014-01-01 " + TextBox18.Text + ":" + TextBox19.Text); BreakEnd.Add("2014-01-01 " + TextBox20.Text + ":" + TextBox21.Text);
            BreakStart.Add("2014-01-01 " + TextBox22.Text + ":" + TextBox23.Text); BreakEnd.Add("2014-01-01 " + TextBox24.Text + ":" + TextBox25.Text);

            DateTime start;
            DateTime end;
            if ((DateTime.TryParse(Start[0], out start) == false) || (DateTime.TryParse(End[0], out end) == false))
            {
                Response.Write("<script>alert('Invalid Data. Please Check.');</script>");

            }
            else    // if data is valid
            {
                int Shift_Id;
                if (IsEdit == false)     // if adding a new shift
                {
                    Shift_Id = da.AddShift(start, end);
                    if (Shift_Id == -1)
                    {
                        Response.Write("<script>alert('Error while Adding Shift!!');</script>");
                    }
                    da.AddShiftday(Convert.ToInt32(Request.QueryString["MachineId"]), Shift_Id, CheckBoxList1.Items[0].Selected,
                    CheckBoxList1.Items[1].Selected, CheckBoxList1.Items[2].Selected,
                    CheckBoxList1.Items[3].Selected, CheckBoxList1.Items[4].Selected,
                    CheckBoxList1.Items[5].Selected, CheckBoxList1.Items[6].Selected);
                }

                else
                {
                    Shift_Id = Convert.ToInt32(Request.QueryString["ShiftId"]);

                    da.UpdateShift(Shift_Id, start.ToString(), end.ToString());
                    da.UpdateShiftday(Convert.ToInt32(Request.QueryString["MachineId"]),
                     Convert.ToInt32(Request.QueryString["ShiftId"]), CheckBoxList1.Items[0].Selected,
                     CheckBoxList1.Items[1].Selected, CheckBoxList1.Items[2].Selected,
                     CheckBoxList1.Items[3].Selected, CheckBoxList1.Items[4].Selected,
                     CheckBoxList1.Items[5].Selected, CheckBoxList1.Items[6].Selected);

                }


                if (IsEdit == true)     // if adding a new shift
                {
                    da.DeleteBreaks(Convert.ToInt32(Request.QueryString["MachineId"]), Shift_Id);
                }
                for (int i = 0; i < 5; i++)
                {
                    DateTime BreakS;
                    DateTime BreakE;
                    if ((DateTime.TryParse(BreakStart[i], out BreakS) == false) || (DateTime.TryParse(BreakEnd[i], out BreakE) == false))
                    {
                        continue;
                    }


                    if (BreakE < BreakS)
                    {
                        BreakE.AddDays(1);
                    }

                    da.AddBreaks(Convert.ToInt32(Request.QueryString["MachineId"]), Shift_Id, BreakS,
                        BreakE, Tags[i]);

                }
                Response.Write("<script>alert('Action Completed Successfully..');if(alert){ window.location='Menu.aspx';}</script>");


            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Menu.aspx?MachineGroup=" + Request.QueryString["MachineGroupId"]);
        }
        
    }
}