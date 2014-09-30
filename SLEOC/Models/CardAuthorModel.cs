using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLEOC.Models
{
    public class CardAuthorModel : Card
    {
        public string ProfileImageURL { get; set; }
        public string ImageURL { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        
        public CardAuthorModel()
        {
            Name = "Name";
            Location = "Location";
            Description = "Description";
        }
    }
}