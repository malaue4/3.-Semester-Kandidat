using CaseApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CaseApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public ObservableCollection<string> TestList { get; set; } = new ObservableCollection<string>();
        public SettingsPage()
        {
            InitializeComponent();
            TestList.Add("Test1");
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            MyListView.BeginRefresh();
        }

        private async void AddFeedMenuItem_OnClicked(object sender, EventArgs e)
        {
            await DisplayActionSheet("Is Mads a faggot?", "Hell Yes", null, "Definitely", "You know it");
            Navigation.PushModalAsync(new AddFeedPage());
        }
    }
}