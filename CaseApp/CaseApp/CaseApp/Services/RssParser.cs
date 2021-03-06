﻿using CaseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Xamarin.Forms;

namespace CaseApp.Services
{
    class RssParser
    {
        public Task<List<Article>> ParseFeed(string rss)
        {
            return Task.Factory.StartNew(() =>
                {
                    //try
                    //{
                        XDocument xdoc = XDocument.Load(rss);
                        var channel = xdoc.Descendants("channel").First();
                        NewsFeed newsfeed = new NewsFeed
                        {
                            Title = (string)channel.Element("title"),
                            Description = (string)channel.Element("description"),
                            Link = new Uri(rss),
                            //Icon = ImageSource.FromUri(new Uri($"https://www.google.com/s2/favicons?domain={rss}"))
                        };
                    
                        return (from item in xdoc.Descendants("item")
                                select new Article
                                {
                                    Title = (string)item.Element("title"),
                                    Description = (string)item.Element("description"),
                                    Link = new Uri((string)item.Element("link")),
                                    PublishDate = DateTime.Parse(((string)item.Element("pubDate")).Replace("PST", "+0800").Replace("PDT", "+0700")),
                                    Author = (string)item.Element("author"),
                                    Source = newsfeed
                                }).ToList();
                    //}
                    //catch (XmlException)
                    //{

                    //    return null;
                    //}
                });
        }
    }
}
