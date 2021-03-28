using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms.Maps;
using HERE.FlexiblePolyline;
namespace Outline.Polyline_Visual
{
    public class DrawPolyline
    {
        public Polyline polyline { get; private set; }

        public DrawPolyline(string origin_lat, string origin_lng, string destination_lat, string destination_lng)
        {
            polyline = new Polyline();
            InitializePolyline(origin_lat, origin_lng, destination_lat, destination_lng);
        }

        private async void InitializePolyline(string origin_lat, string origin_lng, string destination_lat, string destination_lng) //lat + lng together constitutes a destination or an origin
        {
            try
            {
                API_Helpers.API_Initializer.Initialize();
                API_Helpers.RouteAPIcallPolyline polylineRoute = new API_Helpers.RouteAPIcallPolyline();
                string origin_coordinates = origin_lat + "," + origin_lng;
                string destination_coordinates = destination_lat + "," + destination_lng;
                string PolylineRoutingApiCallResponse = await polylineRoute.GetRoute("wz6T_zibtMtTDYPDzVp9ZRiq7q7N1KPR4g7AL3s5BTU", "car", origin_coordinates, destination_coordinates);
                Trace.WriteLine("got api response routing from initializePolyline: \n" + PolylineRoutingApiCallResponse);
                API_Helpers.RouteAPI.Polyline.ExtractPolylineObjectFromJson polylineExtractor = new API_Helpers.RouteAPI.Polyline.ExtractPolylineObjectFromJson(PolylineRoutingApiCallResponse);
                string polylineEncodedString = polylineExtractor.GetPolylineEncodedString();
                Trace.WriteLine("Polyline encoded string: " + polylineEncodedString);
                List<LatLngZ> coordinates = PolylineEncoderDecoder.Decode(polylineEncodedString);
                foreach (LatLngZ latLngZ in coordinates)
                {
                    polyline.Geopath.Add(new Position(latLngZ.Lat, latLngZ.Lng));
                }
            }
            catch(Exception er)
            {
                Trace.WriteLine(er.Message);
                Trace.WriteLine("error from DrawPolyline.InitializePolyline @" + DateTime.Now);
            }
        }
    }
}
