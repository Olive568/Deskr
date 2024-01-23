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
        public List<string[]> Create_Database(string filename, int index)
        {
            List<string[]> database = new List<string[]>();
            int count = 0;
            using (StreamReader sr = new StreamReader(filename))
            {
                string[] data = new string[index];
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
                    for(int y =0; y < database[x].Length; y++)
                    {
                        if (y != database[x].Length - 1)
                            sw.Write(database[x][y] + ",");
                        else
                            sw.Write(database[x][y]);
                    }
                    sw.WriteLine();
                }
            }
        }
        public int Index_Count()
        {
            List<string[]> database = new List<string[]>();
            int count = 0;
            string fileName = "DeskrMain.csv";
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
