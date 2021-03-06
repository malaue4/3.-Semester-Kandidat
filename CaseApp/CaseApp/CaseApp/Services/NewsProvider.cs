﻿using CaseApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CaseApp.Services
{
    internal class NewsProvider
    {
        public List<Article> Articles;
        private static NewsProvider _instance = new NewsProvider();
        public static NewsProvider GetProvider() => _instance;

        private async Task<List<Article>> LoadSampleData()
        {
            var NewsFeeds = await App.Database.GetNewsFeedsAsync();
            //https://visualstudiomagazine.com/rss-feeds/columns.aspx
            //https://www.dr.dk/nyheder/service/feeds/viden

            var articles = new List<Article>();
            foreach (var newsFeed in NewsFeeds)
            {
                if (newsFeed.Active)
                {
                    articles.AddRange(await new RssParser().ParseFeed(newsFeed.LinkString));
                }
            }
            var faves = await App.Database.GetFavoritesAsync();
            return faves.Intersect(articles).Union(articles).ToList();
        }

        public async Task<List<Article>> GetNews(bool refresh = true)
        {
            if (Articles is null || refresh)
            {
                Articles = await LoadSampleData();
            }
            return Articles.ToList();
        }

        public async Task<List<Article>> GetFavoritesAsync()
        {
            return await App.Database.GetFavoritesAsync();
            //return Articles.Where(article => article.Favorite).ToList();
        }

        public async Task<List<NewsFeed>> GetNewsFeedsAsync()
        {
            return await App.Database.GetNewsFeedsAsync();
        }
    }
}
