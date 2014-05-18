using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrontMaps.Models;

namespace FrontMaps.Filters
{
    public interface IFilter
    {
        string Name { get; }

        IQueryable<T> ApplyFilter<T>(IQueryable<T> query, IFilterArgs args) where T : IGeoEntity;
    }
}