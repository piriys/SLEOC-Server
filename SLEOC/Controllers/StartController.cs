using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SLEOC.Models;
using System.Globalization;
using SLEOC.Models.SL;

namespace SLEOC.Controllers
{
    public class StartController : Controller
    {
        /*
         * To Do:
         * -Encrypt key to prevent collision, key parameter is now only for testing convenience in browser
         */
        public ActionResult Interface(string key = "public", string encrypted = "")
        {
            ViewBag.Key = key;

            string userAgent = Request.UserAgent;
            
            InterfaceModel model = new InterfaceModel();
            model.ConnectedFromSL = userAgent.Contains("SecondLife");

            if (!model.ConnectedFromSL)
            {
                ViewBag.UserAgentColor = "red";
            }
            else
            {
                userAgent = userAgent.Substring(userAgent.IndexOf("SecondLife"));
                userAgent = userAgent.Substring(0, userAgent.IndexOf(" "));
                ViewBag.UserAgentColor = "green";
            }

            ViewBag.UserAgent = userAgent;

            encrypted = Helpers.XOR.Decrypt(encrypted, Helpers.Constants.XORAppKey);
            string parameterString = HttpUtility.UrlDecode(encrypted);

            List<string> parameterList = parameterString.Split('&').ToList();

            string scriptUrl = model.ScriptUrl;
            if (parameterList.Exists(s => s.StartsWith("scripturl=", false, new CultureInfo("en-US"))))
            {
                scriptUrl = parameterList.Find(s => s.StartsWith("scripturl=", false, new CultureInfo("en-US"))).Substring(10);
            }
            model.ScriptUrl = scriptUrl;

            ScriptInfo info = Helpers.SLHelpers.GetScriptInfo(scriptUrl);
            if(info != null)
            {
                model.StartingRegion = info.Region;
            }

            string avatarName = model.AvatarName;
            if (parameterList.Exists(s => s.StartsWith("avatarname=", false, new CultureInfo("en-US"))))
            {
                avatarName = parameterList.Find(s => s.StartsWith("avatarname=", false, new CultureInfo("en-US"))).Substring(11);
            }
            model.AvatarName = avatarName;
            model.AvatarImageUrl = Helpers.SLHelpers.GetProfileImageURLFromName(model.AvatarName);

            return View(model);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
