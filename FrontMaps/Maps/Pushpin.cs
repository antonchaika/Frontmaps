using System.Web;
using FrontMaps.Models;
using FrontMaps.Utils;

namespace FrontMaps.Maps
{
    public class Pushpin : IJsonRender
    {
        public Pushpin()
        {
        }

        public Pushpin(double lat, double lng)
            : this()
        {
            this.Position = new LatLng(lat, lng);
        }

        public Pushpin(double lat, double lng, string title)
            : this(lat, lng)
        {
            this.Title = title;
        }

        public Pushpin(double lat, double lng, string title, string description)
            : this(lat, lng, title)
        {
            this.Description = description;
        }

        public Pushpin(double lat, double lng, string title, string description, string imageUrl)
            : this (lat, lng, title, description)
        {
            this.ImageUrl = imageUrl;
        }

        public LatLng Position { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        protected virtual JsonObjectBuilder ToJsonObjectBuilder()
        {
            //var json = new JsonObjectBuilder();
            //json.Append("lat", this.Position.Latitude);
            //json.Append("lng", this.Position.Longitude);
            var json = this.Position.ToJsonObjectBuilder();

            if (!string.IsNullOrEmpty(this.Title))
            {
                json.Append("title", "\"" + this.Title + "\"");
            }

            if (!string.IsNullOrEmpty(this.Description))
            {
                json.Append("desc", "\"" + this.Description + "\"");
            }

            if (!string.IsNullOrEmpty(this.ImageUrl))
            {
                string strImageUrl = this.ImageUrl;
                if (this.ImageUrl.StartsWith("~"))
                {
                    strImageUrl = VirtualPathUtility.ToAbsolute(this.ImageUrl, HttpContext.Current.Request.ApplicationPath);
                }
                json.Append("imageurl", "'" + strImageUrl + "'");
            }

            return json;
        }

        public string Render()
        {
            return this.ToJsonObjectBuilder().Render();
        }
    }
}
