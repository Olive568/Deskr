using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Deskr
{
    internal class Database
    {
        public List<string[]> Create_Database()
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
                    database.Add(data);
                    count++;
                }
            }
            return database;
        }
        public void Database_Write(List<string[]> database, string filename)
        {
            using(StreamWriter sw = new StreamWriter(filename))
            {
                for (int x =0; x < database.Count; x++) 
                {
                    for(int y =0; y < 7; y++)
                    {
                        if (y != 6)
                            sw.Write(database[x][y] + ",");
                        else
                            sw.Write(database[x][y]);
                    }
                    sw.WriteLine();
                }
            }
        }
    }
}
