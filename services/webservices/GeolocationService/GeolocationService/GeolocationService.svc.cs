using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Net;
using MaxMind;

namespace GeolocationService
{
    public class GeolocationService : IGeolocationService
    {
        private static GeoIPCountry geo = new GeoIPCountry("GeoIP.dat");

        public string GetCountry(string ipAddress)
        {
            String countryCode = geo.GetCountryCode(IPAddress.Parse(ipAddress));
            return GeoIPCountry.GetCountryNameByCode(countryCode);
        }
    }
}
