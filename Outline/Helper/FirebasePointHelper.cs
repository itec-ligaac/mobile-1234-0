using Firebase.Database;
using Firebase.Database.Query;
using Outline.Models;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Outline.Helper
{
    class FirebasePointHelper
    {
        readonly FirebaseClient firebaseClient = new FirebaseClient("https://outline-a825f-default-rtdb.firebaseio.com/");
        public async Task AddNgo(string UID, string address)
        {
            await firebaseClient.Child(UID).PostAsync(new NGO()
            {
                Address=address
            }) ;
        }
        public async Task AddPoint(string UID, string lat,string llong)
        {
            await firebaseClient.Child(UID).PostAsync(new PointOfInterest()
            {
                uniqueId=UID,
                Latitude=lat,
                Longitude=llong,
            });
        }
        // TODO RETRIEVE POINTS FROM DATABASE 
    }
}
