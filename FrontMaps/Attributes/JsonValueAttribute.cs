using System;

namespace FrontMaps.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public sealed class JsonValueAttribute : Attribute
    {
        public JsonValueAttribute(string jsonValue)
        {
            this.JsonValue = jsonValue;
        }

        public string JsonValue { get; set; }
    }
}
