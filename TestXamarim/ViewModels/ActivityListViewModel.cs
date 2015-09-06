using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using TestXamarim.Repository;
using System.Collections.Generic;
using System.Windows.Input;

namespace TestXamarim.ViewModels
{
	public class ActivityListViewModel : ViewModelBase
	{
		ObservableCollection<Activity> activityList;
		public ObservableCollection<Activity> ActivityList {
			get {
				return activityList;
			}
			set {
				activityList = value;
				Notify ("ActivityList");
			}
		}


		ICommand listItemTapCommand;
		public ICommand ListItemTapCommand {
			get {
				return listItemTapCommand;
			}
			set {
				listItemTapCommand = value;
			}
		}

		ICommand refreshCommand;
		public ICommand RefreshCommand {
			get {
				return refreshCommand;
			}
			set {
				refreshCommand = value;
			}
		}

		ICommand addNewActivityCommand;
		public ICommand AddNewActivityCommand {
			get {
				return addNewActivityCommand;
			}
			set {
				addNewActivityCommand = value;
			}
		}


		private readonly Services.IMessageService _messageService;

		private readonly ActivityRepository _activityRepository;

		public ActivityListViewModel ()
		{
			//listItemTapCommand = new Command (OnTapped);
			//RefreshCommand = new Command (LoadActivites);
			AddNewActivityCommand = new Command(NavigateToAddNewActivity);
			this._messageService = DependencyService.Get<Services.IMessageService> ();

			this._activityRepository = new ActivityRepository ();

			LoadActivites ();

		}


		#region Private Methods

		void LoadActivites ()
		{
			IList<Activity> activities = _activityRepository.GetAll ();
			this.ActivityList = new ObservableCollection<Activity> (activities);
		}

		void NavigateToAddNewActivity(){
			this._navigationService.NavigateToAddNewActivity ();
		}


		#endregion

	}
}


