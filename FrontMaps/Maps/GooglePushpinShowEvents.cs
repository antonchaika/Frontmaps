/*
* MvcMaps Preview 1 - A Unified Mapping API for ASP.NET MVC
* Copyright (c) 2009 Chris Pietschmann
* http://mvcmaps.codeplex.com
* Licensed under the Microsoft Reciprocal License (Ms-RL)
* http://mvcmaps.codeplex.com/license
*/

using FrontMaps.Attributes;

namespace MvcMaps
{
    public enum GooglePushpinShowEvents : int
    {
        [JsonValue("'click'")]
        Click = 0,
        [JsonValue("'mouseover'")]
        Mouseover = 1,
        [JsonValue("'dblclick'")]
        DoubleClick = 2
    }
}
