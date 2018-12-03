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
        public List<Article> Articles;
        private static NewsProvider _instance = new NewsProvider();
        public static NewsProvider GetProvider() => _instance;

        private async Task<List<Article>> LoadSampleData()
        {
            var articles = new List<Article>();
            articles.AddRange(await (new RssParser().ParseFeed("https://visualstudiomagazine.com/rss-feeds/columns.aspx")));
            articles.AddRange(await (new RssParser().ParseFeed("https://www.blog.google/rss/")));
           /* foreach (var article in articles)
            {
                if (await App.Database.HasItem(article)) article.Favorite = true;
            }*/
            return articles;
        }

        public async Task<List<Article>> GetNews(bool refresh = false)
        {
            if (Articles is null || refresh)
            {
                Articles = await LoadSampleData();
            }
            return Articles.ToList();
        }

        public async Task<List<Article>> GetFavoritesAsync()
        {
            return await App.Database.GetFavorites();
            //return Articles.Where(article => article.Favorite).ToList();
        }
    }
}
