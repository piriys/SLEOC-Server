using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SLEOC.Helpers;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Globalization;
using System.Net;
using SLEOC.Models;

namespace SLEOC.Controllers
{
    public class SLCardController : Controller
    {
        public ActionResult Load(string encrypted)
        {
            string decrypted = Helpers.XOR.Decrypt(encrypted, Helpers.Constants.XORAppKey);
            string scriptURL = HttpUtility.UrlDecode(decrypted);
            try
            {
                using (var client = new WebClient())
                {
                    string json = @client.DownloadString(scriptURL);
                    JObject cardInfo = JObject.Parse(json);
                    string cardType = cardInfo["type"].ToString();
                    if (Helpers.Constants.CardTypes.Contains(cardType))
                    {
                        return RedirectToAction(cardType, "SLCard", new { encrypted = encrypted });
                    }
                    else
                    {
                        return RedirectToAction("Error");
                    }
                }
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult Comments(string encrypted)
        {
            encrypted = Helpers.XOR.Decrypt(encrypted, Helpers.Constants.XORAppKey);
            string scriptURL = HttpUtility.UrlDecode(encrypted);
            CardMosaicListModel model = new CardMosaicListModel();

            try
            {
                using (var client = new WebClient())
                {
                    string json = @client.DownloadString(scriptURL);
                    JObject cardInfo = JObject.Parse(json);
                    return PartialView();
                }
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult Error()
        {
            return PartialView();
        }

        public ActionResult Author(string encrypted)
        {
            encrypted = Helpers.XOR.Decrypt(encrypted, Helpers.Constants.XORAppKey);
            string scriptURL = HttpUtility.UrlDecode(encrypted);
            CardAuthorModel model = new CardAuthorModel();

            try
            {
                using (var client = new WebClient())
                {
                    string json = @client.DownloadString(scriptURL);
                    JObject cardInfo = JObject.Parse(json);
                    string cardType = cardInfo["type"].ToString();
                    if (cardType.ToLower() == "author")
                    {
                        model = cardInfo["parameters"].ToObject<CardAuthorModel>();
                        return PartialView(model);
                    }
                    else
                    {
                        return RedirectToAction("Error");
                    }
                }
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult Hybrid(string encrypted)
        {
            encrypted = Helpers.XOR.Decrypt(encrypted, Helpers.Constants.XORAppKey);
            string scriptURL = HttpUtility.UrlDecode(encrypted);
            CardHybridModel model = new CardHybridModel();

            try
            {
                using (var client = new WebClient())
                {
                    string json = @client.DownloadString(scriptURL);
                    JObject cardInfo = JObject.Parse(json);
                    string cardType = cardInfo["type"].ToString();
                    if (cardType.ToLower() == "hybrid")
                    {
                        model = cardInfo["parameters"].ToObject<CardHybridModel>();
                        return PartialView(model);
                    }
                    else
                    {
                        return RedirectToAction("Error");
                    }
                }
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult HybridMosaic(string encrypted)
        {
            encrypted = Helpers.XOR.Decrypt(encrypted, Helpers.Constants.XORAppKey);
            string scriptURL = HttpUtility.UrlDecode(encrypted);
            CardHybridMosaicModel model = new CardHybridMosaicModel();

            try
            {
                using (var client = new WebClient())
                {
                    string json = @client.DownloadString(scriptURL);
                    JObject cardInfo = JObject.Parse(json);
                    string cardType = cardInfo["type"].ToString();
                    if (cardType.ToLower() == "hybridmosaic")
                    {
                        model = cardInfo["parameters"].ToObject<CardHybridMosaicModel>();
                        return PartialView(model);
                    }
                    else
                    {
                        return RedirectToAction("Error");
                    }
                }
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult List(string encrypted)
        {
            encrypted = Helpers.XOR.Decrypt(encrypted, Helpers.Constants.XORAppKey);
            string scriptURL = HttpUtility.UrlDecode(encrypted);
            CardListModel model = new CardListModel();

            try
            {
                using (var client = new WebClient())
                {
                    string json = @client.DownloadString(scriptURL);
                    JObject cardInfo = JObject.Parse(json);
                    string cardType = cardInfo["type"].ToString();
                    if (cardType.ToLower() == "list")
                    {
                        model = cardInfo["parameters"].ToObject<CardListModel>();
                        return PartialView(model);
                    }
                    else
                    {
                        return RedirectToAction("Error");
                    }
                }
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult MosaicList(string encrypted)
        {
            encrypted = Helpers.XOR.Decrypt(encrypted, Helpers.Constants.XORAppKey);
            string scriptURL = HttpUtility.UrlDecode(encrypted);
            CardMosaicListModel model = new CardMosaicListModel();
            
            try
            {
                using (var client = new WebClient())
                {
                    string json = @client.DownloadString(scriptURL);
                    JObject cardInfo = JObject.Parse(json);
                    string cardType = cardInfo["type"].ToString();
                    if(cardType.ToLower() == "mosaiclist")
                    {
                        model = cardInfo["parameters"].ToObject<CardMosaicListModel>();
                        return PartialView(model);
                    }
                    else
                    {
                        return RedirectToAction("Error");
                    }
                }
            }
            catch 
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult MosaicText(string encrypted)
        {
            encrypted = Helpers.XOR.Decrypt(encrypted, Helpers.Constants.XORAppKey);
            string scriptURL = HttpUtility.UrlDecode(encrypted);
            CardMosaicTextModel model = new CardMosaicTextModel();

            try
            {
                using (var client = new WebClient())
                {
                    string json = @client.DownloadString(scriptURL);
                    JObject cardInfo = JObject.Parse(json);
                    string cardType = cardInfo["type"].ToString();
                    if (cardType.ToLower() == "mosaictext")
                    {
                        model = cardInfo["parameters"].ToObject<CardMosaicTextModel>();
                        return PartialView(model);
                    }
                    else
                    {
                        return RedirectToAction("Error");
                    }
                }
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult Text(string encrypted)
        {
            encrypted = Helpers.XOR.Decrypt(encrypted, Helpers.Constants.XORAppKey);
            string scriptURL = HttpUtility.UrlDecode(encrypted);
            CardTextModel model = new CardTextModel();

            try
            {
                using (var client = new WebClient())
                {
                    string json = @client.DownloadString(scriptURL);
                    JObject cardInfo = JObject.Parse(json);
                    string cardType = cardInfo["type"].ToString();
                    if (cardType.ToLower() == "text")
                    {
                        model = cardInfo["parameters"].ToObject<CardTextModel>();
                        return PartialView(model);
                    }
                    else
                    {
                        return RedirectToAction("Error");
                    }
                }
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult Video(string encrypted)
        {
            encrypted = Helpers.XOR.Decrypt(encrypted, Helpers.Constants.XORAppKey);
            string scriptURL = HttpUtility.UrlDecode(encrypted);
            CardVideoModel model = new CardVideoModel();

            try
            {
                using (var client = new WebClient())
                {
                    string json = @client.DownloadString(scriptURL);
                    JObject cardInfo = JObject.Parse(json);
                    string cardType = cardInfo["type"].ToString();
                    if (cardType.ToLower() == "video")
                    {
                        model = cardInfo["parameters"].ToObject<CardVideoModel>();
                        return PartialView(model);
                    }
                    else
                    {
                        return RedirectToAction("Error");
                    }
                }
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }
    }
}
