using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deskr
{
    internal class Program
    {
        public string mainfile = "DeskrMain.csv";
        public string verificationfile = "DeskrVerification.csv";
        static void Main(string[] args)
        {
            Login login = new Login();
            //login.Run();
            Start();
            //vt.execute();
            Console.ReadKey();
        }
        static void Start()
        {
            Integrity_Check();
            Console.Clear();
            Console.WriteLine("                                                \r\n                                                \r\n`7MM\"\"\"Yb.                   `7MM               \r\n  MM    `Yb.                   MM               \r\n  MM     `Mb  .gP\"Ya  ,pP\"Ybd  MM  ,MP'`7Mb,od8 \r\n  MM      MM ,M'   Yb 8I   `\"  MM ;Y     MM' \"' \r\n  MM     ,MP 8M\"\"\"\"\"\" `YMMMa.  MM;Mm     MM     \r\n  MM    ,dP' YM.    , L.   I8  MM `Mb.   MM     \r\n.JMMmmmdP'    `Mbmmd' M9mmmP'.JMML. YA..JMML.   \r\n                                                \r\n                                                ");
            Console.WriteLine();
            Console.WriteLine("A. Create New Task");
            Console.WriteLine("B. Verify Task (Admin only)");
            Console.WriteLine("C. View Tasks");
            Console.WriteLine("D. View Verification Status");
            Console.WriteLine("E. End a task");
            Console.WriteLine("F. Assign a task");
            string input = Console.ReadLine().ToUpper();
            Choice(input.ToUpper());
        }
        static void Integrity_Check()
        {
            Database DB = new Database();
            List<string[]> main = DB.Create_Database("DeskrMain.csv", 7);
            List<string[]> verification = DB.Create_Database("DeskrVerification.csv", 5);
            List<int> indexesToDelete = new List<int>();

            for (int x = 0; x < verification.Count; x++)
            {
                bool delete = true;

                for (int y = 0; y < main.Count; y++)
                {
                    if (main[y][6] == verification[x][0])
                    {
                        delete = false;
                        break; // No need to continue checking if a match is found
                    }
                }

                if (delete)
                {
                    indexesToDelete.Add(x);
                }
            }
            for (int i = indexesToDelete.Count - 1; i >= 0; i--)
            {
                verification.RemoveAt(indexesToDelete[i]);
            }
            DB.Database_Write(main, "DeskrMain.csv");
            DB.Database_Write(verification, "DeskrVerification.csv");
        }
        static void Choice(string input)
        {
            Display display = new Display();
            if (input == "A")
            {
                Create_Task create = new Create_Task();
                create.Create();
            }
            else if (input == "B")
            {
                VerifyTask verify = new VerifyTask(); 
                display.DispMain();
                verify.Verify();

                Console.ReadKey();
            }
            else if (input == "C")
            {
                display.DispMain();
                Console.ReadKey();
            }
            else if (input == "D")
            {
                display.DispVerify();
                Console.ReadKey();
            }
            else if(input == "E")
            {
                End_Task End = new End_Task();
                End.Choose_task();
            }
            else if(input == "F")
            {
                Create_Task create = new Create_Task();
                create.Name();
            }
            else
            {
                Console.WriteLine("Please enter a valid option.");
                //Start();
            }
            Start(); 
        }
    }
}
