using System;

namespace TestXamarim.Views.Services
{
	public class MessageService : ViewModels.Services.IMessageService
	{
		#region IMessageService implementation

		public async System.Threading.Tasks.Task ShowAsync (string message)
		{
			await TestXamarim.App.Current.MainPage.DisplayAlert ("Bravi Timeline", message, "ok");
		}

		public void Show (string message)
		{
			TestXamarim.App.Current.MainPage.DisplayAlert ("Bravi Timeline", message, "ok");
		}

		#endregion

		public MessageService ()
		{
		}
	}
}

