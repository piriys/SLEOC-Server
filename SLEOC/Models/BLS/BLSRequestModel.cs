using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLEOC.Models.BLS
{
    public class BLSRequestModel
    {
        public IList<string> seriesid { get; set; }
        public int startyear { get; set; }
        public int endyear { get; set; }
        public bool catalog { get; set; }
        public bool calculations { get; set; }
        public bool annualaverage { get; set; }
        public string registrationKey { get; set; }

        public BLSRequestModel()
        {
            seriesid = new List<string>();
            registrationKey = "6a95c4135ed142e588b4766f45c4bd3e";
            startyear = DateTime.Now.Year - 3;
            endyear = DateTime.Now.Year;
            catalog = false;
            calculations = false;
            annualaverage = false;
        }
    }
}