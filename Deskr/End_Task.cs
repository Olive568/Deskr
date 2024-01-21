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
        public void Choose_task()
        {
            Database DB = new Database();   
            List<string[]> database = DB.Create_Database();
            int index = Index(database.Count);
            string status = Status();
            DateTime dateTime = DateTime.Now;
            string time = DateTime.Now.ToString();
            database = Change_Data(database,index , status, time);
            DB.Database_Write(database, "DeskrMain.csv");
        }

        private int Index(int items)
        {
            Database DB = new Database();
            List<string[]> database = DB.Create_Database();
            Console.Clear();
            Quick_Display();
            Console.WriteLine();
            Console.WriteLine("Pick a task to end. Write the number");
            int index = int.Parse(Console.ReadLine());
            if(index == 0 || index > items)
            {
                Console.WriteLine("Invalid input. Wrong index");
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
        private string Status()
        {
            Console.Clear();
            Console.WriteLine("Write 1 for Complete and 2 for incomeplete status");
            int choice = int.Parse(Console.ReadLine());
            string status = "";
            if (choice == 1)
                status = "complete";
            else if (choice == 2) 
                status = "Incomplete";
            else 
            {
                Console.WriteLine("Only 1 or 2");
                Thread.Sleep(500);
                Status();
            }
            return status;
        }
        private void Quick_Display()
        {
            Display display = new Display();
            display.DispMain();
        }
        private List<string[]> Change_Data(List<string[]> database, int index, string status, string time)
        {
            database[index][3] = time;
            database[index][4] = status;
            return database;
        }
    }
}
