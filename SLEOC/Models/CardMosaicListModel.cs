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
            Title = "&lt;span class=&quot;muted&quot;&gt;Title&lt;/span&gt;";
            string[] LabelArray = { "&lt;span class=&quot;white&quot;&gt;Label One&lt;/span&gt;", 
                                          "&lt;span class=&quot;gray&quot;&gt;Label Two&lt;/span&gt;", 
                                          "&lt;span class=&quot;blue&quot;&gt;Label Three&lt;/span&gt;",
                                          "&lt;span class=&quot;red&quot;&gt;Label Four&lt;/span&gt;",
                                          "&lt;span class=&quot;green&quot;&gt;Label Five&lt;/span&gt;",
                                          "&lt;span class=&quot;yellow&quot;&gt;Label Six&lt;/span&gt;"
                                      };
            string[] ItemArray = { "&lt;span class=&quot;white&quot;&gt;One&lt;/span&gt;", 
                                          "&lt;span class=&quot;gray&quot;&gt;Two&lt;/span&gt;", 
                                          "&lt;span class=&quot;blue&quot;&gt;Three&lt;/span&gt;",
                                          "&lt;span class=&quot;red&quot;&gt;Four&lt;/span&gt;",
                                          "&lt;span class=&quot;green&quot;&gt;Five&lt;/span&gt;",
                                          "&lt;span class=&quot;yellow&quot;&gt;Six&lt;/span&gt;"
                                      };

            ImageURL = new List<string>();
            Label = new List<string>(LabelArray).ToList();
            Item = new List<string>(ItemArray).ToList();
        }
    }
}