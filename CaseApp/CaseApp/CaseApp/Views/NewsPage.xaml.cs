using CaseApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using CaseApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CaseApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewsPage : ContentPage
	{
        //public ImageSource img { get; set; }
		public NewsPage ()
		{
			InitializeComponent ();

		    //((NewsViewModel) BindingContext).Articles.CollectionChanged += async (i,b) => await UpdateItems();
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
        /*
        private async Task UpdateImage()
        {
            var uri = new Uri("https://www.google.com");
            img = ImageSource.FromUri(new Uri("https://icons.duckduckgo.com/ip2/www.google.com.jpg"));
            //img = ImageSource.FromUri(new Uri("https://i.imgur.com/Rc7GiRs.jpg"));
            

            //TestImage.Source = img;
        }*/

        private async Task UpdateItems()
        {
            await Task.Run(() =>
            {
                MyListView.ItemsSource = from item in ((NewsViewModel) BindingContext).GetNews()
                    orderby item.PublishDate descending
                    group item by Utility.RelativeTime(item.PublishDate);
            });

        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            await UpdateItems();
            //UpdateImage();
        }

	    private async void MyListView_OnRefreshing(object sender, EventArgs e)
	    {
	        await UpdateItems();
	    }
	}
}