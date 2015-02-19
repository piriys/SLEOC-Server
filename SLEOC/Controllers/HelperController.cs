using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SLEOC.Helpers;

namespace SLEOC.Controllers
{
    public class HelperController : Controller
    {
        [HttpPost]
        public JsonResult Encrypt(string text)
        {
            return Json(new { encrypted = Helpers.XOR.Encrypt(text, Helpers.Constants.XORAppKey)});
        }

        [HttpPost]
        public JsonResult Decrypt(string text)
        {
            return Json(new { decrypted = Helpers.XOR.Decrypt(text, Helpers.Constants.XORAppKey) });
        }
    }
}
