using System;
using System.Threading.Tasks;

namespace TestXamarim.ViewModels.Services
{
	public interface IMessageService
	{
		Task ShowAsync (string message);
		void Show (string message);
	}
}

