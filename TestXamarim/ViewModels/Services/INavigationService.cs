using System;
using System.Threading.Tasks;

namespace TestXamarim.ViewModels.Services
{
	public interface INavigationService
	{
		Task NavigateToLogin();
		Task NavigateToRegister();
		Task NavigateToMain();
		Task NavigateToAddNewActivity();
	}
}

