using Newtonsoft.Json;

namespace FrontMaps.Models
{
	[JsonObject(MemberSerialization.OptIn)]
	public class GeographicPosition
	{
		[JsonProperty("lat")]
		public decimal Latitude { get; set; }

		[JsonProperty("lng")]
		public decimal Longitude { get; set; }
	}
}
