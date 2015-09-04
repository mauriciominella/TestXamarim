using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TestXamarim.Views
{
	public partial class LoginView : ContentPage
	{
		public LoginView ()
		{
			InitializeComponent ();
			this.BindingContext = new TestXamarim.ViewModels.LoginViewModel ();
		}
	}
}

