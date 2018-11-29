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
        public string Author { get; set; }
        public NewsFeed Source { get; set; }
        public Uri Link { get; set; }
        public bool Favorite { get; set; }
        public DateTime PublishDate { get; set; }
        // TODO link til den lokale storage?
    }
}
