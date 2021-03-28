using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Outline.API_Helpers.RouteAPI.Polyline
{

    /*
     *  Use this class with the output from the GetRoute (Routing API)
     *  -Deserializes json output to PolylineRouteModel object 
     *  -Gets encoded polyline string
     *  TODO NEXT: Decode polyline string and ??? have fun enjoy
     */

    public class ExtractPolylineObjectFromJson
    {
        public PolylineRouteModel polylineObject { get; private set; }

        public ExtractPolylineObjectFromJson(string RawJsonString)
        {
            polylineObject = JsonConvert.DeserializeObject<PolylineRouteModel>(RawJsonString);
        }

        public string GetPolylineEncodedString()
        {
            if(polylineObject!=null)
            {
                return polylineObject.routes[0].sections[0].polyline;
            }
            else
            {
                Trace.WriteLine("polylineObject should not be null!");
                return String.Empty;
            }
        }
    }
}
