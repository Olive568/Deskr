using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Deskr
{

    internal class VerifyTask
    {
        Program p = new Program();
        string[] data = new string[5];
        string Filename = "DeskrVerification.csv";
        
        public void Verify()
        {
            //Console.WriteLine(" ______     ______     ______   __  __     __     ______        ______     ______     __    __     __  __     __         ______    \r\n/\\  ___\\   /\\  __ \\   /\\  == \\ /\\ \\_\\ \\   /\\ \\   /\\  __ \\      /\\  == \\   /\\  __ \\   /\\ \"-./  \\   /\\ \\/\\ \\   /\\ \\       /\\  __ \\   \r\n\\ \\___  \\  \\ \\ \\/\\ \\  \\ \\  _-/ \\ \\  __ \\  \\ \\ \\  \\ \\  __ \\     \\ \\  __<   \\ \\ \\/\\ \\  \\ \\ \\-./\\ \\  \\ \\ \\_\\ \\  \\ \\ \\____  \\ \\ \\/\\ \\  \r\n \\/\\_____\\  \\ \\_____\\  \\ \\_\\    \\ \\_\\ \\_\\  \\ \\_\\  \\ \\_\\ \\_\\     \\ \\_\\ \\_\\  \\ \\_____\\  \\ \\_\\ \\ \\_\\  \\ \\_____\\  \\ \\_____\\  \\ \\_____\\ \r\n  \\/_____/   \\/_____/   \\/_/     \\/_/\\/_/   \\/_/   \\/_/\\/_/      \\/_/ /_/   \\/_____/   \\/_/  \\/_/   \\/_____/   \\/_____/   \\/_____/ \r\n                                                                                                                                   ");
            //return "hello";
            gatherinfo();

        }
        public void gatherinfo()
        {
            Display display= new Display();
            Database DB = new Database();
            List<string[]> database = DB.Create_Database(Filename, 5);
            List<string[]> main = DB.Create_Database("DeskrMain.csv", 7);
            Console.Clear();
            display.DispMain();
            int index = 0;
            int count = DB.Index_Count();
            DateTime dateTime = DateTime.Now;
            Console.WriteLine();
            Console.WriteLine("What task would you like to verify?");
            index = int.Parse(Console.ReadLine());
            if (index > count || index == 0)
            {
                Console.WriteLine("That is not a valid index");
                Console.ReadKey();
                gatherinfo();
            }
            else if (main[index][3] == "NULL")
            {
                Console.WriteLine("Task is not complete");
                Console.ReadKey();
                gatherinfo();
            }
            Console.WriteLine("What is your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Verification Status (1: Verified, 2: For Revision");
            int verification = int.Parse(Console.ReadLine());
            string status = verifystatus(verification);

            Console.WriteLine("Credentials: ");
            string details = Console.ReadLine();
            
            Console.WriteLine("Comments:");
            string comments = Console.ReadLine();
            data[0] = name;
            data[1] = DateTime.Now.ToString();
            data[2] = status;
            data[3] = details;
            data[4] = comments;
            database.Add(data);
            Filewriter(database);

        }
        
        public void Filewriter(List<string[]> database)
        {
            Database DB = new Database();
            DB.Database_Write(database, "DeskrVerification.csv");
        }

        private string verifystatus(int choice)
        {
            switch (choice) 
            {
                case 1:
                    return "Verified";
                case 2:
                    return "For Revision";
                default:
                    return "For Verification";
            }
        }
    }
}
