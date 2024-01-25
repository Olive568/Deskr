using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    internal class Create_Task
    {
        public void Create()
        {
            string filename = "DeskrMain.csv";
            Database DB = new Database();
            List<string[]> database = new List<string[]>();
            Console.Clear();
            string name = "NULL";
            string task = Task();
            DateTime time = DateTime.Now;
            string status = "Open";
            database = DB.Create_Database(filename, 7);
            int count = Count_Items();
            string time_string = time.ToString();
            string[] data = new string[7] { name, task, time_string, "NULL", status, "NULL", "NULL" };
            database.Add(data);
            DB.Database_Write(database,filename);
        }
        public void Name()
        {
            bool cont = false;
            Program program = new Program();
            Display display = new Display();
            do
            {
                Console.Clear();
                display.DispMain();
                Console.WriteLine("Continue? Y/N");
                string choice = Console.ReadLine().ToUpper();

                switch (choice)
                {
                    case "Y":
                        Database DB = new Database();
                        List<string[]> database = DB.Create_Database("DeskrMain.csv", 7);
                        Console.WriteLine("Put the index of the task you will assign");
                        int index;

                        if (!int.TryParse(Console.ReadLine(), out index) || index <= 0 || index > database.Count - 1)
                        {
                            Console.WriteLine("Invalid index, out of bounds");
                        }
                        else if (database[index][0] != "NULL")
                        {
                            Console.WriteLine("Invalid index, already assigned");
                        }
                        else
                        {
                            Console.WriteLine("Enter the name");
                            string name = Console.ReadLine();
                            database[index][0] = name;
                            database[index][4] = "Assigned";
                            DB.Database_Write(database, "DeskrMain.csv");
                            cont = true;
                        }
                        Console.ReadKey();
                        break;

                    case "N":
                        cont = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter Y or N.");
                        break;
                }
            } while (!cont);
        }
        private string Task()
        {
            string task = "";
            Console.WriteLine("What is the name of the task? ");
            while (true)
            {
                task = Console.ReadLine();
                if (task.Length < 6)
                {
                    Console.WriteLine("Invalid task");
                    Thread.Sleep(750);
                }
                else
                {
                    return task;
                    break;
                }
            }
        }
        private void Add(string name, string task, DateTime time, string status)
        {
            string line = "";
            int count = 0;
            using (StreamReader sr = new StreamReader("DeskrMain.csv"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    count++;
                }
            }
        }
        private int Count_Items()
        {
            int count = 0;
            string fileName = "DeskrMain.csv";
            string line = "";
            using (StreamReader sr = new StreamReader(fileName))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
