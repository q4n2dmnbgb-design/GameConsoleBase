using GameConsoleBase.App;
using GameConsoleBase.BaseClass;
using GameConsoleBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;


namespace GameConsoleBase.Pages
{
    internal class UserDetails: Screen
    {
        public UserDetails() : base("Actions Of User Information")
        {
        }
        public override void Show()
        {
            base.Show();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("User Details");
            Console.WriteLine($"Name: {GameApp.LoggedUser.Name}");
            Console.WriteLine($"Username: {GameApp.LoggedUser.UserName}");
            Console.WriteLine($"Password: {GameApp.LoggedUser.Password}");
            Console.ReadKey();
        }
    }
}