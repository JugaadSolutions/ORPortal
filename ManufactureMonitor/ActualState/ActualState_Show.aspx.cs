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
    public partial class ActualState_Show : System.Web.UI.Page
    {
        static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("MasterPageLabel")).Text = "OR  " + Request.QueryString["MachineName"];
            Update();
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Update();
            

        }
        void Update()
        {
            int machine = Convert.ToInt32(Request.QueryString["MachineId"]);
            DateTime now = DateTime.Now;
            SystimeTextBox.Text = now.ToString("HH:mm");
            DataAccess da = new DataAccess();
            dt = da.CurrentProject(machine);
            ProjectTextBox.Text = (String)dt.Rows[0][0]+"ss";
            ShiftCollection shifts = da.getShifts(machine);
             Shift s = shifts.getCurrentShift();
             s.Sessions = da.getSessions(s.ID, machine);
             s.Breaks = da.getBreaks(s.ID, machine);

             if (s.IsActive == false) SystimeTextBox.BackColor = Color.DarkGray;
             else
             {
                 Stop off = da.getOff(machine);
                 Stop stop = da.getStop(machine,s );
                

            Session se =  s.getSession(now);

            DateTime seStart = DateTime.Parse(se.StartTime);

            TimeIntervalLabel.Text = "Actual Time Interval  " + seStart.ToString("HH:mm") + "-" + now.ToString("HH:mm");

            DateTime shStart = DateTime.Parse(s.StartTime);

            ShiftLabel.Text = "Actual Shift  " + shStart.ToString("HH:mm") + "-" + now.ToString("HH:mm");

            int seactual =  da.getSessionActual(se, machine);
            int seplan = da.getSessionPlan(se, machine);
            dt = da.GetParameters(Convert.ToInt32(Session["MachineGroup"]), machine);
             double Rmin=(double)dt.Rows[0][1];
             double  Rmax=(double)dt.Rows[0][2];
            double Omin = (double)dt.Rows[0][3];
            double Omax = (double)dt.Rows[0][4];
            double Gmin =(double) dt.Rows[0][5];
            double Gmax = (double)dt.Rows[0][6];

             int Red= Convert.ToInt32(Rmax)-Convert.ToInt32(Rmin);
            int Orange = Convert.ToInt32(Omax) - Convert.ToInt32(Omin);
            int Green = Convert.ToInt32(Gmax) - Convert.ToInt32(Gmin);
            double OR = 0;
            if (seplan > 0)
            {
                OR = Math.Round((seactual * 100.0 / seplan), 2);
                 ORTextBox.Text = OR.ToString()+"%";
            }


            ORTextBox.Text = OR.ToString()+"%";
            if ( OR >= 0 && OR < Rmax)
            {
                ORTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("Red");
                
                SessionSmiley.ImageUrl = "~/Images/RED_SMILEY.png";
                Pointer.ImageUrl = "~/Images/redTriangle.PNG";
                int lm = ((int)(OR * 760) / 100);
                if (lm < 0)
                    lm = 0;
                Pointer.Attributes.Add("style", "margin-left:" + lm + "px");
                

            }
            else if (OR >= Omin && OR < Omax)
            {
                ORTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("OrangeRed");
                
                SessionSmiley.ImageUrl = "~/Images/ORANGE_SmiLEY.png";
                Pointer.ImageUrl = "~/Images/OrangeTriangle.PNG";
                
                int lm = ((int)(OR * 760) / 100);

                Pointer.Attributes.Add("style", "margin-left:" + lm + "px");
                
                
            }

            else if (OR >= Gmin && OR <= Gmax)
            {
                ORTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("Lime");
                
                SessionSmiley.ImageUrl = "~/Images/GREEN_SMILEY.png";
                Pointer.ImageUrl = "~/Images/greenTriangle.PNG";
                int lm = ((int)(OR * 760)/100);
                Pointer.Attributes.Add("style", "margin-left:" + lm + "px");
               
            }
            else if (OR > Gmax)
            {
                ORTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                
                int lm= ((int)(OR * 760)/100);;
                if (OR > 100)
                     lm = 761;
                
                
                    
                Pointer.Attributes.Add("style", "margin-left:" + lm +"px");
                SessionSmiley.ImageUrl = "";
                Pointer.ImageUrl = "~/Images/whiteTriangle .png";
            }


            SessionActualTextBox.Text = "A " + seactual.ToString();
            SessionPlanTextBox.Text = "P " + seplan.ToString();

           
           
           
            string Rlblwidth = Convert.ToString(Red)+"%";
            string Olblwidth = Convert.ToString(Orange) + "%";
            string Glblwidth = Convert.ToString(Green) + "%";
            RedLabel.Attributes.Add("style", "width:" + Rlblwidth);
            OrangeLabel.Attributes.Add("style", "width:" + Olblwidth);
            GreenLabel.Attributes.Add("style", "width:" + Glblwidth);

            int shiftplan = 0;
            int shiftactual = 0;

            foreach (Session sd in s.Sessions)
            {
                shiftplan += da.getSessionPlan(sd, machine);
                shiftactual += da.getSessionActual(sd, machine);
            }

            ShiftActualTextBox.Text = "A " + shiftactual.ToString();
            ShiftPlanTextBox.Text = "P " + shiftplan.ToString();
            
            if (shiftplan > 0)
            {
                OR = Math.Round((shiftactual * 100.0 / shiftplan), 2);
                ShiftORTextBox.Text = OR.ToString()+"%";
            }


            ShiftORTextBox.Text = OR.ToString() + "%";
            if (OR >= 0 && OR < Rmax)
            {
                
                ShiftORTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("Red");
                ShiftSmiley.ImageUrl = "~/Images/RED_SMILEY.png";
                

            }
            else if (OR >= Omin && OR < Omax)
            {
                
                ShiftORTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("OrangeRed");
                
                ShiftSmiley.ImageUrl = "~/Images/OrangeSmiley_small.png";
                


            }

            else if (OR >= Gmin && OR <= Gmax)
            {
                
                ShiftORTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("Lime");
                
                
                ShiftSmiley.ImageUrl = "~/Images/GREENSMILEY_small.png";
            }
            else if (OR > Gmax)
            {
                
                ShiftORTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                
                
                ShiftSmiley.ImageUrl = "";
                
            }


            if (off != null)
            {
                SystimeTextBox.BackColor = Color.Blue;
                SessionSmiley.ImageUrl = "~/Images/STOP.png";
                return;
            }
            else if (stop != null)
            {
                SystimeTextBox.BackColor = Color.Red;
            }

            else if (s.inBreak())
                SystimeTextBox.BackColor = Color.Blue;
            else
                SystimeTextBox.BackColor = Color.Lime;
             }

        }

       
    }
}