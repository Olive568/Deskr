using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deskr
{
    internal class Display
    {
        public void DispMain()
        {
            int count = 0;
            Console.Clear();
            Console.WriteLine("                                                \r\n                                                \r\n`7MM\"\"\"Yb.                   `7MM               \r\n  MM    `Yb.                   MM               \r\n  MM     `Mb  .gP\"Ya  ,pP\"Ybd  MM  ,MP'`7Mb,od8 \r\n  MM      MM ,M'   Yb 8I   `\"  MM ;Y     MM' \"' \r\n  MM     ,MP 8M\"\"\"\"\"\" `YMMMa.  MM;Mm     MM     \r\n  MM    ,dP' YM.    , L.   I8  MM `Mb.   MM     \r\n.JMMmmmdP'    `Mbmmd' M9mmmP'.JMML. YA..JMML.   \r\n                                                \r\n                                                ");
            string fileName = "DeskrMain.csv";
            using (StreamReader sr = new StreamReader(fileName))
            {
                string[] splitter = new string[5];
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {

                    for (int j = 0; j < 167; j++)
                    {
                        Console.Write("-");
                    }
                    Console.WriteLine();
                    splitter = line.Split(',');
                    count++;
                    for (int i = 0; i < splitter.Length; i++)
                    {
                        Console.Write(splitter[i]);
                        if (splitter[i].Length < 35)
                        {
                            if (i != 4)
                            {
                                for (int len = splitter[i].Length; len < 24; len++)
                                {
                                    Console.Write(' ');
                                }
                            }
                            else
                            {
                                for (int len = splitter[i].Length; len < 16; len++)
                                {
                                    Console.Write(' ');
                                }
                            }
                            Console.Write("|");
                        }
                    }
                }
                Console.WriteLine();
                for (int j = 0; j < 167; j++)
                {
                    Console.Write("-");
                }
            }
        }
        public void DispVerify()
        {
            int count = 0;
            Console.Clear();
            Console.WriteLine("                                                \r\n                                                \r\n`7MM\"\"\"Yb.                   `7MM               \r\n  MM    `Yb.                   MM               \r\n  MM     `Mb  .gP\"Ya  ,pP\"Ybd  MM  ,MP'`7Mb,od8 \r\n  MM      MM ,M'   Yb 8I   `\"  MM ;Y     MM' \"' \r\n  MM     ,MP 8M\"\"\"\"\"\" `YMMMa.  MM;Mm     MM     \r\n  MM    ,dP' YM.    , L.   I8  MM `Mb.   MM     \r\n.JMMmmmdP'    `Mbmmd' M9mmmP'.JMML. YA..JMML.   \r\n                                                \r\n                                                ");
            string fileName = "DeskrVerification.csv";
            using (StreamReader sr = new StreamReader(fileName))
            {
                string[] splitter = new string[5];
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {

                    for (int j = 0; j < 122; j++)
                    {
                        Console.Write("-");
                    }
                    Console.WriteLine();
                    splitter = line.Split(',');
                    count++;
                    for (int i = 0; i < splitter.Length; i++)
                    {
                        Console.Write(splitter[i]);
                        if (splitter[i].Length < 35)
                        {
                            if (i != 4)
                            {
                                for (int len = splitter[i].Length; len < 24; len++)
                                {
                                    Console.Write(' ');
                                }
                            }
                            else
                            {
                                for (int len = splitter[i].Length; len < 16; len++)
                                {
                                    Console.Write(' ');
                                }
                            }
                            Console.Write("|");
                        }
                    }
                }
                Console.WriteLine();
                for (int j = 0; j < 122; j++)
                {
                    Console.Write("-");
                }
            }
        }
    }
}
