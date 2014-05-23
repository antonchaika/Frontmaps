/*
* MvcMaps Preview 1 - A Unified Mapping API for ASP.NET MVC
* Copyright (c) 2009 Chris Pietschmann
* http://mvcmaps.codeplex.com
* Licensed under the Microsoft Reciprocal License (Ms-RL)
* http://mvcmaps.codeplex.com/license
*/

namespace MvcMaps
{
    /// <summary>
    /// This interface is used to specify specific properties of the Bing Maps Polygon and Polyline objects (BingPolygon and BingPolyline)
    /// </summary>
    public interface IBingPoly
    {
        bool? ShowIcon { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        string ImageUrl { get; set; }
    }
}
