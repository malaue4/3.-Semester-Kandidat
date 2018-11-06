using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using FransApp.Models;

namespace FransApp.Services
{
    class NewsProvider
    {
        public ObservableCollection<Article> Articles;

        //Fungerer den her hvis articles updateres?
        public IEnumerable<Article> FavoriteArticles => from article in Articles where article.Favorite select article;
    }
}
