using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FrontMaps.Filters;
using FrontMaps.Models;

namespace FrontMaps.Extensions
{
    public static class Configurator
    {
        public static IQueryable<T> QueryGeoData<T>(this IQueryable<T> query) where T : IGeoEntity
        {
            return query;
        }

        public static CollectionContext<T> CollectGeoData<T>(this IQueryable<T> query) where T : IGeoEntity
        {
            return new CollectionContext<T>(query) { TotalCount = query.Count() };
        }

        public static IEnumerable<T> ListGeoData<T>(this IQueryable<T> query) where T : IGeoEntity
        {
            return query.ToList();
        }

        public static IQueryable<T> FilterBy<T, TR>(this IQueryable<T> query, params object[] context) where T : IGeoEntity
        {
            var type = typeof (TR);
            return query;
        }

        public static IQueryable<T> FilterBy<T>(this IQueryable<T> query, IFilter filter, IFilterArgs args) where T : IGeoEntity
        {
            return filter.ApplyFilter(query, args);
        }

        public static IQueryable<T> FilterBy<T>(this IEnumerable<T> query, IFilter filter, IFilterArgs args) where T : IGeoEntity
        {
            return filter.ApplyFilter(query.AsQueryable(), args);
        }

        public static string Append(this string current, string key, string value)
        {
            return String.IsNullOrEmpty(value) ? current : current + key + value + "&";
        }

        public static object GetAttributeValue(Type objectType, string propertyName, Type attributeType, string attributePropertyName)
        {
            var propertyInfo = objectType.GetProperty(propertyName);
            if (propertyInfo != null)
            {
                if (Attribute.IsDefined(propertyInfo, attributeType))
                {
                    var attributeInstance = Attribute.GetCustomAttribute(propertyInfo, attributeType);
                    if (attributeInstance != null)
                    {
                        foreach (PropertyInfo info in attributeType.GetProperties())
                        {
                            if (info.CanRead &&
                                String.Compare(info.Name, attributePropertyName,
                                    StringComparison.InvariantCultureIgnoreCase) == 0)
                            {
                                return info.GetValue(attributeInstance, null);
                            }
                        }
                    }
                }
            }

            return null;
        }
    }
}