using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLEOC.Models.SL
{
    public class ScriptInfo
    {
        public string Owner { get; set; }
        public string Region { get; set; }
        public string Server { get; set; }

        public ScriptInfo()
        {
            Owner = "Unknown";
            Region = "Unknown";
            Server = "Unknown";
        }
    }
}