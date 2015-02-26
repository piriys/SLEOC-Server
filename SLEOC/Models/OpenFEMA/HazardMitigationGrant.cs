using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLEOC.Models.OpenFEMA
{
    public class HazardMitigationGrant
    {
        public string id { get; set; }
        public int costSharePercentage { get; set; }
        public DateTime declarationDate { get; set; }
        public int disasterNumber { get; set; }
        public string disasterTitle { get; set; }
        public string incidentType { get; set; }
        public int projectAmount { get; set; }
        public string projectCounties { get; set; }
        public string projectDescription { get; set; }
        public string projectNumber { get; set; }
        public string projectType { get; set; }
        public string region { get; set; }
        public string state { get; set; }
        public string status { get; set; }
        public string subgrantee { get; set; }
        public int subgranteeFIPSCode { get; set; }
    }
}