using System;

namespace FransApp.Models
{
    public class Article
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public NewsFeed Source { get; set; }
        public Uri Link { get; set; }
        public bool Favorite { get; set; }
    }
}