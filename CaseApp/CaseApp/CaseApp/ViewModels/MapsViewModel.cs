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

        public ICommand AddCommand => new Command(
            async (item) =>
            {
                if (item is MapSpan span)
                {
                    var prompt = new PromptConfig
                    {
                        Title = "Name of location?",
                        OkText = "Save",
                        CancelText = "Nevermind",
                        OnTextChanged = args =>
                        {
                            args.IsValid = !string.IsNullOrWhiteSpace(args.Value);
                        },
                        OnAction = args =>
                        {
                            if (args.Ok)
                            {
                                var pin = new Pin
                                {
                                    Label = args.Text,
                                    Position = span.Center,
                                    Type = PinType.Generic
                                };
                                MapPins.Add(pin);
                                App.SendToast("Pin added");
                            }
                        }
                    };

                    UserDialogs.Instance.Prompt(prompt);

                }
            });

        public ICommand DeleteCommand => new Command(
            async (item) =>
            {
                if (item is Pin mapPin)
                {
                    if (await App.Current.MainPage.DisplayAlert("Delete?", $"Are you sure you want to delete \"{mapPin.Label}\"?", "Yes", "Nevermind"))
                        if (MapPins.Remove(mapPin))
                        {
                            App.SendToast($"Pin \"{mapPin.Label}\" deleted");
                        }
                }
            },
            (item) => item != null && (MapPins.Contains(item as Pin)));
    }
}