using System;
using System.Collections.Generic;
using System.Text;

namespace Outline.API_Helpers.RouteAPI
{
    public class section
    {
        public struct arrival
        {
            public struct place
            {
                public struct location
                {
                    public string lat;
                    public string lng;
                }
                public string type;
            }
            public string time;
        }
        public struct departure
        {
            public struct place
            {
                public struct location
                {
                    public string lat;
                    public string lng;
                }
                public string type;
            }
            public string time;
        }
        public string id;
        public string polyline;
        public struct transport
        {
            public string mode;
        }
        public string type;
    }
    public class route
    {
        public string id;
        public section[] sections;
    }
    public class PolylineRouteModel //Route Object ( for polyline )
    {
        public route[] routes;
    }
}
