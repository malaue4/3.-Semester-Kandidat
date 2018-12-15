using CaseApp.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CaseApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Collections.Generic;

namespace CaseApp.ViewModels
{
    class SettingsViewModel : BaseViewModel
    {
        private bool _isRefreshing = false;
        private ObservableCollection<NewsFeed> _newsFeeds = new ObservableCollection<NewsFeed>();
        private ObservableCollection<Pin> _mapPins = new ObservableCollection<Pin>(new List<Pin> { new Pin() { Label = "RUC", Position = new Position(55.652397, 12.139755) }, new Pin() { Label = "RUC", Position = new Position(55.652397, 12.139755) }, new Pin() { Label = "RUC", Position = new Position(55.652397, 12.139755) }, new Pin() { Label = "RUC", Position = new Position(55.652397, 12.1439755) }, new Pin() { Label = "RUaC", Position = new Position(55.652397, 12.1439755) }, new Pin() { Label = "RaUC", Position = new Position(55.652397, 12.139755) } });

        public ObservableCollection<NewsFeed> NewsFeeds
        {
            get => _newsFeeds;
            set
            {
                if (Equals(value, _newsFeeds)) return;
                _newsFeeds = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Pin> MapPins
        {
            get => _mapPins;
            set
            {
                if (Equals(value, _mapPins)) return;
                _mapPins = value;
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

            NewsFeeds = new ObservableCollection<NewsFeed>(await NewsProvider.GetProvider().GetNewsFeedsAsync());

            IsRefreshing = false;
        });

        public ICommand DeleteCommand => new Command(
            async (item) => {
                if (item  is NewsFeed feed)
                {
                    if(NewsFeeds.Remove(feed))
                        await App.Database.DeleteNewsFeedAsync(feed);
                } else if (item is Pin mapPin)
                {
                    if("Yes".Equals(await App.Current.MainPage.DisplayActionSheet("Are you sure you want to delete?", "Nevermind", null, "Yes")))
                    if (MapPins.Remove(mapPin))
                    {
                        App.Current.MainPage.DisplayAlert("Pin deleted", "It is gone now.", "ok");
                    }
                }
            },
            (item) => item != null && (NewsFeeds.Contains(item as NewsFeed) || MapPins.Contains(item as Pin)));
    }
}