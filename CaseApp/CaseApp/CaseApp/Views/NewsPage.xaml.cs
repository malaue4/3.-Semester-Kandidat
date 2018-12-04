using CaseApp.Models;
using CaseApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseApp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;

namespace CaseApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewsPage : ContentPage
	{
        //public List<Article> Items { get; set; }
        public ImageSource img { get; set; }
		public NewsPage ()
		{
			InitializeComponent ();
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
            var item = (sender as View)?.BindingContext;
            if (e.Value)
            {
                App.Database.SaveItemAsync(item as Article);
            }
            else
            {
                App.Database.DeleteItemAsync(item as Article);
            }
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            MyListView.BeginRefresh();
        }
    }
}