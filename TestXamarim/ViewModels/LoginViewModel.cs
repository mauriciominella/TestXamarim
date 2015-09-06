using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace TestXamarim.ViewModels
{
	public class LoginViewModel : ViewModels.ViewModelBase
	{
		string email;
		public string Email {
			get {
				return email;
			}
			set {
				email = value;
				this.Notify ("Email");
			}
		}

		string password;
		public string Password {
			get {
				return password;
			}
			set {
				password = value;
				this.Notify ("Password");
			}
		}

		ICommand loginCommand;
		public ICommand LoginCommand {
			get {
				return loginCommand;
			}
			set {
				loginCommand = value;
			}
		}

		ICommand registerCommand;
		public ICommand RegisterCommand {
			get {
				return registerCommand;
			}
			set {
				registerCommand = value;
			}
		}

		private readonly Services.IMessageService _messageService;
		private readonly Business.ILoginService _loginService;

		public LoginViewModel () : base()
		{
			this.LoginCommand = new Command (this.Login);
			this.RegisterCommand = new Command (this.Register);

			this._messageService = DependencyService.Get<Services.IMessageService> ();
			this._loginService = DependencyService.Get<Business.ILoginService> ();
		}


		private void Login(){
			if(this.Email == "adm" && this.Password == "123"){
				this._navigationService.NavigateToMain ();
			}else{
				//emitir msg de erro
				this._messageService.ShowAsync("Email e/ou Senha inválidos...");
			}
		}

		private void Register(){
			base._navigationService.NavigateToRegister ();
		}


	}
}

