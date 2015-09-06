using System;
using System.Net;
using System.Json;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace TestXamarim.Repository
{
	public abstract class RestRespositoryBase<T>
	{
		public string ServiceBaseUrl {
			get;
			set;
		}

		public RestRespositoryBase ()
		{
			ServiceBaseUrl = "https://desolate-headland-5520.herokuapp.com/api";
		}

		public void Post(T newEntity){

			var client = new RestClient(ServiceBaseUrl);
			var request = new RestRequest(typeof(T).Name, Method.POST);
			request.RequestFormat = DataFormat.Json;
			request.AddBody(newEntity);
			client.Execute(request);

			// Create an HTTP web request using the URL:
			/*HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (new Uri (ServiceBaseUrl));
			/*request.ContentType = "application/json";
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
			}*/
		}

	//	public async Task<T> Get(int Id){

		/*	var client = new RestClient(ServiceBaseUrl);
			var request = new RestRequest(typeof(T).Name + "/" + Id.ToString(), Method.GET);
			var queryResult = client.Execute<T>(request).Data;

			return queryResult;
*/
			// Create an HTTP web request using the URL:
			/*/HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (new Uri (ServiceBaseUrl + "/" + Id.ToString()));
			request.ContentType = "application/json";
			request.Method = "GET";

			// Send the request to the server and wait for the response:
			using (WebResponse response = await request.GetResponseAsync ())
			{
				// Get a stream representation of the HTTP web response:
				using (Stream stream = response.GetResponseStream ())
				{
					// Use this stream to build a JSON document object:
					JsonValue jsonDoc = await Task.Run (() => System.Json.JsonObject.Load (stream));
					 
					// Return the JSON document:
					JsonConvert.DeserializeObject<T>(jsonDoc);
				}
			}*/

			
		//}

		public IList<T> GetAll(){

			var client = new RestClient(ServiceBaseUrl);
			var request = new RestRequest(typeof(T).Name, Method.GET);
			var queryResult = client.Execute<List<T>>(request).Data;

			return queryResult;

			// Create an HTTP web request using the URL:
			/*HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (new Uri (ServiceBaseUrl));
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

					// Return the JSON document:
					JsonConvert.DeserializeObject<List<T>(jsonDoc);


				}
			}*/
		}
	}
}

