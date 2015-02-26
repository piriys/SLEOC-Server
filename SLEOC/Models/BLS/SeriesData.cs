using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLEOC.Models.BLS
{
    public class SeriesData
    {
        public int year { get; set; }
        public string period { get; set; }
        public string periodName { get; set; }
        public float value { get; set; }
        //public IList<string> footnotes { get; set; }

        public SeriesData()
        {
            //footnotes = new List<string>();
        }
    }
}