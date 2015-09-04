using System;

namespace TestXamarim.Views.Services
{
	public class MessageService : ViewModels.Services.IMessageService
	{
		#region IMessageService implementation

		public async System.Threading.Tasks.Task ShowAsync (string message)
		{
			await TestXamarim.App.Current.MainPage.DisplayAlert ("Mvvm", message, "ok");
		}

		#endregion

		public MessageService ()
		{
		}
	}
}

