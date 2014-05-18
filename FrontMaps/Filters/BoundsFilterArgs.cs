using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrontMaps.Models;

namespace FrontMaps.Filters
{
    public class BoundsFilterArgs : IFilterArgs
    {
        public BoundsFilterArgs(LatLng northEast, LatLng southWest)
        {
            Params = new Dictionary<string, object> { { "northEast", northEast }, { "southWest", southWest } };
        }

        public Dictionary<string, object> Params { get; set; }
    }
}