using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace TestXamarim.ViewModels
{
	public abstract class ViewModelBase : INotifyPropertyChanged
	{
		protected readonly Services.INavigationService _navigationService;

		public ViewModelBase(){
			this._navigationService = DependencyService.Get<Services.INavigationService> ();
		}

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		protected void Notify(string propertyName){
			if (this.PropertyChanged != null)
				this.PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
		}
	}
}

