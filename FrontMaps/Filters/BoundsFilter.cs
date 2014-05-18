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
            var leftTop = args.Params["leftTop"] as LatLng;
            var rightBottom = args.Params["rightBottom"] as LatLng;

            if (leftTop != null && rightBottom != null)
            query = query.Where(x => 
                x.Latitude + bounds > rightBottom.Latitude && 
                x.Latitude - bounds < leftTop.Latitude &&
                Math.Abs(x.Longitude) + bounds > Math.Abs(leftTop.Longitude) &&
                Math.Abs(x.Longitude) - bounds < Math.Abs(rightBottom.Longitude));

            return query;
        }

        public void GetData()
        {
            
        }
    }
}