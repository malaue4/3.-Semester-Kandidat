using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CaseApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RssFeedCell : ViewCell
	{
	    public static readonly BindableProperty IsExpandedProperty = BindableProperty.Create(
	        nameof(IsExpanded),
	        typeof(bool),
	        typeof(RssFeedCell),
	        false);

	    public Page Page
        {
	        get { return (Page) GetValue(PageProperty); }
	        set { SetValue(PageProperty, value); }
	    }

	    public static readonly BindableProperty PageProperty = BindableProperty.Create(
	        nameof(Page),
	        typeof(Page),
	        typeof(RssFeedCell),
	        null);

	    public bool IsExpanded
	    {
	        get { return (bool)GetValue(IsExpandedProperty); }
	        set { SetValue(IsExpandedProperty, value); }
	    }

	    public RssFeedCell ()
		{
			InitializeComponent ();
		}

	    private async void Link_Clicked(object sender, EventArgs e)
	    {
	        var article = ((View)sender).BindingContext as Article;

	        var articlePage = new ArticlePage {BindingContext = article};
	        if (Page != null) await Page.Navigation.PushAsync(articlePage);
        }



	    private void Favorite_Toggled(object sender, ToggledEventArgs e)
	    {
            /*
	        var item = (sender as View)?.BindingContext;
	        if (e.Value)
	        {
	            App.Database.SaveItemAsync(item as Article);
	        }
	        else
	        {
	            App.Database.DeleteItemAsync(item as Article);
	        }*/
	    }
    }
}