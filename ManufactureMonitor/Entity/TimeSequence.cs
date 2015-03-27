using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManufactureMonitor.Entity
{
    public class TimeSequence
    {
        public int SlNo { get; set; }
        public int Machine_Id { get; set; }
        public String From { get; set; }
        public String To { get; set; }
        public int Duration { get; set; }
        public String StopType { get; set; }
        public String Problem { get; set; }
        public String Comment { get; set; }
        public String Date { get; set; }
        public int ProblemCode { get; set; }


        public double GetDuration()
        {
            DateTime from = DateTime.Parse(From);
            DateTime to = DateTime.Parse(To);

            return (to - from).TotalSeconds;
        }
    }

    public class ProblemAccumulationRecord
    {
        public int ProblemCode { get; set; }
        public String ProblemDescription { get; set; }
        public double TimeDuration { get; set; }
        public double TimePercentage { get; set; }
        public int Count { get; set; }
        public String From { get; set; }
        public String To { get; set; }
        public String Date { get; set; }
    }
}