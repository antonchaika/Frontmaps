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
    /// An enumeration of Bing Maps Map Modes.
    /// </summary>
    public enum BingMapMode : int
    {
        /// <summary>
        /// Displays the map in 2-dimensions.
        /// </summary>
        Mode2D = 0,
        /// <summary>
        /// Loads the Bing Maps 3D Map Control and displays the map in 3-demensions.
        /// </summary>
        Mode3D = 1
    }
}
