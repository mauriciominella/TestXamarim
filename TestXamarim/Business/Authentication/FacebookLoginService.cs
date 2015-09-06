using System;

namespace TestXamarim.Business
{
	public class FacebookLoginService : ILoginService
	{
		#region ILoginService implementation

		public TestXamarim.Business.Authentication.Models.LoginResult Login (string username, string password)
		{
			return null;
			/*var auth = new OAuth2Authenticator (
				clientId: "App ID from https://developers.facebook.com/apps",
				scope: "",
				authorizeUrl: new Uri ("https://m.facebook.com/dialog/oauth/"),
				redirectUrl: new Uri ("http://www.facebook.com/connect/login_success.html"));

			auth.Completed += (sender, eventArgs) => {
				DismissViewController (true, null);
				if (eventArgs.IsAuthenticated) {
					// Use eventArgs.Account to do wonderful things
				}
			}

				auth.ge
				PresentViewController (auth.GetUI (), true, null);*/
		}

		#endregion

		public FacebookLoginService ()
		{
		}
	}
}

