using System;

using Xamarin.Forms;
using System.Windows.Input;
using System.Collections.ObjectModel;
using TestXamarim.Business;
using System.Collections.Generic;
using TestXamarim.Repository;

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

		IList<string> activityStatuses;
		public IList<string> ActivityStatuses {
			get {
				return activityStatuses;
			}
			set {
				activityStatuses = value;
				Notify ("ActivityStatuses");
			}
		}

		int activityStatusSelectedIndex;
		public int ActivityStatusSelectedIndex {
			get {
				return activityStatusSelectedIndex;
			}
			set {
				activityStatusSelectedIndex = value;
				Notify ("ActivityStatusSelectedIndex");
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

		private readonly ActivityRepository _activityRepository;

		public AddNewActivityViewModel ()
		{
			this._activityRepository = new ActivityRepository ();

			this.ActivityStatuses = new List<string> ();

			this.Date = DateTime.Now;

			foreach (var item in Enum.GetValues (typeof(EnumActivityType))) {
				this.ActivityStatuses.Add (item.ToString());
			}

			this.SaveCommand = new Command (this.Save);
			this.CancelCommand = new Command (this.Cancel);

		}

		private void Save()
		{
			try {
				this._activityRepository.Add (this.GetActivityEntity ());

				this.ClearFields();

				_messageService.ShowAsync ("New activity created!");

				this._navigationService.NavigateToActivityList();
			} catch (Exception ex) {
				_messageService.ShowAsync (ex.Message);
			}
		}

		private void ClearFields(){
			this.Date = DateTime.Now;
			this.Description = string.Empty;
			this.ActivityStatusSelectedIndex = -1;
		}

		private Activity GetActivityEntity(){
			Activity newActivity = new Activity ();
			newActivity.Date = this.Date;
			newActivity.Description = this.Description;
			newActivity.Type = ((EnumActivityType)Enum.Parse (typeof(EnumActivityType), this.ActivityStatuses [this.ActivityStatusSelectedIndex])).GetHashCode();

			return newActivity;
		}

		private void Cancel()
		{
			base._navigationService.NavigateToActivityList ();
		}
	}
}


