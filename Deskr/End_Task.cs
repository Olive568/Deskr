using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Deskr
{
    internal class End_Task
    {
        string Filename = "DeskrMain.csv";
        public void Choose_task()
        {
            
            Database DB = new Database();   
            List<string[]> database = DB.Create_Database(Filename,7);
            Console.WriteLine("Continue? Y/N");
            string choice = Console.ReadLine().ToUpper();
            switch (choice)
            {
                case "Y":

                    break;
                case "N":
                    return;
                    break;
                default:
                    Choose_task();
                    break;
            }
            int index = Index(database.Count);
            string status = "For Verification";
            DateTime dateTime = DateTime.Now;
            string time = DateTime.Now.ToString();
            Console.WriteLine("Write your comment");
            string comment = Console.ReadLine();
            database = Change_Data(database,index , status, time,comment);
            DB.Database_Write(database, "DeskrMain.csv");
        }

        private int Index(int items)
        {
            Database DB = new Database();
            List<string[]> database = DB.Create_Database(Filename, 7);
            Console.Clear();
            Quick_Display();
            Console.WriteLine();
            Console.WriteLine("Pick a task to end. Write the number");

            int index;
            bool isValidInput = int.TryParse(Console.ReadLine(), out index);

            if (!isValidInput || index == 0 || index > items)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Thread.Sleep(750);
                Index(items);
            }
            else if (database[index][3] != "NULL")
            {
                Console.WriteLine("This task is already finished");
                Thread.Sleep(750);
                Index(items);
            }

            return index;
        }
        private void Quick_Display()
        {
            Display display = new Display();
            display.DispMain();
        }
        private List<string[]> Change_Data(List<string[]> database, int index, string status, string time,string comment)
        {
            database[index][3] = time;
            database[index][4] = status;
            database[index][5] = comment;
            return database;
        }
    }
}
