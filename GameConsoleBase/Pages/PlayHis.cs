using GameConsoleBase.App;
using GameConsoleBase.BaseClass;
using GameConsoleBase.DB;
using GameConsoleBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsoleBase.Pages
{
    internal class PlayHis : Screen
    {
        private int Type;

        public PlayHis(int type) : base("HistoryGame")
        {
            this.Type = type;


        }

        public override void Show()
        {
            Console.Clear();
            PrintHeader();

            if (Type == 1)
            {

                List<GameDetails> gameDetails = GameApp.LoggedUser.SortByName();
                if (gameDetails == null)
                {
                    WriteInfo("Haven't played yet");

                }
                else
                {
                    gameDetails.ForEach(g => Console.WriteLine(g));

                }
            }
            else if (Type == 2)
            {
                List<GameDetails> gameDetails = GameApp.LoggedUser.SortByScore();
                if (gameDetails == null)
                {
                    WriteInfo("Haven't played yet");

                }
                else
                {
                    gameDetails.ForEach(g => Console.WriteLine(g));
                }
            }
            else
            {
                WriteInfo("Showing details of the last game played:");
                if (GameApp.LoggedUser.LastGame() != null)
                {
                    WritePrompt(GameApp.LoggedUser.LastGame().GameName + GameApp.LoggedUser.LastGame().PlayScore);
                }
                else
                {
                    WriteInfo("Haven't played yet");
                }

            }

            Console.ReadKey();
            Console.Clear();

            // עובר למסך הבא (GameMenuScreen)
            Screen next = new GameMenuScreen();
            next.Show();

            
        }
    }
}