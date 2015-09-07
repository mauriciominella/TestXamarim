using System;
using RestSharp.Serializers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TestXamarim
{
	public class LowerCaseJsonSerializer : ISerializer
	{
		public LowerCaseJsonSerializer()
		{
			ContentType = "application/json";
		}

		public string Serialize(object obj)
		{
			var settings = new JsonSerializerSettings();
			settings.ContractResolver = new LowercaseContractResolver();

			return JsonConvert.SerializeObject(obj, settings);
		}

		public string RootElement { get; set; }

		public string Namespace { get; set; }

		public string DateFormat { get; set; }

		public string ContentType { get; set; }

	}

	public class LowercaseContractResolver : DefaultContractResolver {
		protected override string ResolvePropertyName(string propertyName) {
			return propertyName.ToLower();
		}
	}
}

