/*
* MvcMaps Preview 1 - A Unified Mapping API for ASP.NET MVC
* Copyright (c) 2009 Chris Pietschmann
* http://mvcmaps.codeplex.com
* Licensed under the Microsoft Reciprocal License (Ms-RL)
* http://mvcmaps.codeplex.com/license
*/
using System;
using System.Web.Mvc;

namespace MvcMaps
{
    public static class GoogleMapExtensions
    {
        public static GoogleMap GoogleMap(this AjaxHelper helper)
        {
            DateTime dt = DateTime.Now;
            return GoogleMap(helper, "G" + string.Format("{0}{1}{2}", dt.Minute, dt.Second, dt.Millisecond));
        }

        public static GoogleMap GoogleMap(this AjaxHelper helper, string mapID)
        {
            if (string.IsNullOrEmpty(mapID))
            {
                throw new ArgumentNullException("mapID");
            }
            var map = new GoogleMap(helper, mapID);

            map.Zoom(4)
                .Center(39.9097362345372, -97.470703125)
                .MapType(MapType.Road);

            return map;
        }
    }
}
