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

		public async System.Threading.Tasks.Task NavigateToAddNewActivity(){
			await TestXamarim.App.Current.MainPage.Navigation.PushAsync (new Views.AddNewActivityView ());
		}

		public async System.Threading.Tasks.Task NavigateToActivityList(){
			await TestXamarim.App.Current.MainPage.Navigation.PushAsync (new Views.ActivityListView ());
		}

		#endregion

		public NavigationService ()
		{
		}
	}
}

