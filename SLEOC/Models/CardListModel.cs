using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLEOC.Models
{
    public class CardListModel : Card
    {
        public List<string> Item { get; set; }

        public CardListModel()
        {
            Item = new List<string>();
        }
    }
}