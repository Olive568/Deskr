﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Deskr
{
    internal class Create_Task
    {
        public void Create()
        {
            Console.Clear();
            string name = Name();
            string task = Task();
            DateTime time = DateTime.Now;
            string status = "In Progress";
            Console.ReadKey();
        }

        private string Name()
        {
            string name = "";
            while(true)
            {
                Console.WriteLine("Write the name");
                name = Console.ReadLine();
                if(name.Length <= 0)
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
            while(true) 
            {
                task = Console.ReadLine();
                if(task.Length < 6)
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
    }
}
