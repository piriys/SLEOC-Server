using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLEOC.Models
{
    public class CardMosaicListModel : Card
    {
        public string Title { get; set; }
        public List<string> ImageURL { get; set; }
        public List<string> Label {get; set;}
        public List<string> Item { get; set; }
        
        public CardMosaicListModel()
        {
            Title = "Title";
            ImageURL = new List<string>();
            Label = new List<string>();
            Item = new List<string>();
        }
    }
}