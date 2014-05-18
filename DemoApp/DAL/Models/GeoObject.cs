using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using FrontMaps.Attributes;
using FrontMaps.Models;
using Newtonsoft.Json;

namespace DemoRealtApp.DAL.Models
{
    public class GeoObject : IGeoEntity
    {
        public Guid ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(-90.0, +90.0)]
        [Geo(GeoType.Lat)]
        [JsonProperty("lat")]
        //[DisplayFormat(DataFormatString = "{0:0.#####}", ApplyFormatInEditMode = true)]
        public double Latitude { get; set; }

        [Required]
        [Range(-180.0, +180.0)]
        [Geo(GeoType.Lng)]
        [JsonProperty("lng")]
        //[DisplayFormat(DataFormatString = "{0:0.#####}", ApplyFormatInEditMode = true)]
        public double Longitude { get; set; }

        public int Type { get; set; }
    }
}