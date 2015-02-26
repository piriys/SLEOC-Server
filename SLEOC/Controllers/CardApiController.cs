using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.SignalR;
using System.Web;

namespace SLEOC.Controllers
{
    public class CardApiController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage AddCard(string type = "text", string key = "public", string encrypted = "")
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<CardHub>();
            hubContext.Clients.Group(key).addCard(type, encrypted);
            hubContext.Clients.Group(key).log(type + " Card added");
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }

        [HttpPost]
        public HttpResponseMessage SetScriptUrl(string key = "public", string encrypted = "")
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<CardHub>();
            encrypted = Helpers.XOR.Decrypt(encrypted, Helpers.Constants.XORAppKey);
            string url = HttpUtility.UrlDecode(encrypted);
            
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string regionName = response.GetResponseHeader("X-SecondLife-Region");
                response.Close();
                hubContext.Clients.Group(key).log("Script URL Recieved. Region Name: " + regionName);
                hubContext.Clients.Group(key).setScriptUrl(url, regionName);
                return Request.CreateResponse(HttpStatusCode.Accepted);
            }
            catch
            {
                hubContext.Clients.Group(key).log("Script URL Error.");
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
