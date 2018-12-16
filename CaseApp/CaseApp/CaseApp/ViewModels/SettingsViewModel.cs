using CaseApp.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CaseApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Collections.Generic;
using Acr.UserDialogs;
using System.Threading.Tasks;

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
            await Task.Delay(100);

            IsRefreshing = false;
        });

        public ICommand DeleteCommand => new Command(
            async (item) => {
                if (item  is NewsFeed feed)
                {

                    if (await App.Current.MainPage.DisplayAlert("Delete?", $"Are you sure you want to delete \"{feed.Title}\"?", "Yes", "Nevermind"))
                        if (NewsFeeds.Remove(feed)) await App.Database.DeleteNewsFeedAsync(feed);
                }
            },
            (item) => item != null && (NewsFeeds.Contains(item as NewsFeed) || MapPins.Contains(item as Pin)));
    }
}