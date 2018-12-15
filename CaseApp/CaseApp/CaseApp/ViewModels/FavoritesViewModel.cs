using CaseApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using CaseApp.Services;
using Xamarin.Forms;

namespace CaseApp.ViewModels
{
    class FavoritesViewModel : BaseViewModel
    {
        private bool _isRefreshing = false;
        private IEnumerable<IGrouping<string, Article>> _favoriteArticles;

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

        public ICommand RefreshCommand => new Command(async () =>
        {
            IsRefreshing = true;
            List<Article> faves = await NewsProvider.GetProvider().GetFavoritesAsync();
            FavoriteArticles = from item in faves
                               orderby item.PublishDate descending
                               group item by Utility.RelativeTime(item.PublishDate);
            IsRefreshing = false;
        });
    }
}