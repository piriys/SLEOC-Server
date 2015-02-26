using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLEOC.Models
{
    public class InterfaceModel
    {
        public string ScriptUrl { get; set; }
        public string AvatarName { get; set; }
        public string StartingRegion { get; set; }
        public bool ConnectedFromSL { get; set; }
        public string AvatarImageUrl { get; set;  }

        public InterfaceModel()
        {
            ScriptUrl = "";
            AvatarName = "Unknown Avatar";
            StartingRegion = "Unknown Region";
            ConnectedFromSL = false;
            AvatarImageUrl = "https://d2mjw3k7q9u8rb.cloudfront.net/images/default/avatar_thumb.png";
        }
    }
}