using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using TestXamarim.Repository;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using System.Threading.Tasks;

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
			this.IsLoading = true;

			//RefreshCommand = new Command (LoadActivites);
			AddNewActivityCommand = new Command(NavigateToAddNewActivity);
			DeleteCommand = new Command<Activity> (a => Delete(a));

			this._activityRepository = new ActivityRepository ();

			LoadActivites ();

		}


		bool isLoading;
		public bool IsLoading {
			get {
				return isLoading;
			}
			set {
				isLoading = value;
				Notify ("IsLoading");
			}
		}

		#region Private Methods

		private async void LoadActivites ()
		{
			this.IsLoading = true;

			var result = await _activityRepository.GetAllAsync();
			this.ActivityList = new ObservableCollection<Activity> (result.OrderByDescending(d => d.Date).ToList());

			this.IsLoading = false;
		}

		void NavigateToAddNewActivity(){
			this._navigationService.NavigateToAddNewActivity ();
		}

		private async void Delete(Activity activityToDelete){
			try {
				this.IsLoading = true;

				await this._activityRepository.DeleteAsync (activityToDelete);

				this.IsLoading = false;

				_messageService.ShowAsync ("Activity deleted!");

				this.LoadActivites();

			} catch (Exception ex) {
				_messageService.ShowAsync (ex.Message);
			}
		}


		#endregion

	}
}


