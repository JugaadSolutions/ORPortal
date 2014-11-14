using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManufactureMonitor.Entity
{
    public class TimeSequence
    {
        
        public String From { get; set; }
        public String To { get; set; }
        public int Duration { get; set; }
        public String StopType { get; set; }
        public String Problem { get; set; }
        public String Comment { get; set; }
        public String Date { get; set; }

        
    }
}