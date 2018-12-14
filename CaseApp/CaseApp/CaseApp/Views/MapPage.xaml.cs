using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace CaseApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		public MapPage ()
		{
			InitializeComponent ();

            MyMapControl.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(55.652397, 12.139755), Distance.FromKilometers(0.5)));

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            LocationPermission();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

	    async Task LocationPermission()
	    {
	        var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
	        if (status != PermissionStatus.Granted)
	        {
	            if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
	            {
	                await DisplayAlert("Need location", "Gunna need that location", "OK");
	            }

	            var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
	            //Best practice to always check that the key exists
	            if (results.ContainsKey(Permission.Location))
	                status = results[Permission.Location];
            }

	        if (status == PermissionStatus.Granted)
	        {
                MyMapControl.IsShowingUser = true;
	        }
        }
	}
}