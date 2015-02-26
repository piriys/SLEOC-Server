using SLEOC.Models.SL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace SLEOC.Helpers
{
    public static class SLHelpers
    {
        public static string GetProfileImageURLFromName(string name)
        {
            try
            {
                string url = "https://my-secondlife.s3.amazonaws.com/users/"+ name +"/thumb_sl_image.png";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                return url;
            }
            catch
            {
                return "https://d2mjw3k7q9u8rb.cloudfront.net/images/default/avatar_thumb.png";
            }
        }

        public static ScriptInfo GetScriptInfo(string url)
        {
            ScriptInfo info = new ScriptInfo();

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                info.Owner = response.GetResponseHeader("X-SecondLife-Owner-Name");
                info.Region = response.GetResponseHeader("X-SecondLife-Region");
                info.Server = response.GetResponseHeader("Server");
                return info;
            }
            catch
            {
                return null;
            }
        }
    }
}