
using FrontMaps.Models;
using Newtonsoft.Json;

namespace FrontMaps.Geocoding
{
	[JsonObject(MemberSerialization.OptIn)]
	public class Viewport
	{
		[JsonProperty("southwest")]
		public GeographicPosition Southwest { get; set; }

		[JsonProperty("northeast")]
		public GeographicPosition Northeast { get; set; }
	}
}
