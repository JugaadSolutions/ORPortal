using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManufactureMonitor.Entity
{
    public class ShiftHistory
    {
        public string Project {get;set;}
        public String From { get; set; }
        public String To { get; set; }
        public double CycleTime { get; set; }
        public int Actual { get; set; }
        public int Scraps { get; set; }
        public double LoadTime { get; set; }
        public double Nop1 { get; set; }
        public double Nop2 { get; set; }
        public double Nop2_1 { get; set; }
        public double Nop2_2 { get; set; }
        public double Nop2_3 { get; set; }
        public double Nop2_4 { get; set; }
        public double Undefined {get;set;}
        public double Idle { get; set; }
        public double KR { get; set; }
        public double BKR { get; set; }
        public double OK { get; set; }
        public String Date { get; set; }

        public String GetFromDate()
        {
            DateTime from = DateTime.Parse(From);
            Date =  from.ToString("dd-MMM-yyyy");
            return Date;
        }

    }


    public class ShiftHistory_Summary
    {
        private ShiftHistory shiftHistory;
        private List<ShiftHistory> list;

        public static ShiftHistory_Summary ShiftHistory_SummaryTotal(List<ShiftHistory_Summary> summaryList )
        {
            ShiftHistory_Summary su = new ShiftHistory_Summary();
            foreach(ShiftHistory_Summary s in summaryList)
            {
                su.Actual += s.Actual;
                su.Scraps += s.Scraps;
                su.LoadTime += s.LoadTime;
                su.Nop1 += s.Nop1;
                su.Nop2 += s.Nop2;
                su.Undefined += s.Undefined;
                su.Idle += s.Idle;
                su.KR += ((s.Actual * s.CycleTime ) );
                su.BKR +=((s.LoadTime - s.Nop1));
                
            }
            su.KR = Math.Round((su.KR / su.LoadTime )* 100, 2);
            su.BKR = Math.Round((su.BKR / su.LoadTime) * 100, 2);

            return su;
        }

        public ShiftHistory_Summary()
        {

        }
        public ShiftHistory_Summary(List<ShiftHistory> list)
        {
            Project = String.Empty;
            CycleTime = 0;
            Actual = Scraps = 0;
                LoadTime = Nop1 = Nop2 = Idle = KR = BKR = 0;

            foreach (ShiftHistory sh in list)
            {
                if (this.Project != sh.Project)
                    this.Project = sh.Project;
                if (this.CycleTime != sh.CycleTime)
                    this.CycleTime = sh.CycleTime;
                Actual += sh.Actual;
                Scraps += sh.Scraps;
                LoadTime += sh.LoadTime;
                Nop1 += sh.Nop1;
                Nop2 += sh.Nop2;
                Idle += sh.Idle;
                Undefined += sh.Undefined;

            }
            KR = Math.Round(((Actual * CycleTime) / LoadTime) * 100,2);
            BKR = Math.Round(((LoadTime - Nop1) / LoadTime) * 100,2);
        }
        public string Project { get; set; }
        public double CycleTime { get; set; }
        public int Actual { get; set; }
        public int Scraps { get; set; }
        public double LoadTime { get; set; }
        public double Nop1 { get; set; }
        public double Nop2 { get; set; }
        public double Idle { get; set; }
        public double Undefined { get; set; }
        public double KR { get; set; }
        public double BKR { get; set; }
        public String Date {get;set;}
    }

  
}