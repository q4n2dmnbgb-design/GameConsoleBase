using GameConsoleBase.BaseClass;
using GameConsoleBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsoleBase.Pages
{
	internal class GameScreen:Screen
	{
		private IGamePlay game;
		public GameScreen(IGamePlay game) : base(game.Name)
		{
			this.game = game;
		}

		public override void Show()
		{
			Console.Clear();
			PrintHeader();
			WriteInfo($"Get ready to play {game.Name}!");
            Console.WriteLine();//עוד עיצובים שהוספנו 
			Console.Clear();
			base.Show();
			Console.ForegroundColor = ConsoleColor.DarkMagenta;
			HorizontalCenter("Press any key to start Playing");
			Console.ReadKey();
			game.Play();


		}

	}
}
