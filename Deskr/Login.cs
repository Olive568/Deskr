using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Deskr
{
    internal class Login
    {
        private const string UsersFileName = "users.csv";

        public void Run()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            DisplayLoginScreen();
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            int x = (windowWidth - "Username: ".Length) / 2;
            int y = windowHeight / 2 - 2;

            string username = GetUsername(x,y);
            string password = GetPassword(x,y);

            if (AuthenticateUser(username, password))
            {
                Console.WriteLine("Login successful!");
            }
            else
            {
                Console.WriteLine("Authentication failed. Do you want to create a new account? (yes/no)");
                string response = Console.ReadLine();

                if (response.ToLower() == "yes")
                {
                    CreateAccount(username, password);
                    Console.WriteLine("Account created successfully!");
                }
                else
                {
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                }
            }

            Console.ReadLine(); // Pause before closing the console window
        }

        private void DisplayLoginScreen()
        {
            Console.Clear();
            Console.WriteLine("=== Welcome to the Login Screen ===");
            Console.WriteLine("Please enter your credentials:");

            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;

            int x = (windowWidth - "Username: ".Length) / 2;
            int y = windowHeight / 2 - 2;

            Console.SetCursorPosition(x, y);
            Console.Write("Username: ");
            Console.CursorVisible = true;

            Console.SetCursorPosition(x, y + 1);
            Console.Write("Password: ");
            Console.CursorVisible = false;
        }

        private string GetUsername(int x, int y)
        {
            Console.SetCursorPosition(x + "Username: ".Length, Console.CursorTop - 1);
            return Console.ReadLine();
        }

        private string GetPassword(int x, int y)
        {
            Console.SetCursorPosition(x + "Password: ".Length, Console.CursorTop);

            string password = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }

        private bool AuthenticateUser(string username, string password)
        {
            if (File.Exists(UsersFileName))
            {
                string[] lines = File.ReadAllLines(UsersFileName);
                foreach (var line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2 && parts[0] == username && parts[1] == password)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void CreateAccount(string username, string password)
        {
            using (StreamWriter writer = new StreamWriter(UsersFileName, true))
            {
                writer.WriteLine($"{username},{password}");
            }
        }
    }
}
