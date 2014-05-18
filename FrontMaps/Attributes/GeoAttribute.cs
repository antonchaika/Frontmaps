using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FrontMaps.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class GeoAttribute : Attribute
    {
        private GeoType _propName;
        public GeoAttribute(GeoType name)
        {
            this._propName = name;
        }
    }

    public enum GeoType
    {
        Lat,
        Lng
    }
}