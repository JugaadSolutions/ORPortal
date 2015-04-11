using ManufactureMonitor.DALayer;
using ManufactureMonitor.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ManufactureMonitor
{
    public class DataAnalyzer
    {
        DataAccess da;

        List<Session> OffSessions;
        DataTable ProjectSessions;
        
        

        public List<ShiftHistory> ShiftHistoryList;
        public List<ShiftHistory_Summary> ShSummary;

        public List<ProblemAccumulationRecord> ProblemAccumulationList;

        List<Session> OnSessions;
        int machine;

        public DataAnalyzer(int machine)
        {
            da = new DataAccess();

            this.machine = machine;
        }

        public void CalculateShiftHistory(Shift Shift)
        {

            ShiftHistoryList =new List<ShiftHistory>();

            ProjectSessions = da.GetProjectSessions(machine, Shift);

            for (int i = 0; i < ProjectSessions.Rows.Count; i++)
            {
                ShiftHistory ShiftHistory = new Entity.ShiftHistory();
                ShiftHistory.CycleTime =(double) ProjectSessions.Rows[i]["CycleTime"];
                ShiftHistory.Scraps = (int)ProjectSessions.Rows[i]["Scraps"];
                ShiftHistory.Project = (String)ProjectSessions.Rows[i]["Project"];
                ShiftHistory.From = ProjectSessions.Rows[i]["From"].ToString();
                ShiftHistory.To = ProjectSessions.Rows[i]["To"].ToString();
                ShiftHistory.Date = Shift.Date.ToString("dd-MM-yyyy");

                DateTime ProjectSessionStart = (DateTime)ProjectSessions.Rows[i]["Start"];
                DateTime ProjectSessionEnd = (DateTime)ProjectSessions.Rows[i]["End"];

                CalculateOffOnSessions(ProjectSessionStart, ProjectSessionEnd);

                 foreach( Session session in OffSessions )
                 {
                     ShiftHistory.Idle += Shift.getActiveDuration(DateTime.Parse(session.StartTime), DateTime.Parse(session.EndTime));
                 }
                foreach( Session se in OnSessions)
                {
                    DateTime start = DateTime.Parse(se.StartTime);
                    DateTime end = DateTime.Parse(se.EndTime);
                    ShiftHistory.LoadTime+= Shift.getActiveDuration(start,end );
                    ShiftHistory.Actual += da.GetMachineInputCount(machine, start, end);
                    ShiftHistory.Nop1 += da.GetNop1Duration(machine, start, end, Shift);
                    ShiftHistory.Nop2 += da.GetNop2Duration(machine, start, end, Shift);
                    ShiftHistory.Undefined += da.GetUndefinedDuration(machine, start, end, Shift);
                }

                ShiftHistory.OK = ShiftHistory.Actual - ShiftHistory.Scraps;
                ShiftHistory.KR = Math.Round(((ShiftHistory.OK * ShiftHistory.CycleTime) / ShiftHistory.LoadTime) * 100,2);
                ShiftHistory.BKR = Math.Round(((ShiftHistory.LoadTime - ShiftHistory.Nop2) / ShiftHistory.LoadTime) * 100,2);

                ShiftHistoryList.Add(ShiftHistory);
                
            }
                

        }

        public void CalculateShiftHistorySummary(Shift Shift)
        {
            CalculateShiftHistory(Shift);
            Dictionary<String, List<ShiftHistory>> ShiftHistoryCollection = new Dictionary<string, List<ShiftHistory>>();


            foreach (ShiftHistory sh in ShiftHistoryList)
            {
                if (ShiftHistoryCollection.ContainsKey(sh.Project))
                    ShiftHistoryCollection[sh.Project].Add(sh);
                else
                {
                    List<ShiftHistory> sl = new List<Entity.ShiftHistory>();
                    sl.Add(sh);
                    ShiftHistoryCollection.Add(sh.Project, sl);
                }
            }

            ShSummary = new List<ShiftHistory_Summary>();

            foreach (KeyValuePair<string, List<ShiftHistory>> K in ShiftHistoryCollection)
            {
                ShSummary.Add(new ShiftHistory_Summary(K.Value));
            }
        }

        public void CalculateProblemAccumulation(Shift Shift)
        {
            ProblemAccumulationList = new List<ProblemAccumulationRecord>();

            ProjectSessions = da.GetProjectSessions(machine, Shift);

            for (int i = 0; i < ProjectSessions.Rows.Count; i++)
            {
                DateTime ProjectSessionStart = (DateTime)ProjectSessions.Rows[i]["Start"];
                DateTime ProjectSessionEnd = (DateTime)ProjectSessions.Rows[i]["End"];

                CalculateOffOnSessions(ProjectSessionStart, ProjectSessionEnd);


            }
        }

        void CalculateOffOnSessions(DateTime ProjectSessionStart, DateTime ProjectSessionEnd)
        {

              OffSessions = da.GetOffs(machine,  ProjectSessionStart, ProjectSessionEnd);
              OnSessions = new List<Session>();

                foreach (Session session in OffSessions)
                {
                    if (DateTime.Parse(session.StartTime) < ProjectSessionStart)
                        session.StartTime = ProjectSessionStart.ToString("yyyy-MM-dd HH:mm:ss");


                    if (DateTime.Parse(session.EndTime) > ProjectSessionEnd)
                        session.EndTime = ProjectSessionEnd.ToString("yyyy-MM-dd HH:mm:ss");
                }

                Session FirstSession = new Session();
                FirstSession.StartTime = ProjectSessionStart.ToString("yyyy-MM-dd HH:mm:ss");

                if (OffSessions.Count > 0)
                {


                    FirstSession.EndTime = (DateTime.Parse(OffSessions[0].StartTime)).ToString("yyyy-MM-dd HH:mm:ss");

                    OnSessions.Add(FirstSession);


                    int j;
                    for (j = 1; j < OffSessions.Count; j++)
                    {
                        Session OnSession = new Session();
                        OnSession.StartTime = (DateTime.Parse(OffSessions[j - 1].EndTime).ToString("yyyy-MM-dd HH:mm:ss"));
                        OnSession.EndTime = (DateTime.Parse(OffSessions[j - 1].StartTime).ToString("yyyy-MM-dd HH:mm:ss"));

                        OnSessions.Add(OnSession);
                    }

                    Session LastSession = new Session();
                    LastSession.StartTime = (DateTime.Parse(OffSessions[j - 1].EndTime).ToString("yyyy-MM-dd HH:mm:ss"));
                    LastSession.EndTime = ProjectSessionEnd.ToString("yyyy-MM-dd HH:mm:ss");


                    OnSessions.Add(LastSession);
                }
                else
                {
                    FirstSession.EndTime = ProjectSessionEnd.ToString("yyyy-MM-dd HH:mm:ss");
                    OnSessions.Add(FirstSession);
                }



        }



        

    }
}