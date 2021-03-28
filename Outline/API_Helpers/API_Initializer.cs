using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Diagnostics;

namespace Outline.API_Helpers
{
    public static class API_Initializer
    {
        public static HttpClient ApiClient { get; set; }

        public static void Initialize()
        {
            try
            {
                ApiClient = new HttpClient();
                ApiClient.DefaultRequestHeaders.Accept.Clear();
                ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //AuthenticationHeaderValue authenticationHeader = new AuthenticationHeaderValue("Bearer", "8KtWGk-McvepWJJgEPy9TajS2gv8Tv-PKXGxNVNUbY8");
                //ApiClient.DefaultRequestHeaders.Authorization = authenticationHeader;
                Trace.WriteLine("authorized with credentials: " + ApiClient.DefaultRequestHeaders.Authorization.Scheme + " " + ApiClient.DefaultRequestHeaders.Authorization.Parameter);
            }
            catch(Exception er)
            {
                Trace.WriteLine(er.Message);
                Trace.Write("error from Initialize (API_Helpers.API_Initializer) @" + DateTime.Now);
            }
        }
    }
}
