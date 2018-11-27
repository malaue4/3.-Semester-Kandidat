using System;
using System.Collections.Generic;
using System.Text;

namespace CaseApp.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public NewsFeed Source { get; set; }
        public Uri Link { get; set; }
        public bool Favorite { get; set; }
        // TODO link til den lokale storage?
    }
}
