using System;

namespace TestXamarim.Business.Models
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

