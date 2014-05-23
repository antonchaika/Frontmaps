/*
* MvcMaps Preview 1 - A Unified Mapping API for ASP.NET MVC
* Copyright (c) 2009 Chris Pietschmann
* http://mvcmaps.codeplex.com
* Licensed under the Microsoft Reciprocal License (Ms-RL)
* http://mvcmaps.codeplex.com/license
*/

using System.IO;
using System.Web.Mvc;
using MvcMaps.Utils;

// http://code.google.com/apis/maps/documentation/
// http://code.google.com/apis/maps/documentation/v3/

[assembly: System.Web.UI.WebResource("MvcMaps.GoogleMap.js", "text/javascript")]

namespace MvcMaps
{
    /// <summary>
    /// Renders a Google Maps map.
    /// </summary>
    public class GoogleMap : Map<GoogleMap>
    {
        public GoogleMap(AjaxHelper helper, string mapID)
            : base(helper, mapID, "MvcMaps.GoogleMap")
        {
            //this.ScriptInclude("main", "http://maps.google.com/maps/api/js?sensor=false");
            this.ScriptInclude("main", "http://maps.google.com/maps?file=api&v=2&key=abcdefg&sensor=false");
            this.ScriptInclude("gmap.js", WebUtils.GetWebResourceUrl<GoogleMap>("MvcMaps.GoogleMap.js"));
        }

        protected override object ResolveMapType()
        {
            var strMapType = "null";
            switch (this._MapType)
            {
                case MvcMaps.MapType.Road:
                    strMapType = "G_NORMAL_MAP";
                    break;
                case MvcMaps.MapType.Aerial:
                    strMapType = "G_SATELLITE_MAP";
                    break;
                case MvcMaps.MapType.Hybrid:
                    strMapType = "G_HYBRID_MAP";
                    break;
                case MvcMaps.MapType.Terrain:
                    strMapType = "G_PHYSICAL_MAP";
                    break;
            }
            return strMapType;
        }
    }
}
