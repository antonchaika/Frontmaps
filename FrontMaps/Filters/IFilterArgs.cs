using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontMaps.Filters
{
    public interface IFilterArgs
    {
        Dictionary<string, object> Params { get; set; }
    }
}
