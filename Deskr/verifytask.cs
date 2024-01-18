using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Deskr
{

    internal class verifytask
    {
        Program p = new Program();
        static List<string> s = new List<string>();
        
        public verifytask()
        {
            //Console.WriteLine(" ______     ______     ______   __  __     __     ______        ______     ______     __    __     __  __     __         ______    \r\n/\\  ___\\   /\\  __ \\   /\\  == \\ /\\ \\_\\ \\   /\\ \\   /\\  __ \\      /\\  == \\   /\\  __ \\   /\\ \"-./  \\   /\\ \\/\\ \\   /\\ \\       /\\  __ \\   \r\n\\ \\___  \\  \\ \\ \\/\\ \\  \\ \\  _-/ \\ \\  __ \\  \\ \\ \\  \\ \\  __ \\     \\ \\  __<   \\ \\ \\/\\ \\  \\ \\ \\-./\\ \\  \\ \\ \\_\\ \\  \\ \\ \\____  \\ \\ \\/\\ \\  \r\n \\/\\_____\\  \\ \\_____\\  \\ \\_\\    \\ \\_\\ \\_\\  \\ \\_\\  \\ \\_\\ \\_\\     \\ \\_\\ \\_\\  \\ \\_____\\  \\ \\_\\ \\ \\_\\  \\ \\_____\\  \\ \\_____\\  \\ \\_____\\ \r\n  \\/_____/   \\/_____/   \\/_/     \\/_/\\/_/   \\/_/   \\/_/\\/_/      \\/_/ /_/   \\/_____/   \\/_/  \\/_/   \\/_____/   \\/_____/   \\/_____/ \r\n                                                                                                                                   ");
            //return "hello";
            gatherinfo();

        }
        public void gatherinfo()
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine("What task would you like to verify?");
            Console.WriteLine("What is your name: ");
            string name = Console.ReadLine();
            //s.Add(name);
            Console.WriteLine("Verification Status (1: Verified, 2: For Revision");
            int verification = int.Parse(Console.ReadLine());
            string status = verifystatus(verification);

            Console.WriteLine("Credentials: ");
            string details = Console.ReadLine();
            
            Console.WriteLine("Comments:");
            string comments = Console.ReadLine();

            s.Add(name + "," + dateTime.ToString() + "," + status + "," + details + "," + comments);

        }
        public void Filereader()
        {
            using (StreamReader sr = new StreamReader(p.mainfile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        
        public void Filewriter(string input)
        {
            using (StreamWriter sw = new StreamWriter(p.verificationfile))
            {
                sw.WriteLine(input);
            }
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
