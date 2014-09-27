using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLEOC.Models
{
    public class Card
    {
        public string LeftFooter { get; set; }
        public Boolean ShowLeftFooter { get; set; }
        public string RightFooter { get; set; }
        public Boolean ShowRightFooter { get; set; }

        public Card()
        {
            LeftFooter = "&lt;span class=&quot;muted&quot;&gt;Footer&lt;/span&gt;";
            ShowLeftFooter = false;
            RightFooter = DateTime.Now.ToShortTimeString();
            ShowRightFooter = false;
        }
    }
}