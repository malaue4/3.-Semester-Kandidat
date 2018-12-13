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
       
        public Article Selected { get; set; }
		public NewsPage ()
		{
			InitializeComponent ();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            MyListView.BeginRefresh();
        }

        private void MyListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(sender is ListView list)
            {
                if(list.SelectedItem == Selected)
                {
                    list.SelectedItem = null;
                } else
                {
                    Selected = e.Item as Article;
                    //list.SelectedItem = Selected;
                }
            }
        }

        private void ItemCell_Tapped(object sender, EventArgs e)
        {
            if (sender is NewsArticleCell cell)
            {
                cell.IsExpanded = !cell.IsExpanded;
                if (cell.IsExpanded)
                {
                }
            }
        }
    }
}