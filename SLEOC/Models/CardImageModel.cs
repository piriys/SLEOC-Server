using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Helpers;

namespace SLEOC.Models
{
    public class CardImageModel : Card
    {
        public string ImageURL { get; set; }
        public string Description { get; set; }
        
        public CardImageModel()
        {
            Description = "Description";
        }
    }
}