using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TestXamarim.Views
{
	public partial class MainView : ContentPage
	{
		public MainView ()
		{
			InitializeComponent ();
			this.BindingContext = new TestXamarim.ViewModels.MainViewModel ();
		}
	}
}

