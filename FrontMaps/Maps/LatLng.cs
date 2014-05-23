/*
* MvcMaps Preview 1 - A Unified Mapping API for ASP.NET MVC
* Copyright (c) 2009 Chris Pietschmann
* http://mvcmaps.codeplex.com
* Licensed under the Microsoft Reciprocal License (Ms-RL)
* http://mvcmaps.codeplex.com/license
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcMaps.Utils;

namespace MvcMaps
{
    public class LatLng
    {
        public LatLng(double lat, double lng)
        {
            this.Latitude = lat;
            this.Longitude = lng;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

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
