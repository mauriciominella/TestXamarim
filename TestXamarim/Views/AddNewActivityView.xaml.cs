using System;
using System.Collections.Generic;

using Xamarin.Forms;
using TestXamarim.ViewModels;

namespace TestXamarim.Views
{
	public partial class AddNewActivityView : ContentPage
	{
		public AddNewActivityView ()
		{
			InitializeComponent ();
			this.BindingContext = new TestXamarim.ViewModels.AddNewActivityViewModel ();
		}

		protected override void OnBindingContextChanged ()
		{
			base.OnBindingContextChanged ();

			AddNewActivityViewModel vm = BindingContext as AddNewActivityViewModel;

			if (vm != null) {
				ActivityStatusPicker.Items.Clear ();
				foreach (var item in vm.ActivityStatuses) {
					ActivityStatusPicker.Items.Add (item);
				}
			}
				
		}
	}
}

