using System;
using System.Threading.Tasks;
using System.Json;
using System.Net;
using System.IO;

namespace TestXamarim.Business
{
	public class GoogleLoginService : ILoginService
	{
		#region ILoginService implementation

		public TestXamarim.Business.Authentication.Models.LoginResult Login (string username, string password)
		{
			return null;
			// Get the latitude and longitude entered by the user and create a query.
			/*string url = "http://api.geonames.org/findNearByWeatherJSON?lat=" +
				latitude.Text +
				"&lng=" +
				longitude.Text +
				"&username=demo";*/

			// Fetch the weather information asynchronously, 
			// parse the results, then update the screen:
			//JsonValue json = await FetchWeatherAsync (url);
			// ParseAndDisplay (json);

		}

		#endregion

		public GoogleLoginService ()
		{
		}

		// Gets weather data from the passed URL.
		private async Task<JsonValue> FetchWeatherAsync (string url)
		{
			// Create an HTTP web request using the URL:
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (new Uri (url));
			request.ContentType = "application/json";
			request.Method = "GET";

			// Send the request to the server and wait for the response:
			using (WebResponse response = await request.GetResponseAsync ())
			{
				// Get a stream representation of the HTTP web response:
				using (Stream stream = response.GetResponseStream ())
				{
					// Use this stream to build a JSON document object:
					JsonValue jsonDoc = await Task.Run (() => JsonObject.Load (stream));
					Console.Out.WriteLine("Response: {0}", jsonDoc.ToString ());

					// Return the JSON document:
					return jsonDoc;
				}
			}
		}
	}
}

