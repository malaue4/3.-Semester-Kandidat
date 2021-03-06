﻿using CaseApp.Models;
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
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            MyListView.BeginRefresh();
        }

        private void AddFeedMenuItem_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddFeedPage());
        }

        private void MyListView_ItemDisappearing(object sender, ItemVisibilityEventArgs e)
        {
            if(sender is ListView listView)
            {
                listView.SelectedItem = null;
            }
        }
    }
}