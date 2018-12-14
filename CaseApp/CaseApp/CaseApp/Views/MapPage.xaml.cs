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

		    LocationPermission();
		}

	    async Task LocationPermission()
	    {
	        var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
	        if (status != PermissionStatus.Granted)
	        {
	            if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
	            {
	                await DisplayAlert("Need location", "Gunna need that location", "OK");
	            }

	            var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);
	            //Best practice to always check that the key exists
	            if (results.ContainsKey(Permission.LocationWhenInUse))
	                status = results[Permission.LocationWhenInUse];
            }

	        if (status == PermissionStatus.Granted)
	        {
	            //MyMapControl.IsShowingUser = true;
	        }
        }
	}
}