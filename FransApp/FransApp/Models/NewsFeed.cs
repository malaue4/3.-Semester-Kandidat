using System;

namespace FransApp.Models
{
    public class NewsFeed
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Uri RssFeedAddress { get; set; }
    }
}