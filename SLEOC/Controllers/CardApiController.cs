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
        public HttpResponseMessage GoToCard(string key = "public", int card = 1)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<CardHub>();
            hubContext.Clients.Group(key).goToCard(card);
            hubContext.Clients.Group(key).log("move to card");
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage AddCard(string type = "text", string key = "public", string encrypted = "")
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<CardHub>();
            hubContext.Clients.Group(key).addCard(type, encrypted);
            hubContext.Clients.Group(key).log(type + " Card added");
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        //[HttpPost]
        //public HttpResponseMessage AddHybridCard(string key = "public", string encrypted = "")
        //{
        //    var hubContext = GlobalHost.ConnectionManager.GetHubContext<CardHub>();
        //    hubContext.Clients.Group(key).addHybridCard(encrypted);
        //    hubContext.Clients.Group(key).log("Hybrid Card added");
        //    return Request.CreateResponse(HttpStatusCode.Created);
        //}

        //[HttpPost]
        //public HttpResponseMessage AddHybridMosaicCard(string key = "public", string encrypted = "")
        //{
        //    var hubContext = GlobalHost.ConnectionManager.GetHubContext<CardHub>();
        //    hubContext.Clients.Group(key).addHybridMosaicCard(encrypted);
        //    hubContext.Clients.Group(key).log("Hybrid Mosaic Card added");
        //    return Request.CreateResponse(HttpStatusCode.Created);
        //}

        //[HttpPost]
        //public HttpResponseMessage AddListCard(string key = "public", string encrypted = "")
        //{
        //    var hubContext = GlobalHost.ConnectionManager.GetHubContext<CardHub>();
        //    hubContext.Clients.Group(key).addListCard(encrypted);
        //    hubContext.Clients.Group(key).log("List Card added");
        //    return Request.CreateResponse(HttpStatusCode.Created);
        //}

        //[HttpPost]
        //public HttpResponseMessage AddMosaicListCard(string key = "public", string encrypted = "")
        //{
        //    var hubContext = GlobalHost.ConnectionManager.GetHubContext<CardHub>();
        //    hubContext.Clients.Group(key).addMosaicListCard(encrypted);
        //    hubContext.Clients.Group(key).log("Mosaic List Card added");
        //    return Request.CreateResponse(HttpStatusCode.Created);
        //}

        //[HttpPost]
        //public HttpResponseMessage AddMosaicTextCard(string key = "public", string encrypted = "")
        //{
        //    var hubContext = GlobalHost.ConnectionManager.GetHubContext<CardHub>();
        //    hubContext.Clients.Group(key).addMosaicTextCard(encrypted);
        //    hubContext.Clients.Group(key).log("Mosaic Text Card added");
        //    return Request.CreateResponse(HttpStatusCode.Created);
        //}

        //[HttpPost]
        //public HttpResponseMessage AddTextCard(string key = "public", string encrypted = "")
        //{
        //    var hubContext = GlobalHost.ConnectionManager.GetHubContext<CardHub>();
        //    hubContext.Clients.Group(key).addTextCard(encrypted);
        //    hubContext.Clients.Group(key).log("Text Card added");
        //    return Request.CreateResponse(HttpStatusCode.Created);
        //}
    }
}
