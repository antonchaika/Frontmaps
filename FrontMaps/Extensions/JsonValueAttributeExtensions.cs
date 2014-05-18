using System;
using FrontMaps.Attributes;

namespace FrontMaps.Extensions
{
    internal static class JsonValueAttributeExtensions
    {
        internal static string ToJsonValue(this Enum enumValue)
        {
            var attributes = (JsonValueAttribute[])enumValue.GetType().GetField(enumValue.ToString()).GetCustomAttributes(typeof(JsonValueAttribute), false);
            return (attributes.Length > 0 ? attributes[0].JsonValue : string.Empty);
        }
    }
}
