﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManufactureMonitor.Entity
{
    public class StopTimeoutArgs : EventArgs
    {
        public StopTimeoutArgs(int id)
        {
            ID = id;
        }
        public int ID { get; set; }
    }
}
