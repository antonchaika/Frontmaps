using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FrontMaps.Models
{
    [DataContract]
    public class CollectionContext<T>
    {
        private T[] items;

        [DataMember]
        public int TotalCount { get; set; }

        [DataMember]
        public bool IsGeneric { get; set; }

        [DataMember]
        public IDictionary<string, string> Context { get; set; }

        [DataMember]
        public IEnumerable<T> Items
        {
            get { return this.items; }
            set { items = value.ToArray(); }
        }

        public CollectionContext()
        {
        }

        public CollectionContext(IEnumerable<T> items)
        {
            Items = items;
        }
    }
}