using System;
using System.Threading.Tasks;
using System.Json;
using System.Net;
using System.IO;
using Xamarin.Auth;


namespace TestXamarim.Business
{
	public class GoogleLoginService : ILoginService
	{
		#region ILoginService implementation

		public TestXamarim.Business.Authentication.Models.LoginResult Login (string username, string password)
		{
			throw new NotImplementedException ();
		}

		#endregion

		public GoogleLoginService ()
		{
		}

	}

}

