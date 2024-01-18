using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deskr
{
    internal class End_Task
    {
        public void Choose_task()
        {
            Display display= new Display();
            display.DispMain(true);
            Console.WriteLine("Pick a task to end");
            int choice = int.Parse(Console.ReadLine());
            Console.ReadKey();
        }
        private List<string[]> Change_Data(int index)
        {
            List<string[]> database = new List<string[]>();
            return database;
        }
    }
}
