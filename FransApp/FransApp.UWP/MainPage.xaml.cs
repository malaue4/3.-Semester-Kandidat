using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace FransApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {

            Xamarin.FormsMaps.Init("5m1MYj4UGLHKBrsxzRYz~sl5SyVq652BKPkba9gEmGA~AkmyF4P3B5B5iKDFuJvWOXtQpV12v1BLzriMrd_EcICcsIHLux48nabtuVGwhOrL"); // tilføjet for at bruge maps
            this.InitializeComponent();

            LoadApplication(new FransApp.App());
        }
    }
}
