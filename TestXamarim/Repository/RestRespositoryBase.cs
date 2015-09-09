using System;
using System.Net;
using System.Json;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

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
			var request = new RestRequest(typeof(T).Name.ToLower(), Method.POST);
			request.JsonSerializer = new LowerCaseJsonSerializer ();
			request.RequestFormat = DataFormat.Json;
			request.AddJsonBody(newEntity);

			var response = client.Execute(request);

			if (response.StatusCode != HttpStatusCode.Created)
				throw new Exception ("Error creating a new entity: " + response.StatusCode);
		}

		public void Delete(string id){

			var client = new RestClient(ServiceBaseUrl);
			var request = new RestRequest(typeof(T).Name.ToLower() + "/" + id, Method.DELETE);

			var response = client.Execute(request);

			if (response.StatusCode != HttpStatusCode.NoContent)
				throw new Exception ("Error deleting entity: " + response.StatusCode);

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

