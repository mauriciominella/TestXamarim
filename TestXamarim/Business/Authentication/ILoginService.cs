using System;
using System.Threading.Tasks;
using TestXamarim.Business.Authentication.Models;

namespace TestXamarim.Business
{
	public interface ILoginService
	{
		LoginResult Login (string username, string password);
	}
}

