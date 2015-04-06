using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLEOC.Models.GeoJson
{
    /*
     * API: http://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
     */
  
    public class Earthquake
    {
    }

    public class metadata
    {
        public long generated { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string api { get; set; }
        public int count { get; set; }
    }

    public class bbox
    {

    }

    public class feature
    {
        public properties properties { get; set; }
        public string id { get; set; }
    }

    public class properties
    {
        public decimal mag { get; set; }
        public string place { get; set; }
        public long time { get; set; }
        public long updated { get; set; }
        public int tz { get; set; }
        public string url { get; set; }
        public string detail { get; set; }
        public int felt { get; set; }
        public decimal cdi { get; set; }
        public decimal mmi { get; set; }
        public string alert { get; set; }
        public string status { get; set; }
        public int tsunami { get; set; }
        public int sig { get; set; }
        public string net { get; set; }
        public string code { get; set; }
        public string ids { get; set; }
        public string sources { get; set; }
        public string types { get; set; }
        public int nst { get; set; }
        public decimal dmin { get; set; }
        public decimal gap { get; set; }
        public string magType { get; set; }
        public string type { get; set; }
    }

    public class geometry
    {

    }
}