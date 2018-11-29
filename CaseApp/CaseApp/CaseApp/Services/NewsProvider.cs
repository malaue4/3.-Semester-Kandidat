using CaseApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CaseApp.Services
{
    class NewsProvider
    {
        public ObservableCollection<Article> Articles = new ObservableCollection<Article>();
        private static NewsProvider _instance = new NewsProvider();
        public static NewsProvider GetProvider() => _instance;

        private NewsProvider()
        {
            LoadSampleData();
        }

        private async void LoadSampleData()
        {
            //var feed = new WebClient().DownloadString("https://visualstudiomagazine.com/rss-feeds/columns.aspx");
            var articles = await (new RssParser().ParseFeed("https://visualstudiomagazine.com/rss-feeds/columns.aspx"));
            foreach (var article in articles)
            {
                Articles.Add(article);
            }
            /*
            var collection = new ObservableCollection<Article>();
            for (int i = 0; i < 10; i++)
            {
                collection.Add(new Article
                {
                    Title=$"Item {i}",
                    Description="This is an item",
                    Favorite=true
                });
            }*/
        }

        public List<Article> GetNews()
        {
            return Articles.ToList();
        }

        public List<Article> GetFavorites()
        {
            return Articles.Where(article => article.Favorite).ToList();
        }

        /*
        */
    }
}
