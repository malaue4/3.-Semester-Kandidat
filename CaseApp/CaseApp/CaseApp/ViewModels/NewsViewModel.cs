using CaseApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CaseApp.ViewModels
{
    class NewsViewModel
    {
        public ObservableCollection<Article> Articles = new ObservableCollection<Article>();
        public ObservableCollection<Article> FavoriteArticles = new ObservableCollection<Article>();


    }
}
