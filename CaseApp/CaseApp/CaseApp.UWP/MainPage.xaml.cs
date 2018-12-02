using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Credentials;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace CaseApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitMaps();

            this.InitializeComponent();

            LoadApplication(new CaseApp.App());
        }

        private async void InitMaps()
        {
            var apiKey = GetApiKey() ?? await RequestApiKey();
            apiKey.RetrievePassword();
            Xamarin.FormsMaps.Init(apiKey.Password); // tilføjet for at bruge maps
        }

        private async Task<PasswordCredential> RequestApiKey()
        {
            var apiDialog = new Dialogs.RequestApiKeyDialog();
            await apiDialog.ShowAsync();

            var vault = new PasswordVault();
            PasswordCredential credential = new PasswordCredential("bingApiKey", "default_user", apiDialog.Result);
            vault.Add(credential);

            return credential;
        }

        private PasswordCredential GetApiKey()
        {
            PasswordCredential credential = null;

            var vault = new PasswordVault();

            try
            {
                var credentialList = vault.FindAllByResource("bingApiKey");
                if (credentialList.Count > 0)
                {
                    if (credentialList.Count == 1)
                    {
                        credential = credentialList[0];
                    }
                    else
                    {
                        credential = vault.Retrieve("bingApiKey", "default_user");
                    }
                }

                return credential;
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
