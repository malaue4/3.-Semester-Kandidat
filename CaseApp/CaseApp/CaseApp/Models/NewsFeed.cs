using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SQLite;
using Xamarin.Forms;

namespace CaseApp.Models
{
    public class NewsFeed
    {
        private Uri _link;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string LinkString { get; set; }
        public bool Active { get; set; }

        [Ignore]
        public Uri Link
        {
            get
            {
                if(_link == null) _link = new Uri(LinkString);
                return _link;
            }
            set
            {
                _link = value;
                LinkString = value.OriginalString;
            }
        }

        public static NewsFeed From(Uri url)
        {
            var xdoc = XDocument.Load(url.OriginalString);
            var channel = xdoc.Descendants("channel").First();
            NewsFeed newsfeed = new NewsFeed
            {
                Title = (string)channel.Element("title"),
                Description = (string)channel.Element("description"),
                Link = new Uri((string)channel.Element("link")),
                //Icon = ImageSource.FromUri(new Uri($"https://www.google.com/s2/favicons?domain={rss}"))
            };
            return newsfeed;

        }
    }
}
