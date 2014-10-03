using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.SignalR;

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
            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}
