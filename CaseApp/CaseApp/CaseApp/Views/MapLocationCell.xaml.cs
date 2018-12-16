using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;

namespace CaseApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapLocationCell : ViewCell
	{



        public static readonly BindableProperty MapViewProperty = BindableProperty.Create(
            nameof(MapView),
            typeof(Map),
            typeof(MapLocationCell),
            null);

        public Map MapView
        {
            get { return (Map)GetValue(MapViewProperty); }
            set { SetValue(MapViewProperty, value); }
        }



        public MapLocationCell ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(MapView != null && BindingContext is Pin pin)
            {
                MapView.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Position, Distance.FromKilometers(0.5)));
            }
        }
    }
}