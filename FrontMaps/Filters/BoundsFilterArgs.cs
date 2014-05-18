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
        public BoundsFilterArgs(LatLng leftTop, LatLng rightBottom)
        {
            Params = new Dictionary<string, object> {{"leftTop", leftTop}, {"rightBottom", rightBottom}};
        }

        public Dictionary<string, object> Params { get; set; }
    }
}
