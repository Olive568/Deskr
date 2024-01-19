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
    internal class Create_Task
    {
        public void Create()
        {
            Database DB = new Database();
            List<string[]> database = new List<string[]>();
            Console.Clear();
            string name = Name();
            string task = Task();
            DateTime time = DateTime.Now;
            string status = "In Progress";
            database = DB.Create_Database();
            int count = Count_Items();
            database = Add_Items(database, count,status,time,task,name);
        }

        private string Name()
        {
            string name = "";
            while (true)
            {
                Console.WriteLine("Write the name");
                name = Console.ReadLine();
                if (name.Length <= 0)
                {
                    Console.WriteLine("Invalid name");
                    Thread.Sleep(750);
                }
                else
                {
                    return name;
                    break;
                }
            }

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
        private List<string[]> Add_Items(List<string[]> database, int count, string status, DateTime time, string task, string name)
        {
            
            string time_string = time.ToString();
            string[] data = new string[7] { name, task, time_string, "NULL", status, "NULL", "NULL" };
            database.Add(data);

            string filename = "DeskrMain.csv";
           
            using (StreamWriter sw = new StreamWriter(filename))
            {
                for (int x = 0; x < database.Count; x++)
                {
                    for (int y = 0; y < 7; y++)
                    {
                        if (y == 6)
                            sw.Write(database[x][y]);
                        else
                            sw.Write(database[x][y] + ",");
                    }
                    sw.WriteLine();
                }
            }
            return database;
        }
    }
}
