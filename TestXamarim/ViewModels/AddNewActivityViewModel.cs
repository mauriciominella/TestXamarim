using System;

using Xamarin.Forms;
using System.Windows.Input;

namespace TestXamarim.ViewModels
{
	public class AddNewActivityViewModel : ViewModels.ViewModelBase
	{
		DateTime date;
		public DateTime Date {
			get {
				return date;
			}
			set {
				date = value;
				Notify ("Date");
			}
		}

		string description;
		public string Description {
			get {
				return description;
			}
			set {
				description = value;
				Notify ("Description");
			}
		}

		ICommand saveCommand;
		public ICommand SaveCommand {
			get {
				return saveCommand;
			}
			set {
				saveCommand = value;
			}
		}

		ICommand cancelCommand;
		public ICommand CancelCommand {
			get {
				return cancelCommand;
			}
			set {
				cancelCommand = value;
			}
		}

		public AddNewActivityViewModel ()
		{
			this.SaveCommand = new Command (this.Save);
			this.CancelCommand = new Command (this.Cancel);

		}

		private void Save()
		{
		}

		private void Cancel()
		{
		}
	}
}


