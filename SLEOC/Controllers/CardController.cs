﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using SLEOC.Models;
using SLEOC.Helpers;
using System.Net;

namespace SLEOC.Controllers
{
    public class CardController : Controller
    {

        public ActionResult Team()
        {
            return PartialView();
        }

        public ActionResult Map()
        {
            ViewBag.MapID = System.Guid.NewGuid().ToString();
            return View();
        }

        public ActionResult DisasterDeclarationsStats(DDStatsModel model)
        {
            ViewBag.FullState = StateHelpers.StateAbbreviationExpand(model.State);

            return PartialView(model);
        }

        public ActionResult Video(CardVideoModel model)
        {
            model.Video = HttpUtility.HtmlDecode(model.Video);
            model.LeftFooter = HttpUtility.HtmlDecode(model.LeftFooter);
            model.RightFooter = HttpUtility.HtmlDecode(model.RightFooter);

            return PartialView(model);
        }

        public ActionResult Author(CardAuthorModel model)
        {
            if (String.IsNullOrEmpty(model.ImageURL))
            {
                model.ImageURL = Url.Content("~/Content/images/defaultimage.png");
            }

            if (String.IsNullOrEmpty(model.ProfileImageURL))
            {
                model.ProfileImageURL = Url.Content("~/Content/images/defaultprofileimage.png");
            }

            model.Name = HttpUtility.HtmlDecode(model.Name);
            model.Location = HttpUtility.HtmlDecode(model.Location);
            model.Description = HttpUtility.HtmlDecode(model.Description);
            model.LeftFooter = HttpUtility.HtmlDecode(model.LeftFooter);
            model.RightFooter = HttpUtility.HtmlDecode(model.RightFooter);

            return PartialView(model);
        }

        public ActionResult Text(CardTextModel model)
        {
            model.Title = HttpUtility.HtmlDecode(model.Title);
            model.Description = HttpUtility.HtmlDecode(model.Description);
            model.LeftFooter = HttpUtility.HtmlDecode(model.LeftFooter);
            model.RightFooter = HttpUtility.HtmlDecode(model.RightFooter);

            return PartialView(model);
        }
        
        public ActionResult List(CardListModel model)
        {
            for(int i = 0; i < model.Item.Count; i++)
            {
                model.Item[i] = HttpUtility.HtmlDecode(model.Item[i]);
            }

            model.LeftFooter = HttpUtility.HtmlDecode(model.LeftFooter);
            model.RightFooter = HttpUtility.HtmlDecode(model.RightFooter);

            return PartialView(model);
        }

        public ActionResult Hybrid(CardHybridModel model)
        {
            if (String.IsNullOrEmpty(model.ImageURL))
            {
                model.ImageURL = Url.Content("~/Content/images/defaultimage.png");
            }

            model.Description = HttpUtility.HtmlDecode(model.Description);
            model.LeftFooter = HttpUtility.HtmlDecode(model.LeftFooter);
            model.RightFooter = HttpUtility.HtmlDecode(model.RightFooter);

            return PartialView(model);
        }

        public ActionResult HybridMosaic(CardHybridMosaicModel model)
        {
            if (model.ImageURL.Count == 0)
            {
                model.ImageURL.Add(Url.Content("~/Content/images/defaultimage.png"));
                model.ImageURL.Add(Url.Content("~/Content/images/defaultimage.png"));
                model.ImageURL.Add(Url.Content("~/Content/images/defaultimage.png"));
            }

            model.Description = HttpUtility.HtmlDecode(model.Description);

            return PartialView(model);
        }

        public ActionResult MosaicText(CardMosaicTextModel model)
        {
            model.Title = HttpUtility.HtmlDecode(model.Title);
            model.Description = HttpUtility.HtmlDecode(model.Description);

            if (model.ImageURL.Count == 0)
            {
                model.ImageURL.Add(Url.Content("~/Content/images/defaultimage.png"));
                model.ImageURL.Add(Url.Content("~/Content/images/defaultimage.png"));
                model.ImageURL.Add(Url.Content("~/Content/images/defaultimage.png"));
            }

            model.LeftFooter = HttpUtility.HtmlDecode(model.LeftFooter);
            model.RightFooter = HttpUtility.HtmlDecode(model.RightFooter);

            return PartialView(model);
        }

        public ActionResult MosaicList(CardMosaicListModel model)
        {
            model.Title = HttpUtility.HtmlDecode(model.Title);

            if (model.ImageURL.Count == 0)
            {
                model.ImageURL.Add(Url.Content("~/Content/images/defaultimage.png"));
                model.ImageURL.Add(Url.Content("~/Content/images/defaultimage.png"));
                model.ImageURL.Add(Url.Content("~/Content/images/defaultimage.png"));
            }

            for (int i = 0; i < model.Item.Count; i++)
            {
                model.Item[i] = HttpUtility.HtmlDecode(model.Item[i]);
            }

            for (int i = 0; i < model.Label.Count; i++)
            {
                model.Label[i] = HttpUtility.HtmlDecode(model.Label[i]);
            }

            model.LeftFooter = HttpUtility.HtmlDecode(model.LeftFooter);
            model.RightFooter = HttpUtility.HtmlDecode(model.RightFooter);

            return PartialView(model);
        }
    }
}
