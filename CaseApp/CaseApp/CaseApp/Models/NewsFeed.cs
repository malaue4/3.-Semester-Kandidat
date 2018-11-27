using System;
using System.Collections.Generic;
using System.Text;

namespace CaseApp.Models
{
    public class NewsFeed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Uri RssFeedAddress { get; set; }
    }
}
