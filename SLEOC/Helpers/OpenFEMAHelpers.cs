using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using SLEOC.Models.OpenFEMA;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace SLEOC.Helpers
{
    public static class OpenFEMAHelpers
    {
        //string state - Full State Name
        public static IList<HazardMitigationGrant> GetHazardMitigationGrantsByState(string state)
        {
            IList<HazardMitigationGrant> grants = new List<HazardMitigationGrant>();

            using (var client = new WebClient())
            {
                string json = @client.DownloadString("http://www.fema.gov/api/open/v1/HazardMitigationGrants?$format=json&$filter=state eq '" + state + "'");
                JObject openFEMAResults = JObject.Parse(json);
                IList<JToken> results = openFEMAResults["HazardMitigationGrants"].ToList();

                foreach(JToken result in results)
                {
                    HazardMitigationGrant grant = JsonConvert.DeserializeObject<HazardMitigationGrant>(result.ToString());
                    grants.Add(grant);
                }
            }

            return grants;
        }

        //string state - State Abbriviation
        public static IList<DisasterDeclaration> GetDisasterDeclarationsByState(string state)
        {
            IList<DisasterDeclaration> declarations = new List<DisasterDeclaration>();

            using (var client = new WebClient())
            {
                string json = @client.DownloadString("http://www.fema.gov/api/open/v1/DisasterDeclarationsSummaries?$format=json&$filter=state eq '" + state + "'");
                JObject openFEMAResults = JObject.Parse(json);
                IList<JToken> results = openFEMAResults["DisasterDeclarationsSummaries"].ToList();

                foreach (JToken result in results)
                {
                    DisasterDeclaration declaration = JsonConvert.DeserializeObject<DisasterDeclaration>(result.ToString());
                    declarations.Add(declaration);
                }
            }

            return declarations;
        }
    }
}