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
    internal class RegisterScreen : Screen
    {
        // בנאי (Constructor) של RegisterScreen
        // קורא לבנאי של המחלקה הבסיסית (Screen) ומגדיר את הכותרת של המסך כ-"Register Page"
        public RegisterScreen() : base("Register Page")
        {
        }

        // שיטה שמציגה את מסך ההרשמה
        public override void Show()
        {
            

            // משתנים לשמירת פרטי המשתמש
            string name;
            string userName;
            string password;

            WriteInfo("Create a new acaount");

            // בקשה מהמשתמש להזין את שמו
            WritePrompt("Enter Name");
            name = Console.ReadLine();

            // משתנה שמסמן אם ההרשמה הצליחה
            bool success = false;

            // לולאה שממשיכה עד שההרשמה מצליחה
            while (!success)
            {
                System.Console.WriteLine("");
                // בקשה מהמשתמש להזין שם משתמש
                WritePrompt("enter desired user name  ");
                userName = Console.ReadLine();

                // בדיקה אם שם המשתמש תקין
                while (!IsValidUserName(userName))
                {
                    WriteError("Invalid username! Must be at least 4 chars.");
                    WritePrompt("enter valid userName:");
                    userName = Console.ReadLine();
                }

                // בקשה מהמשתמש להזין סיסמה
                WritePrompt("Enter Password");
                password = ReadPassword();

                // בדיקה אם הסיסמה תקינה
                while (!IsValidPassword(password))
                {
                    WriteError("Invalid password! Must be 6+ chars and contain '@'.");
                    WritePrompt("Enter new Password");
                    password = Console.ReadLine();
                }

                

                // ניסיון לרשום את המשתמש החדש בבסיס הנתונים
                success = GameDB.RegisterUser(new User(name, userName, password));

                // אם ההרשמה הצליחה
                if (success)
                {
                    WriteSuccess("Registration Successful!");
                }
                // אם ההרשמה נכשלה (למשל, שם המשתמש כבר קיים)
                else
                {
                    WriteError("Registration Failed! UserName already exists.");
                }
            }

            // מחכה שהמשתמש ילחץ על מקש כלשהו לפני שמנקה את המסך
            Console.ReadKey();
            Console.Clear();
        }

        // שיטה שבודקת אם שם המשתמש תקין
        private bool IsValidUserName(string? userName)
        {
            // שם משתמש חייב להיות לפחות 4 תווים ואינו יכול להיות ריק
            if (string.IsNullOrWhiteSpace(userName) || userName.Length < 4)
            {
                Console.WriteLine("UserName must be at least 4 characters long and cannot be empty.");
                return false;
            }
            return true;
        }

        // שיטה שבודקת אם הסיסמה תקינה

        //החלפנו לpublic static כדי שנוכל לגשת ממסך שינוי סיסמה כדי לבדוק אם היא חוקית
        public static bool IsValidPassword(string? password)
        {
            // סיסמה חייבת להיות לפחות 6 תווים, להכיל את הסימן '@', ואינה יכולה להיות ריקה
            if (password == null || password.Length < 6 || password.Contains("@") || string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Password must be at least 6 characters long and contain '@' symbol.");
                return false;
            }
            return true;
        }
    }
}
