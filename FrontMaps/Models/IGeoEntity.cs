using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontMaps.Models
{
    public interface IGeoEntity
    {
        double Latitude { get; set; }

        double Longitude { get; set; }
    }
}
