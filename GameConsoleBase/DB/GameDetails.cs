using GameConsoleBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsoleBase.DB
{
    //יצרתי מחלקה בשם GameDetails שמייצגת תוצאה של משחק אחד.
    //היא שומרת את שם המשחק ואת מספר הנקודות שהמשתמש השיג.

    internal class GameDetails
    {

        public String GameName { get; set; }
        public int PlayScore { get; set; }


        public GameDetails(String gameName, int playScore)
        {
            GameName = gameName;
            PlayScore = playScore;
        }
        public Boolean bigger(String gameName, int playScore)
        {
            if (gameName == GameName && playScore > PlayScore)
            {
                PlayScore = playScore;
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return $"{GameName}: {PlayScore} pts";
        }

    }
}