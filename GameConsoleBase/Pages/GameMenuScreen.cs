using GameConsoleBase.BaseClass;
using GameConsoleBase.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsoleBase.Pages
{
	internal class GameMenuScreen : MenuScreen
	{
		public GameMenuScreen() : base("Game Menu")
		{
			AddMenuItem("Fluffy Game", new GameScreen(new FluffyBirdGame()));
			AddMenuItem("PacMan Game", new GameScreen(new PacManGame()));
			AddMenuItem("Tetris Game", new GameScreen(new TetrisGame()));
		}


	}
}
