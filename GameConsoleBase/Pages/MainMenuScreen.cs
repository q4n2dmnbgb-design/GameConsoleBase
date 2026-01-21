using GameConsoleBase.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsoleBase.Pages
{
	internal class MainMenuScreen : MenuScreen
	{
		public MainMenuScreen() : base("Main Menu")
		{
			// AddMenuItem("Update", new UpdatePasswordScreen());
			AddMenuItem("Login", new LoginScreen());
			AddMenuItem("Register", new RegisterScreen());
		}
	}
}
