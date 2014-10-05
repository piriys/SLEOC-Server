using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLEOC.Models
{
    public class CardVideoModel : Card
    {
        public string Video { get; set; }
        public bool Autoplay { get; set; }

        public CardVideoModel()
        {
            Video = "4EvNxWhskf8";
            Autoplay = true;
        }
    }
}