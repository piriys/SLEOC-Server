using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLEOC.Models
{
    public class CardMosaicModel : Card
    {
        public string Title { get; set; }
        public List<string> ListImageURLs { get; set; }
        public List<string> ListLabels {get; set;}
        public List<string> ListItems { get; set; }
        
        public CardMosaicModel()
        {
            Title = "&lt;span class=&quot;muted&quot;&gt;Title&lt;/span&gt;";
            string[] listLabelsArray = { "&lt;span class=&quot;white&quot;&gt;Label One&lt;/span&gt;", 
                                          "&lt;span class=&quot;gray&quot;&gt;Label Two&lt;/span&gt;", 
                                          "&lt;span class=&quot;blue&quot;&gt;Label Three&lt;/span&gt;",
                                          "&lt;span class=&quot;red&quot;&gt;Label Four&lt;/span&gt;",
                                          "&lt;span class=&quot;green&quot;&gt;Label Five&lt;/span&gt;",
                                          "&lt;span class=&quot;yellow&quot;&gt;Label Six&lt;/span&gt;"
                                      };
            string[] listItemsArray = { "&lt;span class=&quot;white&quot;&gt;One&lt;/span&gt;", 
                                          "&lt;span class=&quot;gray&quot;&gt;Two&lt;/span&gt;", 
                                          "&lt;span class=&quot;blue&quot;&gt;Three&lt;/span&gt;",
                                          "&lt;span class=&quot;red&quot;&gt;Four&lt;/span&gt;",
                                          "&lt;span class=&quot;green&quot;&gt;Five&lt;/span&gt;",
                                          "&lt;span class=&quot;yellow&quot;&gt;Six&lt;/span&gt;"
                                      };

            ListImageURLs = new List<string>();
            ListLabels = new List<string>(listLabelsArray).ToList();
            ListItems = new List<string>(listItemsArray).ToList();
        }
    }
}