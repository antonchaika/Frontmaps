using System;
using System.ComponentModel;
using System.Data.SqlTypes;
using FrontMaps.Utils;

namespace FrontMaps.Models
{
    [TypeConverter(typeof(LatLngConverter))]
    public class LatLng
    {
        public LatLng() { }

        public LatLng(double lat, double lng)
        {
            this.Latitude = lat;
            this.Longitude = lng;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public static bool TryParse(string s, out LatLng result)
        {
            result = null;

            var parts = s.Split(';');
            if (parts.Length != 2)
            {
                return false;
            }

            double latitude, longitude;
            if (double.TryParse(parts[0], out latitude) &&
                double.TryParse(parts[1], out longitude))
            {
                result = new LatLng { Longitude = longitude, Latitude = latitude };
                return true;
            }
            return false;
        }


        internal virtual JsonObjectBuilder ToJsonObjectBuilder()
        {
            var json = new JsonObjectBuilder();
            json.Append("lat", this.Latitude);
            json.Append("lng", this.Longitude);
            return json;
        }

        public string Render()
        {
            return this.ToJsonObjectBuilder().Render();
        }
    }
}
