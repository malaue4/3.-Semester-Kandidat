using CaseApp.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CaseApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Collections.Generic;
using Acr.UserDialogs;

namespace CaseApp.ViewModels
{
    class MapsViewModel : BaseViewModel
    {
        private bool _isRefreshing = false;
        private ObservableCollection<Pin> _mapPins = new ObservableCollection<Pin>(new List<Pin> { new Pin() { Label = "RUC", Position = new Position(55.652397, 12.139755) } });

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

            //NewsFeeds = new ObservableCollection<NewsFeed>(await NewsProvider.GetProvider().GetNewsFeedsAsync());

            IsRefreshing = false;
        });

        public ICommand AddCommand => new Command(
            async (item) =>
            {
                if (item is MapSpan span)
                {
                    var pin = new Pin
            {
                Label = "You are here",
                Position = span.Center,
                Type = PinType.Generic
            };
                    //if ("Yes".Equals(await App.Current.MainPage.DisplayActionSheet("Are you sure you want to delete?", "Nevermind", null, "Yes")))
                    MapPins.Add(pin);
                        
                            var toastConfig = new ToastConfig("Pin added");
                            toastConfig.SetDuration(3000);
                            toastConfig.SetBackgroundColor(System.Drawing.Color.FromArgb(12, 131, 193));

                            UserDialogs.Instance.Toast(toastConfig);
                            //App.Current.MainPage.DisplayAlert("Pin deleted", "It is gone now.", "ok");
                        
                }
            });

        public ICommand DeleteCommand => new Command(
            async (item) => {
                if (item is Pin mapPin)
                {
                    if("Yes".Equals(await App.Current.MainPage.DisplayActionSheet("Are you sure you want to delete?", "Nevermind", null, "Yes")))
                    if (MapPins.Remove(mapPin))
                    {
                            var toastConfig = new ToastConfig("Pin deleted");
                            toastConfig.SetDuration(3000);
                            toastConfig.SetBackgroundColor(System.Drawing.Color.FromArgb(12, 131, 193));

                            UserDialogs.Instance.Toast(toastConfig);
                            //App.Current.MainPage.DisplayAlert("Pin deleted", "It is gone now.", "ok");
                    }
                }
            },
            (item) => item != null && (MapPins.Contains(item as Pin)));
    }
}