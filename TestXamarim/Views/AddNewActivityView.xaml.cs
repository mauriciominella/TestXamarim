using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TestXamarim.Views
{
	public partial class AddNewActivityView : ContentPage
	{
		public AddNewActivityView ()
		{
			InitializeComponent ();
			this.BindingContext = new TestXamarim.ViewModels.AddNewActivityViewModel ();
		}
	}
}

