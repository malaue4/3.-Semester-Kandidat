using Acr.UserDialogs;
using CaseApp.Services;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CaseApp
{
    public partial class App : Application
    {

        static LocalDatabase _database;
        public static LocalDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new LocalDatabase(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "localdatabase.db3"));
                }
                return _database;
            }
            private set
            {
                _database = value;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        //
        // Summary:
        //     Static method for sending the user toast-like notifications
        //
        public static void SendToast(string message, string icon=null)
        {
            var toastConfig = new ToastConfig(message);
            toastConfig.SetDuration(3000);
            toastConfig.SetIcon(icon);
            toastConfig.SetBackgroundColor(Color.Accent);

            UserDialogs.Instance.Toast(toastConfig);
        }
    }
}
