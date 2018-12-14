using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CaseApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddFeedPage : ContentPage
	{
		public AddFeedPage ()
		{
			InitializeComponent ();
		}

	    private void CancelButton_OnClicked(object sender, EventArgs e)
	    {
	        Navigation.PopModalAsync();
	    }

	    private void UrlEntry_OnCompleted(object sender, EventArgs e)
	    {
	        if (BindingContext is AddFeedViewModel viewModel)
	        {
	            viewModel.TestFeed(UrlEntry.Text);
	        }
	    }
	}
}