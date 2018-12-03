using CaseApp.Models;
using CaseApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseApp;
using CaseApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;

namespace CaseApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewsPage : ContentPage
	{
        public ImageSource img { get; set; }
		public NewsPage ()
		{
			InitializeComponent ();

		    ((NewsViewModel) BindingContext).Articles.CollectionChanged += (i,b) => UpdateItems();
		}

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Console.WriteLine(e.Item.ToString());

            if(e.Item is Article article)
            {
            }


            /*
            var articlePage = new ArticlePage();
            articlePage.BindingContext = article;
            await Navigation.PushAsync(articlePage);

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
            */
        }

        private async void Link_Clicked(object sender, EventArgs eventArgs)
        {

            var article = ((View) sender).BindingContext as Article;

            var articlePage = new ArticlePage();
            articlePage.BindingContext = article;
            await Navigation.PushAsync(articlePage);

            //Deselect Item
            //((ListView)sender).SelectedItem = null;
            
        }

        private void Favorite_Toggled(object sender, ToggledEventArgs e)
        {
           
        }

        private async void UpdateImage()
        {
            var uri = new Uri("https://www.google.com");
            img = ImageSource.FromUri(new Uri("https://icons.duckduckgo.com/ip2/www.google.com.jpg"));
            //img = ImageSource.FromUri(new Uri("https://i.imgur.com/Rc7GiRs.jpg"));
            

            //TestImage.Source = img;
        }

        private async void UpdateItems()
        {
            MyListView.ItemsSource = from item in ((NewsViewModel)BindingContext).Articles
                                     orderby item.PublishDate descending
                                     group item by Utility.RelativeTime(item.PublishDate);

        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            //UpdateItems();
            UpdateImage();
        }

	    private void MyListView_OnRefreshing(object sender, EventArgs e)
	    {
	        //UpdateItems();
	    }
	}
}