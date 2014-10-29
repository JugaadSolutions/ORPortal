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
             s.Breaks = da.getSessions(s.ID, machine);

             if (s.IsActive == false) SystimeTextBox.BackColor = Color.DarkGray;
             else if (s.inBreak()) SystimeTextBox.BackColor = Color.DarkBlue;

            Session se =  s.getSession(now);

            DateTime seStart = DateTime.Parse(se.StartTime);

            TimeIntervalLabel.Text = "Actual Time Interval  " + seStart.ToString("HH:mm") + "-" + now.ToString("HH:mm");

            DateTime shStart = DateTime.Parse(s.StartTime);

            ShiftLabel.Text = "Actual Shift  " + shStart.ToString("HH:mm") + "-" + now.ToString("HH:mm");

            int seplan = da.getSessionActual(se, machine);
            int seactual = da.getSessionPlan(se, machine);

            if( seplan == 0 ) 

            SessionActualTextBox.Text = "A " + seactual.ToString();
            SessionPlanTextBox.Text = "P " + seplan.ToString();


            



        }

    }
}