using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using SLEOC.Models;
using SLEOC.Helpers;

namespace SLEOC.Controllers
{
    public class CardController : Controller
    {
        public ActionResult Event(CardEventModel model)
        {
            model.Title = HttpUtility.HtmlDecode(model.Title);
            model.Description = HttpUtility.HtmlDecode(model.Description);
            model.FooterLeft = HttpUtility.HtmlDecode(model.FooterLeft);
            model.FooterRight = HttpUtility.HtmlDecode(model.FooterRight);

            return PartialView(model);
        }
        
        public ActionResult List(CardListModel model)
        {
            for(int i = 0; i < model.ListItems.Count; i++)
            {
                model.ListItems[i] = HttpUtility.HtmlDecode(model.ListItems[i]);
            }

            model.FooterLeft = HttpUtility.HtmlDecode(model.FooterLeft);
            model.FooterRight = HttpUtility.HtmlDecode(model.FooterRight);

            return PartialView(model);
        }

        public ActionResult Image(CardImageModel model)
        {
            if (String.IsNullOrEmpty(model.ImageURL))
            {
                model.ImageURL = Url.Content("~/Content/images/defaultimage.png");
            }

            model.Description = HttpUtility.HtmlDecode(model.Description);
            model.FooterLeft = HttpUtility.HtmlDecode(model.FooterLeft);
            model.FooterRight = HttpUtility.HtmlDecode(model.FooterRight);

            return PartialView(model);
        }

        public ActionResult Mosaic(CardMosaicModel model)
        {
            model.Title = HttpUtility.HtmlDecode(model.Title);

            if (model.ListImageURLs.Count == 0)
            {
                model.ListImageURLs.Add(Url.Content("~/Content/images/defaultimage.png"));
                model.ListImageURLs.Add(Url.Content("~/Content/images/defaultimage.png"));
                model.ListImageURLs.Add(Url.Content("~/Content/images/defaultimage.png"));
            }

            for (int i = 0; i < model.ListItems.Count; i++)
            {
                model.ListItems[i] = HttpUtility.HtmlDecode(model.ListItems[i]);
            }

            for (int i = 0; i < model.ListLabels.Count; i++)
            {
                model.ListLabels[i] = HttpUtility.HtmlDecode(model.ListLabels[i]);
            }

            model.FooterLeft = HttpUtility.HtmlDecode(model.FooterLeft);
            model.FooterRight = HttpUtility.HtmlDecode(model.FooterRight);

            return PartialView(model);
        }
    }
}
