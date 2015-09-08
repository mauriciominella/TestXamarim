using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using TestXamarim.Repository;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;

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

		ICommand deleteCommand;
		public ICommand DeleteCommand {
			get {
				return deleteCommand;
			}
			set {
				deleteCommand = value;
			}
		}



		private readonly ActivityRepository _activityRepository;

		public ActivityListViewModel ()
		{
			//listItemTapCommand = new Command (OnTapped);
			RefreshCommand = new Command (LoadActivites);
			AddNewActivityCommand = new Command(NavigateToAddNewActivity);
			DeleteCommand = new Command<Activity> (a => Delete(a));

			this._activityRepository = new ActivityRepository ();

			LoadActivites ();

		}


		#region Private Methods

		void LoadActivites ()
		{
			IList<Activity> activities = _activityRepository.GetAll ().OrderByDescending(d => d.Date).ToList();
			this.ActivityList = new ObservableCollection<Activity> (activities);
		}

		void NavigateToAddNewActivity(){
			this._navigationService.NavigateToAddNewActivity ();
		}

		void Delete(Activity activityToDelete){
			try {
				
				this._activityRepository.Delete (activityToDelete);
				_messageService.ShowAsync ("Activity deleted!");
				this.LoadActivites();

			} catch (Exception ex) {
				_messageService.ShowAsync (ex.Message);
			}
		}


		#endregion

	}
}


