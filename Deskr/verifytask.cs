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
            string status = "";
            Display display = new Display();

            Console.WriteLine("");
            Console.WriteLine("Continue? Y/N");
            string choice = Console.ReadLine().ToUpper();

            switch (choice)
            {
                case "Y":
                    break;
                case "N":
                    return;
                default:
                    gatherinfo();
                    return;
            }

            Database DB = new Database();
            List<string[]> database = DB.Create_Database(Filename, 5);
            List<string[]> databasemain = DB.Create_Database("DeskrMain.csv", 7);

            Console.Clear();
            display.DispMain();

            int index = 0;
            int count = DB.Index_Count();
            DateTime dateTime = DateTime.Now;

            Console.WriteLine();
            Console.WriteLine("What task would you like to verify?");

            // Handle user input for the index
            while (!int.TryParse(Console.ReadLine(), out index) || index <= 0 || index > count)
            {
                Console.WriteLine("Invalid input. Please enter a valid index.");
            }

            if (databasemain[index][3] == "NULL")
            {
                Console.WriteLine("Task is not complete");
                Console.ReadKey();
                gatherinfo();
            }
            else if (databasemain[index][4] == "Open" || databasemain[index][4] == "Closed" || databasemain[index][4] == "Assigned")
            {
                Console.WriteLine("This Task cannot be verified");
                Console.ReadKey();
                gatherinfo();
            }
            else if (databasemain[index][4] == "For Verification")
            {
                string name = index + "";
                Console.WriteLine("Verification Status (1: Verified, 2: For Revision");
                int verification = int.Parse(Console.ReadLine());
                status = verifystatus(verification);

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
            }
            else if (databasemain[index][4] == "For Revision")
            {
                index = int.Parse(databasemain[index][6]);
                string name = index + "";
                Console.WriteLine("Verification Status (1: Verified, 2: For Revision");
                int verification = int.Parse(Console.ReadLine());
                status = verifystatus(verification);

                Console.WriteLine("Credentials: ");
                string details = Console.ReadLine();

                Console.WriteLine("Comments:");
                string comments = Console.ReadLine();
                data[0] = name;
                data[1] = DateTime.Now.ToString();
                data[2] = status;
                data[3] = details;
                data[4] = comments;
                database[index] = data;
            }

            if (status == "Verified")
                databasemain[index][4] = "Closed";
            else if (status == "For Revision")
                databasemain[index][4] = status;

            databasemain[index][6] = index.ToString();
            Filewriter(database, databasemain);
        }

        public void Filewriter(List<string[]> database, List<string[]> database2)
        {
            Database DB = new Database();
            DB.Database_Write(database, "DeskrVerification.csv");
            DB.Database_Write(database2, "DeskrMain.csv");
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
