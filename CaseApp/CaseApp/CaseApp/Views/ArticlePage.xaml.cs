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
                return new Command(parameter =>
                {
                    if (parameter is Article article)
                    {
                        article.Favorite = !article.Favorite;
                    }
                });
            }
        }

        public ArticlePage()
        {
            InitializeComponent();
        }
    }
}