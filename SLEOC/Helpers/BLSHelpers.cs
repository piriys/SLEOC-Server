using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using SLEOC.Models.BLS;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Specialized;
using System.Text;

namespace SLEOC.Helpers
{
    public static class BLSHelpers
    {
        public static IList<SeriesData> GetBLSSeries(BLSRequestModel model)
        {
            IList<SeriesData> series = new List<SeriesData>();

            using (var client = new WebClient())
            {
                client.Headers["Content-Type"] = "application/json";          
                string requestJson = JsonConvert.SerializeObject(model);
                byte[] bytes = client.UploadData("http://api.bls.gov/publicAPI/v2/timeseries/data/", Encoding.UTF8.GetBytes(requestJson));
                string responseJson = Encoding.UTF8.GetString(bytes);
                JObject BLSResults = JObject.Parse(responseJson);
                IList<JToken> results = BLSResults["Results"]["series"][0]["data"].ToList();

                foreach (JToken result in results)
                {
                    SeriesData data = JsonConvert.DeserializeObject<SeriesData>(result.ToString());
                    series.Add(data);
                }
            }

            return series; 
        }
    }
}