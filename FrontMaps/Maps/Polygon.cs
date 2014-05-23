/*
* MvcMaps Preview 1 - A Unified Mapping API for ASP.NET MVC
* Copyright (c) 2009 Chris Pietschmann
* http://mvcmaps.codeplex.com
* Licensed under the Microsoft Reciprocal License (Ms-RL)
* http://mvcmaps.codeplex.com/license
*/
using System.Collections.Generic;
using MvcMaps.Utils;

namespace MvcMaps
{
    public class Polygon : IJsonRender
    {
        public Polygon()
        {
        }

        public Polygon(IEnumerable<LatLng> points)
            : this()
        {
            this.Points = new List<LatLng>(points);
        }

        public List<LatLng> Points { get; set; }

        /// <summary>
        /// Specifies the Line Weight (or Thickness) for the drawn line.
        /// </summary>
        public int? LineWeight { get; set; }

        public string LineColor { get; set; }

        public double? LineOpacity { get; set; }

        public string FillColor { get; set; }

        public double? FillOpacity { get; set; }

        protected virtual JsonObjectBuilder ToJsonObjectBuilder()
        {
            var json = new JsonObjectBuilder();

            var pointsBuilder = new JsonArrayBuilder();
            foreach (var point in this.Points)
            {
                pointsBuilder.Add(point.Render());
            }
            json.Append("points", pointsBuilder.Render());

            if (this.LineWeight.HasValue)
            {
                json.Append("lineweight", this.LineWeight);
            }

            if (!string.IsNullOrEmpty(this.LineColor))
            {
                json.Append("linecolor", "'" + this.LineColor + "'");
            }

            if (this.LineOpacity.HasValue)
            {
                json.Append("lineopacity", this.LineOpacity);
            }

            if (!string.IsNullOrEmpty(this.FillColor))
            {
                json.Append("fillcolor", "'" + this.FillColor + "'");
            }

            if (this.FillOpacity.HasValue)
            {
                json.Append("fillopacity", this.FillOpacity);
            }


            // Special values that are for Bing Maps, give a better default behavior
            json.Append("B_showicon", false);

            return json;
        }

        public string Render()
        {
            return this.ToJsonObjectBuilder().Render();
        }
    }
}
