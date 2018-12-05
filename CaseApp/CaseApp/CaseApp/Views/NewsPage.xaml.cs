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
		public NewsPage ()
		{
			InitializeComponent ();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            MyListView.BeginRefresh();
        }
    }
}