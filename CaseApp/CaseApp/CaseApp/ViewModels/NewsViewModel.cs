using CaseApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using CaseApp.Annotations;
using CaseApp.Services;
using Xamarin.Forms;

namespace CaseApp.ViewModels
{
    class NewsViewModel : BaseViewModel
    {
        private bool _isRefreshing = false;
        private IEnumerable<IGrouping<string, Article>> _articles;
        private IEnumerable<IGrouping<string, Article>> _favoriteArticles;
        private List<NewsFeed> _newsFeeds;

        public IEnumerable<IGrouping<string, Article>> Articles
        {
            get => _articles;
            set
            {
                _articles = value;
                OnPropertyChanged(nameof(Articles));
            }
        }

        public IEnumerable<IGrouping<string, Article>> FavoriteArticles
        {
            get => _favoriteArticles;
            set
            {
                if (Equals(value, _favoriteArticles)) return;
                _favoriteArticles = value;
                OnPropertyChanged();
            }
        }

        public List<NewsFeed> NewsFeeds {
            get => _newsFeeds;
            set
            {
                if (Equals(value, _newsFeeds)) return;
                _newsFeeds = value;
                OnPropertyChanged();
            }
        }

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public ICommand RefreshCommand => new Command(async () =>
                                                        {
                                                            IsRefreshing = true;

                                                            List<Article> news = await NewsProvider.GetProvider().GetNews();
                                                            Articles = from item in news
                                                                       orderby item.PublishDate descending
                                                                       group item by Utility.RelativeTime(item.PublishDate);

                                                            List<Article> faves = await NewsProvider.GetProvider().GetFavoritesAsync();
                                                            FavoriteArticles = from item in faves
                                                                               orderby item.PublishDate descending
                                                                               group item by Utility.RelativeTime(item.PublishDate);

                                                            NewsFeeds = await NewsProvider.GetProvider().GetNewsFeedsAsync();
                                                            IsRefreshing = false;
                                                        });
    }
}