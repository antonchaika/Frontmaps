using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FrontMaps.Utils
{
    public class JsonConverter
    {
        public virtual string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public virtual object Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
