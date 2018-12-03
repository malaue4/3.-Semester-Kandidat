using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CaseApp.Models;
using CaseApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CaseApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticlePage : ContentPage
    {
        public ICommand ToggleFavoriteCommand
        {
            get
            {
                return new Command(async (parameter) =>
                {
                    if (parameter is Article article)
                    {
                        article.Favorite = !article.Favorite;
                        if (article.Favorite)
                        {
                            await App.Database.SaveItemAsync(BindingContext as Article);
                        }
                        else
                        {
                            await App.Database.DeleteItemAsync(BindingContext as Article);
                        }
                    }
                });
            }
        }

        public ArticlePage()
        {
            InitializeComponent();
        }

        private void Switch_OnToggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                App.Database.SaveItemAsync(BindingContext as Article);
            }
            else
            {
                App.Database.DeleteItemAsync(BindingContext as Article);
            }
        }
    }
}