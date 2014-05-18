﻿using System;
using FrontMaps.Extensions;

namespace FrontMaps.Geocoding
{
	/// <summary>
	/// Provides a request for the Google Maps Geocoding web service.
	/// </summary>
	public class GeocodingRequest
	{
		/// <summary>
		/// The address that you want to geocode.
		/// </summary>
		/// <remarks>Required if latlng not present.</remarks>
		public string Address { get; set; }

		/// <summary>
		/// The textual latitude/longitude value for which you wish to obtain
		/// the closest, human-readable address.
		/// </summary>
		/// <remarks>Required if address not present.</remarks>
		/// <see cref="http://code.google.com/apis/maps/documentation/geocoding/#ReverseGeocoding"/>
		public string LatitudeLongitude { get; set; }

		/// <summary>
		/// The bounding box of the viewport within which to bias geocode
		/// results more prominently.
		/// </summary>
		/// <remarks>
		/// Optional. This parameter will only influence, not fully restrict, results
		/// from the geocoder.
		/// </remarks>
		/// <see cref="http://code.google.com/apis/maps/documentation/geocoding/#Viewports"/>
		public string Bounds { get; set; }

		/// <summary>
		/// The region code, specified as a ccTLD ("top-level domain")
		/// two-character value.
		/// </summary>
		/// <remarks>
		/// Optional. This parameter will only influence, not fully restrict, results
		/// from the geocoder.
		/// </remarks>
		/// <see cref="http://code.google.com/apis/maps/documentation/geocoding/#RegionCodes"/>
		public string Region { get; set; }

		/// <summary>
		/// The language in which to return results. If language is not
		/// supplied, the geocoder will attempt to use the native language of
		/// the domain from which the request is sent wherever possible.
		/// </summary>
		/// <remarks>Optional.</remarks>
		/// <see cref="http://code.google.com/apis/maps/faq.html#languagesupport"/>
		public string Language { get; set; }

		/// <summary>
		/// Indicates whether or not the geocoding request comes from a device
		/// with a location sensor. This value must be either true or false.
		/// </summary>
		/// <remarks>Required.</remarks>
		public string Sensor { get; set; }

		internal Uri ToUri()
		{
			var url = "json?"
				.Append("address=", Address)
				.Append("latlng=", LatitudeLongitude)
				.Append("bounds=", Bounds)
				.Append("region=", Region)
				.Append("language=", Language)
				.Append("sensor=", Sensor)
				.TrimEnd('&');

			return new Uri(url, UriKind.Relative);
		}
	}
}
