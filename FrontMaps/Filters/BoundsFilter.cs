using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FrontMaps.Attributes;
using FrontMaps.Models;

namespace FrontMaps.Filters
{
    public sealed class BoundsFilter : Filter
    {
        private const double bounds = 0.05;

        public override IQueryable<T> ApplyFilter<T>(IQueryable<T> query, IFilterArgs args)
        {
            var northEast = args.Params["northEast"] as LatLng;
            var southWest = args.Params["southWest"] as LatLng;

            if (northEast != null && southWest != null)
            query = query.Where(x =>
                x.Latitude + bounds > southWest.Latitude &&
                x.Latitude - bounds < northEast.Latitude &&
                Math.Abs(x.Longitude) + bounds > Math.Abs(northEast.Longitude) &&
                Math.Abs(x.Longitude) - bounds < Math.Abs(southWest.Longitude));

            return query;
        }

        public void GetData()
        {
            
        }
    }
}