using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLEOC.Models
{
    public class CardEventModel : Card
    {
        public string Title {get; set;}
        public string Description {get; set;}

        public CardEventModel()
        {
            Title = "&lt;span class=&quot;green&quot;&gt;"+  DateTime.Now.ToShortTimeString() + "&lt;/span&gt;";
            Description = "Description";
        }
    }
}