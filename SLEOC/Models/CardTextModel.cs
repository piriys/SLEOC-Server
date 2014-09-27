using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLEOC.Models
{
    public class CardTextModel : Card
    {
        public string Title {get; set;}
        public string Description {get; set;}

        public CardTextModel()
        {
            Title = "&lt;span class=&quot;muted&quot;&gt;Title&lt;/span&gt;";
            Description = "Description";
        }
    }
}