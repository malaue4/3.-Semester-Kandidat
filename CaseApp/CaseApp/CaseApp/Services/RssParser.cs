using CaseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;

namespace CaseApp.Services
{
    class RssParser
    {
        public async Task<List<Article>> ParseFeed(string rss)
        {
            return await Task.Run(() =>
                {
                    var xdoc = XDocument.Load(rss);
                    var channel = xdoc.Descendants("channel").First();
                    NewsFeed newsfeed = new NewsFeed
                    {
                        Title = (string)channel.Element("title"),
                        Description = (string)channel.Element("description"),
                        Link = new Uri((string)channel.Element("link")),
                        Icon = ImageSource.FromFile("doc512.png")
                    };
                    return (from item in xdoc.Descendants("item")
                            select new Article
                            {
                                Title = (string)item.Element("title"),
                                Description = (string)item.Element("description"),
                                Link = new Uri((string)item.Element("link")),
                                PublishDate = DateTime.Parse((string)item.Element("pubDate")),
                                Author = (string)item.Element("author"),
                                Source = newsfeed
                            }).ToList();
                });
        }
    }
}
