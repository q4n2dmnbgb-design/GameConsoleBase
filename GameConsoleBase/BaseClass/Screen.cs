using GameConsoleBase.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsoleBase.BaseClass
{
    internal class Screen
    {
        // משתנה פרטי שמחזיק את הכותרת של המסך
        private string title;

        // בנאי (Constructor) של המחלקה Screen
        // מקבל כותרת (title) ושומר אותה במשתנה הפרטי
        public Screen(string title)
        {
            this.title = title;
        }

        // שיטה שמציגה את המסך
        // מנקה את המסך, מציגה את הכותרת במרכז המסך בצבע מג'נטה, ואז מאפסת את הצבעים
            
            public virtual void Show()
    {
        Console.Clear(); // מנקה מסך
        PrintHeader();   // <--- השינוי החשוב: קריאה לפונקציית העיצוב החדשה
    }
        //עיצוב מגניב להצגה, לעיצוב נעזרנו בצאט בשביל לעשות דברים מגניבים ממש
        protected void PrintHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
   ___                     _      
___                  ____                      
  / _ \  _   _  _ __   / ___|  __ _  _ __ ___   ___ 
 | | | || | | || '__| | |  _  / _` || '_ ` _ \ / _ \
 | |_| || |_| || |    | |_| || (_| || | | | | |  __/
  \___/  \__,_||_|     \____| \__,_||_| |_| |_|\___|
                                  "); // לוגו לדוגמה
            Console.WriteLine(new string('=', Console.WindowWidth)); // קו מפריד לרוחב המסך
            
            // מרכוז הכותרת של העמוד הספציפי
            string text = $"--- {title} ---";
            int centerX = (Console.WindowWidth - text.Length) / 2;
            Console.SetCursorPosition(centerX, Console.CursorTop);
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.WriteLine(); // שורה רווח
            Console.ResetColor();
        }
        // תוסיפי את זה בתוך Screen.cs
        protected void WriteInfo(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" >> "); // קישוט קטן בהתחלה
            
            Console.ForegroundColor = ConsoleColor.White;
            
            // לולאה שמדפיסה אות-אות עם השהיה קטנה
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(20); // משך ההשהיה (במילי-שניות). 20 זה מהיר וכיפי.
            }
            Console.WriteLine(); // ירידת שורה בסוף
            Console.ResetColor();
        }

        // 2. פונקציה להודעות שגיאה
        protected void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[X] Error: {message}");
            Console.ResetColor();
        }

        // 3. פונקציה להודעות הצלחה
        protected void WriteSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[V] Success: {message}");
            Console.ResetColor();
        }

        // 4. פונקציה לקבלת קלט עם סטייל
        protected void WritePrompt(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" [?] "); // סימן של שאלה/קלט
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{text}: ");
            
            // שינוי צבע הסמן כדי שמה שהמשתמש מקליד יהיה בולט
            Console.ForegroundColor = ConsoleColor.Yellow; 
        }



        // שיטה שמציגה טקסט במרכז השורה הנוכחית
        // text - הטקסט שברצוננו להציג
        public void CenterText(string text)
        {
            // מחשבת את המיקום האופקי כך שהטקסט יוצג במרכז השורה
            Console.SetCursorPosition(Console.WindowWidth / 2 - text.Length / 2, Console.CursorTop);
            Console.WriteLine(text); // מציגה את הטקסט
        }

        // פונקציה לקריאת סיסמה עם כוכביות
        protected string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true); // true = לא להציג את האות על המסך

                // אם המשתמש לא לחץ על Backspace ולא על Enter - נוסיף את האות
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*"); // מדפיס כוכבית במקום האות
                    Console.ForegroundColor = ConsoleColor.Yellow; // צבע הכוכבית
                }
                // טיפול במחיקה (Backspace)
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, (password.Length - 1));
                    Console.Write("\b \b"); // טריק למחיקת התו האחרון מהמסך
                }
            }
            // ממשיך כל עוד לא נלחץ Enter
            while (key.Key != ConsoleKey.Enter);

            Console.WriteLine(); // ירידת שורה בסוף
            return password;
        }
        

        // שיטה שמציגה טקסט במרכז המסך (אופקית ואנכית)
        // text - הטקסט שברצוננו להציג
        public void HorizontalCenter(string text)
        {
            // מחשבת את המיקום האופקי והאנכי כך שהטקסט יוצג במרכז המסך
            Console.SetCursorPosition(Console.WindowWidth / 2 - text.Length / 2, Console.WindowHeight / 2 - Console.CursorTop / 2);
            Console.WriteLine(text); // מציגה את הטקסט
        }
    }
}
