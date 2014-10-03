using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SLEOC.Helpers;

namespace SLEOC.Controllers
{
    public class HelperApiController : ApiController
    {
        [HttpGet]
        public string Encrypt (string text)
        {
            return Helpers.XOR.Encrypt(text, Helpers.Constants.XORAppKey);
        }

        [HttpGet]
        public string Decrypt(string text)
        {
            return Helpers.XOR.Decrypt(text, Helpers.Constants.XORAppKey);
        }
    }
}
