using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLEOC.Models
{
    public class CardHybridMosaicModel : Card
    {
        public List<string> ImageURL { get; set; }
        public string Description { get; set; }
        
        public CardHybridMosaicModel()
        {
            ImageURL = new List<string>();
            Description = "Description";
        }
    }
}