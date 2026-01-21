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
    internal class UpdateName : Screen
    {
        // בנאי (Constructor) של LoginScreen
        // קורא לבנאי של המחלקה הבסיסית (Screen) ומגדיר את הכותרת של המסך כ-"Login Page"
        public UpdateName() : base("Update Name")
        {
        }

        // שיטה שמציגה את מסך ההתחברות
        public override void Show()
        {
            // מציג את הכותרת של המסך
            base.Show();

            // בקשה מהמשתמש להזין שם משתמש וסיסמה
            WritePrompt("Please enter old Name:");
            string oldName = Console.ReadLine(); // קריאת שם המשתמש מהקלט

            //check old is correct
            if (GameApp.LoggedUser.Name.Equals(oldName))
            {
                WritePrompt("Please enter new name:");
                string newName = Console.ReadLine(); // קריאת הסיסמה מהקלט

                WritePrompt("Please verify new name:");
                string newNameVerified = Console.ReadLine(); // קריאת הסיסמה מהקלט

                if (newName !=  "" && newName == newNameVerified)
                {
                    GameApp.LoggedUser.Name = newName;
                    GameDB.UpdateUser(GameApp.LoggedUser);
                    WriteSuccess("update succeeded");
                }
                else
                {
                    WriteError("Name varification failed");
                }
            }
            else
            {
                WriteError("Not available");

            }

            // מחכה שהמשתמש ילחץ על מקש כלשהו לפני שמנקה את המסך
            Console.ReadKey();
            Console.Clear();

            // עובר למסך הבא (GameMenuScreen)
            Screen next = new GameMenuScreen();
            next.Show();
        }
    }
}
