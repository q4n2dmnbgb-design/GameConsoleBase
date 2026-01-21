using GameConsoleBase.App;
using GameConsoleBase.BaseClass;
using GameConsoleBase.DB;
using GameConsoleBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Towel.Measurements;

namespace GameConsoleBase.Pages
{
    internal class UpdatePassword : Screen
    {
        // בנאי (Constructor) של LoginScreen
        // קורא לבנאי של המחלקה הבסיסית (Screen) ומגדיר את הכותרת של המסך כ-"Login Page"
        public UpdatePassword() : base("Update password")
        {
        }

        // שיטה שמציגה את מסך ההתחברות
        public override void Show()
        {
            // מציג את הכותרת של המסך
            base.Show();

            // בקשה מהמשתמש להזין שם משתמש וסיסמה
            WritePrompt("Please enter old password:");
            string oldPassword = ReadPassword(); // קריאת שם המשתמש מהקלט

            //check old is correct
            if (GameApp.LoggedUser.Password.Equals(oldPassword))
            {
                WritePrompt("Please enter new password:");
                string newPassword = Console.ReadLine(); // קריאת הסיסמה מהקלט
                if (RegisterScreen.IsValidPassword(newPassword))
                {
                    WritePrompt("Please verify new password:");
                    string newPasswordVerified = Console.ReadLine(); // קריאת הסיסמה מהקלט

                    if (newPassword != "" && newPassword == newPasswordVerified)
                    {
                        GameApp.LoggedUser.Password = newPassword;
                        GameDB.UpdateUser(GameApp.LoggedUser);
                        WriteSuccess("update succeeded");
                    }
                    else
                    {
                        WriteError("password varification failed");
                    }
                }
                else
                {
                    WriteError("paswword isn't available");
                }

                
            }
            else
            {
                WriteError("Isn't available");

            }


            // מחכה שהמשתמש ילחץ על מקש כלשהו לפני שמנקה את המסך
            WriteInfo("Press any key to return");
            Console.Clear();

            // עובר למסך הבא (GameMenuScreen)
            Screen next = new GameMenuScreen();
            next.Show();
        }
    }
}
