using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLEOC.Models
{
    public class DDStatsModel
    {
        public string State { get; set; }
        
        public DDStatsModel()
        {
            State = "Unknown";
        }
    }
}