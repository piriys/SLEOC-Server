using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLEOC.Models
{
    public class CardMosaicTextModel : Card
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> ImageURL { get; set; }

        public CardMosaicTextModel()
        {
            Title = "Title";
            Description = "Description";
            ImageURL = new List<string>();
        }
    }
}