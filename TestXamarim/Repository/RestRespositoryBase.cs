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

		private HttpResponseMessage PostCallBack(HttpResponseMessage res){
			string status = res.StatusCode.ToString ();
			return null;
		}

		public async Task Post(T newEntity){

			using (var client = new HttpClient ()) {
				
				client.DefaultRequestHeaders.Accept.Clear ();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				string jsonText = JsonConvert.SerializeObject (newEntity);
				HttpResponseMessage wcfResponse = await client.PostAsync(ServiceBaseUrl + "/activity", new StringContent(jsonText, Encoding.UTF8, "application/json"))
					.ContinueWith(t => PostCallBack(t.Result));
				if(wcfResponse.StatusCode != HttpStatusCode.Created)
					throw new Exception (wcfResponse.StatusCode.ToString());
			}



			//var request = new RestRequest(typeof(T).Name, Method.POST);
			//request.Parameters.Clear ();
			//request.RequestFormat = DataFormat.Json;
			//request.AddHeader("Content-Type", "application/json");
			//request.AddJsonBody (newEntity);
			//request.AddBody(newEntity);


			/*string jsonText = JsonConvert.SerializeObject (newEntity);
			request.Method = Method.POST;
			request.RequestFormat = DataFormat.Json;
			request.AddHeader("Accept", "application/json");
			request.AddParameter("application/json", jsonText, ParameterType.RequestBody);*/

			//string jsonText = JsonConvert.SerializeObject (newEntity);
			//request.AddBody (jsonText);

			//var response = client.Execute(request);

			/*if (response.StatusCode != HttpStatusCode.Created)
				throw new Exception (response.ErrorMessage);*/

			// Create an HTTP web request using the URL:
			/*HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (new Uri (ServiceBaseUrl + "/activity"));
			request.ContentType = "application/json";
			request.Method = "POST";

			string jsonText = JsonConvert.SerializeObject (newEntity);

			using (var streamWriter = new StreamWriter(request.GetRequestStream()))
			{

				streamWriter.Write(jsonText);
				streamWriter.Flush();
				streamWriter.Close();
			}*/



			// Send the request to the server and wait for the response:
			/*using (WebResponse response = request.GetResponse ())
			{
				if (response.Headers.st != HttpStatusCode.Created)
					throw new Exception (response.ErrorMessage);
				
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

