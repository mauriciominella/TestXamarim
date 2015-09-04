using System;

namespace TestXamarim.Views.Services
{
	public class NavigationService : ViewModels.Services.INavigationService
	{
		#region INavigationService implementation

		public async System.Threading.Tasks.Task NavigateToLogin ()
		{
			await TestXamarim.App.Current.MainPage.Navigation.PushAsync (new Views.LoginView ());
		}

		public async System.Threading.Tasks.Task NavigateToRegister ()
		{
			await TestXamarim.App.Current.MainPage.Navigation.PushAsync (new Views.RegisterView ());
		}

		public async System.Threading.Tasks.Task NavigateToMain ()
		{
			await TestXamarim.App.Current.MainPage.Navigation.PushAsync (new Views.MainView ());
		}

		#endregion

		public NavigationService ()
		{
		}
	}
}

