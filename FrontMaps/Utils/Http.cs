using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace FrontMaps
{
	/// <summary>
	/// Provides an intuitive and simple HTTP client wrapper.
	/// </summary>
	internal static class Http
	{
		public class HttpGetResponse
		{
			private Uri requestUri;

			public HttpGetResponse(Uri uri)
			{
				requestUri = uri;
			}

			public string AsString()
			{
				var output = String.Empty;

				var response = WebRequest.Create(requestUri).GetResponse();
				using (var reader = new StreamReader(response.GetResponseStream()))
				{
					output = reader.ReadToEnd();
					reader.Close();
				}
				response.Close();

				return output;
			}

			public T As<T>() where T : class
			{
				T output = null;

				using (var stringReader = new StringReader(AsString()))
				{
					var jsonReader = new JsonTextReader(stringReader);
					var serializer = new JsonSerializer();
					output = serializer.Deserialize<T>(jsonReader);
				}

				return output;
			}
		}

		public static HttpGetResponse Get(Uri uri)
		{
			return new HttpGetResponse(uri);
		}
	}
}
