using CaseApp.Models;
using System;
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

            Items = new ObservableCollection<Article>
            {
                new Article{
                    Title="Item 1",
                    Description="This is an item",
                    Favorite=false
                },
                new Article{
                    Title="Item 2",
                    Description="This is an item",
                    Favorite=false
                },
                new Article{
                    Title="Item 3",
                    Description="This is an item",
                    Favorite=false
                },
                new Article{
                    Title="Item 4",
                    Description="This is an item",
                    Favorite=false
                }
            };
			
			MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
