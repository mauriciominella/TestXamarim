using System;

namespace TestXamarim.Business.Authentication.Models
{
	public class LoginResult
	{
		public LoginResult ()
		{
		}

		public bool IsLoggedIn {
			get;
			set;
		}

		public string ErrorMessage {
			get;
			set;
		}
	}

}

