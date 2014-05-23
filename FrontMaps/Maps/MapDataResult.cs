/*
* MvcMaps Preview 1 - A Unified Mapping API for ASP.NET MVC
* Copyright (c) 2009 Chris Pietschmann
* http://mvcmaps.codeplex.com
* Licensed under the Microsoft Reciprocal License (Ms-RL)
* http://mvcmaps.codeplex.com/license
*/
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MvcMaps.Utils;

namespace MvcMaps
{
    public class MapDataResult : ActionResult
    {
        public IEnumerable<Pushpin> Pushpins { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var response = context.HttpContext.Response;
            response.ContentType = "application/json";

            var json = new JsonObjectBuilder();

            json.Append("code", 200);

            var pushpinsJson = new JsonArrayBuilder();
            foreach (var pin in this.Pushpins)
            {
                pushpinsJson.Add(pin);
            }
            json.Append("pushpins", pushpinsJson);

            response.Write(json.Render());
        }
    }
}
