using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deskr
{
    internal class Program
    {
        static void Main(string[] args)
        { 
          Start();       
          Console.ReadKey();
        }
        static void Start()
        {
            Console.Clear();
            Console.WriteLine("                                                \r\n                                                \r\n`7MM\"\"\"Yb.                   `7MM               \r\n  MM    `Yb.                   MM               \r\n  MM     `Mb  .gP\"Ya  ,pP\"Ybd  MM  ,MP'`7Mb,od8 \r\n  MM      MM ,M'   Yb 8I   `\"  MM ;Y     MM' \"' \r\n  MM     ,MP 8M\"\"\"\"\"\" `YMMMa.  MM;Mm     MM     \r\n  MM    ,dP' YM.    , L.   I8  MM `Mb.   MM     \r\n.JMMmmmdP'    `Mbmmd' M9mmmP'.JMML. YA..JMML.   \r\n                                                \r\n                                                ");
            Console.WriteLine();
            Console.WriteLine("A. Create New Task");
            Console.WriteLine("B. Verify Task");
            Console.WriteLine("C. View Tasks");
            Console.WriteLine("D. View Verification Status");
            string input = Console.ReadLine().ToUpper();
            choice(input.ToUpper());
        }
        static void choice(string input)
        {
            Display display = new Display();
            if (input == "A")
            {

            }
            else if (input == "B")
            {

            }
            else if (input == "C")
            {
                display.DispMain();
            }
            else if (input == "D")
            {
                display.DispVerify();
            }
            else
            {
                Console.WriteLine("Please enter a valid option.");
                //Start();
            }
        }
    }
}
