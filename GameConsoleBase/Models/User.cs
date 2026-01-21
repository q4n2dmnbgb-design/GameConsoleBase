using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsoleBase.Models
{
	internal class User
	{
		public string Name
		{
			get;
			set;
		}
		public string UserName
		{
			get;
			set;
		}
		public string Password
		{
			get;
			set;
		}

		public User(string name, string userName, string password)
		{
			Name = name;
			UserName = userName;
			Password = password;
		}

		private List<GameDetails> Games = new List<GameDetails>();

		public void AddGame(GameDetails game)
		{
			Games.Add(game);
	
		}

		public List<GameDetails> SortByName()
		{
			return Games.OrderBy(g => g.GameName).ToList();
		}
		public List<GameDetails> SortByScore()
		{
			return Games.OrderBy(g => g.PlayScore).ToList();
		}

		public GameDetails LastGame()
		{
			var last = Games.Count - 1;
			if (last > 0)
			{
				return Games[last];
			}
			return null;
		}

		//מחזירה את התוצאה הגבוהה ביותר
		public GameDetails HighestScore()
		{
			GameDetails max = Games[0];
			for (int i = 1; i < Games.Count; i++)
			{
				if (Games[i].PlayScore > max.PlayScore)
				{
					max = Games[i];
				}
			}
			return max;
		}





	}
}
