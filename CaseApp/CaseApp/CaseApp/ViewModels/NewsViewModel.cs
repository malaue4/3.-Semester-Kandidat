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
    class NewsViewModel : INotifyPropertyChanged
    {
        private bool _isRefreshing = false;
        private IEnumerable<IGrouping<string, Article>> _articles;
        private IEnumerable<IGrouping<string, Article>> _favoriteArticles;

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

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;

                    Articles = from item in await NewsProvider.GetProvider().GetNews()
                        orderby item.PublishDate descending
                        group item by Utility.RelativeTime(item.PublishDate);
                    FavoriteArticles = from item in await NewsProvider.GetProvider().GetFavoritesAsync()
                        orderby item.PublishDate descending
                        group item by Utility.RelativeTime(item.PublishDate);
                    IsRefreshing = false;
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}