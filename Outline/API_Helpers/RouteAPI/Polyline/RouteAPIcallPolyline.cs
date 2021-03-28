using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Outline.API_Helpers
{
    public class RouteAPIcallPolyline
    {
        public async Task<string> GetRoute(string apiKey, string transportMode, string origin, string destination)
        {
            try
            {
                string baseAddress = "https://router.hereapi.com/v8/routes";
                string routeBuilder = baseAddress + $"?apiKey={apiKey}&transportMode={transportMode}&origin={origin}&destination={destination}&return=polyline";
                Trace.WriteLine("finished building route: " + routeBuilder);
                using (HttpResponseMessage responseMessage = await API_Helpers.API_Initializer.ApiClient.GetAsync(routeBuilder))
                {
                    string responseContent = string.Empty;
                    Trace.WriteLine("Trying to get response from GetRoute api (Polyline)");
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        Trace.WriteLine("GetRoute api status code: " + responseMessage.StatusCode);
                        responseContent = await responseMessage.Content.ReadAsStringAsync();
                        Trace.WriteLine("json response from route api (polyline):\n" + responseContent + "\nGot result @" + DateTime.Now);
                    }
                    Trace.WriteLine(responseMessage.StatusCode);
                    return responseContent; // returns Json answer from routing API (polyline - !!!ENCODED!!!)
                }
            }
            catch(Exception er)
            {
                Trace.WriteLine(er.Message);
                Trace.WriteLine("error from GetRoute (RouteAPIcallPolyline.cs) @" + DateTime.Now);
                return string.Empty;
            }
        }
    }
}
