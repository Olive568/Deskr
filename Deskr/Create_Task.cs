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
            List<string[]> database = new List<string[]>();
            Console.Clear();
            string name = Name();
            string task = Task();
            DateTime time = DateTime.Now;
            string status = "In Progress";
            database = Generate_Database();
            int count = Count_Items() + 1;
            database = Add_Items(database, count,status,time,task,name);
            Console.ReadKey();
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
        private List<string[]> Generate_Database()
        {
            List<string[]> database = new List<string[]>();
            int count = 0;
            string fileName = "DeskrMain.csv";
            using (StreamReader sr = new StreamReader(fileName))
            {
                string[] data = new string[7];
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    data = line.Split(',');
                    database[count] = data;
                    count++;
                }
                
            }
            return database;
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
            database[count][0] = name;
            database[count][1] = task;
            database[count][2] = time_string;
            database[count][3] = "NULL";
            database[count][4] = status;
            database[count][5] = "NULL";
            database[count][6] = "NULL";
            string filename = "DeskrMain.csv";
            using (StreamWriter sw = new StreamWriter(filename))
            {
                for (int i = 0; i < 7; i++)
                {
                    if(i == 6)
                        sw.Write(database[count][i]);
                    sw.Write(database[count][i] + ",");
                }
            }
            return database;
        }
    }
}
