using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLEOC.Models.OpenFEMA
{
    public class DisasterDeclaration
    {
        public string id { get; set; }
        public DateTime declarationDate { get; set; }
        public string declaredCountyArea { get; set; }
        public DateTime disasterCloseOutDate { get; set; }
        public int disasterNumber { get; set; }
        public string disasterType { get; set; }
        public bool hmProgramDeclared { get; set; }
        public bool iaProgramDeclared { get; set; }
        public bool ihProgramDeclared { get; set; }
        public DateTime incidentBeginDate { get; set; }
        public DateTime incidentEndDate { get; set; }
        public string incidentType { get; set; }
        public bool paProgramDeclared { get; set; }
        public string state { get; set; }
        public string title { get; set; }
    }
}