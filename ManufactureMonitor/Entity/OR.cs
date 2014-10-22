using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManufactureMonitor.Entity
{
    public class OR
    {
        public double Value { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        int MachineId { get; set; }
        Project Project { get; set; }

        
    }
}