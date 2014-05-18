using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontMaps.Models
{
    public class GeoEntity
    {
        public Guid Id { get; set; }

        public Dictionary<string, object> Fields { get; set; }

        public LatLng position { get; set; }
    }

    /*public class GeoFields*/
}