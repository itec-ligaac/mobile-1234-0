using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using System.Diagnostics;
using Outline.Helper;

namespace Outline
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Test : ContentPage
    {
        public Test()
        {
            InitializeComponent();
        }
        readonly FirebasePointHelper firebaseClient = new FirebasePointHelper();
        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Geocoder geocoder = new Geocoder();

                IEnumerable<Position> approximateLocations = await geocoder.GetPositionsForAddressAsync(Entry.Text);
                Position position = approximateLocations.FirstOrDefault();
                Pin pin = new Pin
                {
                    Label = "Test label sa vad cum arata lol tare",
                    Address = Entry.Text,
                    Type = PinType.Place,
                    Position = position
                };
                map.Pins.Add(pin);
                //Create polyline between current position and pin

                //get current position
                var currentLocation = await Geolocation.GetLastKnownLocationAsync();
                string currentlocation_lat = "45.751650";
                string currentlocation_lng = "21.226114";
                string pinlocation_lat = position.Latitude.ToString();
                string pinlocation_lng = position.Longitude.ToString();
                await firebaseClient.AddPoint(DateTime.Now.ToString("dd mm yyyy hh:mm:ss"), pinlocation_lat, pinlocation_lng);
                if (currentLocation != null)
                {
                    Polyline_Visual.DrawPolyline drawPolyline = new Polyline_Visual.DrawPolyline(currentlocation_lat, currentlocation_lng, pinlocation_lat, pinlocation_lng);
                    map.MapElements.Add(drawPolyline.polyline);
                }
            }
            catch(Exception er)
            {
                Trace.WriteLine(er.Message);
                Trace.WriteLine("error from ButtonClicked(test.xaml.cs) @" + DateTime.Now);
            }
        }
    }
}