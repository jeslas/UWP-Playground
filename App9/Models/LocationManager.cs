using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace App9.Models
{
    public class LocationManager
    {
        public async static Task<Geoposition> GetLocation()
        {
            var accessstatus = await Geolocator.RequestAccessAsync();
            if (accessstatus != GeolocationAccessStatus.Allowed) throw new Exception();

            var geolocator = new Geolocator() { DesiredAccuracyInMeters = 0 };
            return await geolocator.GetGeopositionAsync();

        }
    }
}
