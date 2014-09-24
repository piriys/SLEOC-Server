using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLEOC.Models
{
    public class Card
    {
        public string FooterLeft { get; set; }
        public Boolean ShowFooterLeft { get; set; }
        public string FooterRight{ get; set; }
        public Boolean ShowFooterRight { get; set; }

        public Card()
        {
            FooterLeft = "&lt;span class=&quot;muted&quot;&gt;Footer&lt;/span&gt;";
            ShowFooterLeft = false;
            FooterRight = DateTime.Now.ToShortTimeString();
            ShowFooterRight = false;
        }
    }
}