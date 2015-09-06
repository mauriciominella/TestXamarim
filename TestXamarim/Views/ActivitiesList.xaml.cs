using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TestXamarim.Views
{
	public partial class ActivityListView : ContentPage
	{
		public ActivityListView ()
		{
			InitializeComponent ();
			this.BindingContext = new TestXamarim.ViewModels.ActivityListViewModel ();
		}
	}
}

