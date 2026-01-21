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
    internal class LoginScreen : MenuScreen
    {
        // בנאי (Constructor) של LoginScreen
        // קורא לבנאי של המחלקה הבסיסית (Screen) ומגדיר את הכותרת של המסך כ-"Login Page"
        public LoginScreen() : base("Login Page")
        {
            //עובר למסך הבא
            AddMenuItem("Game Menu ", new GameMenuScreen());
            AddMenuItem("User Peulot", new UserPeulotPage());

        }

        // שיטה שמציגה את מסך ההתחברות
        public override void Show()
        {
           

            Console.Clear();
            PrintHeader();


            // בקשה מהמשתמש להזין שם משתמש וסיסמה
            WriteInfo("Please enter user name and password:");
            System.Console.WriteLine("");
            WritePrompt(" Enter user Name: ");
            string userName = Console.ReadLine(); // קריאת שם המשתמש מהקלט
            WritePrompt("Password: ");
            string password = ReadPassword(); // קריאת הסיסמה מהקלט

            // ניסיון להתחבר עם שם המשתמש והסיסמה
            User user = DB.GameDB.Login(userName, password);

            // לולאה שממשיכה עד שהמשתמש מזין פרטים נכונים
            while (user == null)
            {
                // אם הפרטים שגויים, מציג הודעת שגיאה ומבקש לנסות שוב
                WriteError("Invalid credentials. Please try again.");
                WritePrompt("Enter User Name: ");
                userName = Console.ReadLine();
                WritePrompt("Enter Password: ");
                password = ReadPassword();
                user = DB.GameDB.Login(userName, password); // ניסיון נוסף להתחבר
            }

            // אם ההתחברות הצליחה, מציג הודעת ברוכים הבאים
            WriteSuccess($"Welcome back, {user.Name}!");

            // שומר את המשתמש המחובר במשתנה הסטטי LoggedUser של GameApp
            GameApp.LoggedUser = user;

            initTestGames();

    

            

            // מחכה שהמשתמש ילחץ על מקש כלשהו לפני שמנקה את המסך
            Console.ReadKey();
            Console.Clear();

            
            // מציג את הכותרת של המסך
            base.Show();
            
        }

        private void initTestGames()
        {
            GameApp.LoggedUser.AddGame(new GameDetails("Fluffy Bird", 99));
            GameApp.LoggedUser.AddGame(new GameDetails("Fluffy Bird", 9));
            GameApp.LoggedUser.AddGame(new GameDetails("Fluffy Bird", 29));
            GameApp.LoggedUser.AddGame(new GameDetails("Fluffy Bird", 94));
            GameApp.LoggedUser.AddGame(new GameDetails("Fluffy Bird", 0));

            
        }
    }
}
