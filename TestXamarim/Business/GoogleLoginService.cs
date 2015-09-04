using System;

namespace TestXamarim.Business
{
	public class GoogleLoginService : ILoginService
	{
		#region ILoginService implementation

		public TestXamarim.Business.Models.LoginResult Login (string username, string password)
		{
			throw new NotImplementedException ();
		}

		#endregion

		public GoogleLoginService ()
		{
		}
	}
}

