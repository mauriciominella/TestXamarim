using System;
using System.Collections.Generic;

using Xamarin.Forms;
using TestXamarim.ViewModels;

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

