using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManufactureMonitor.Entity
{
    public class Parameter
    {
        public float TOS { get; set; }
        public String Pulses { get; set; }
        public String Pieces { get; set; }
        public float Rmin { get; set; }
        public float Rmax { get; set; }
        public float Omin { get; set; }
        public float Omax { get; set; }
        public float Gmin { get; set; }
        public float Gmax { get; set; }
        public Parameter(float tos, String pulses, String pieces, float rmin, float rmax, float omin, float omax, float gmin, float gmax)
        {
            TOS = tos;
            Pulses = pulses;
            Pieces = pieces;
            Rmin = rmin;
            Rmax = rmax;
            Omin = omin;
            Omax = omin;
            Gmin = gmin;
            Gmax = gmax;
        }
    }
    
}