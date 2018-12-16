using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CaseApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CaseApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewsArticleCell : ViewCell
	{
	    public static readonly BindableProperty IsExpandedProperty = BindableProperty.Create(
	        nameof(IsExpanded),
	        typeof(bool),
	        typeof(NewsArticleCell),
	        false);

	    public Page Page
        {
	        get { return (Page) GetValue(PageProperty); }
	        set { SetValue(PageProperty, value); }
	    }

	    public static readonly BindableProperty PageProperty = BindableProperty.Create(
	        nameof(Page),
	        typeof(Page),
	        typeof(NewsArticleCell),
	        null);

	    public bool IsExpanded
	    {
	        get { return (bool)GetValue(IsExpandedProperty); }
	        set { SetValue(IsExpandedProperty, value); }
	    }

	    public NewsArticleCell ()
		{
			InitializeComponent ();
		}

	    private async void Link_Clicked(object sender, EventArgs e)
	    {
	        var article = ((View)sender).BindingContext as Article;

	        var articlePage = new ArticlePage {BindingContext = article};
	        if (Page != null) await Page.Navigation.PushAsync(articlePage);
        }

        public ICommand FavoriteCommand => new Command(()=>
        {
            if (BindingContext is Article article)
                article.Favorite = !article.Favorite;
        });
    }
}