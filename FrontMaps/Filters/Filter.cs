using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrontMaps.Models;

namespace FrontMaps.Filters
{
    public abstract class Filter : IFilter
    {
        public virtual string Name
        {
            get { return this.GetType().Name; }
        }

        public abstract IQueryable<T> ApplyFilter<T>(IQueryable<T> query, IFilterArgs args) where T: IGeoEntity;
    }
}
