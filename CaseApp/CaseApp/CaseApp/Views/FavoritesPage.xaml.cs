using CaseApp.Models;
using CaseApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CaseApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritesPage : ContentPage
    {
        public ObservableCollection<Article> Items { get; set; }

        public FavoritesPage()
        {
            InitializeComponent();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void Favorite_Toggled(object sender, ToggledEventArgs e)
        {
            
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            //MyListView.BeginRefresh();
            //MyListView.ItemsSource = NewsProvider.GetProvider().GetFavorites();
           // MyListView.EndRefresh();
        }
    }
}
