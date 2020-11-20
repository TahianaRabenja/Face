using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Understand
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> test = new List<string>();

            string filePath = @"C:\\citydb.csv";
            StreamReader reader = null;
            if (File.Exists(filePath))
            {
                reader = new StreamReader(File.OpenRead(filePath));
                List<string> listA = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    foreach (var item in values)
                    {
                        listA.Add(item);
                    }
                    foreach (var coloumn1 in listA)
                    {
                        Console.WriteLine(coloumn1);
                    }
                }
            }
            else
            {
                Console.WriteLine("File doesn't exist");
            }
            Console.ReadLine();

            test = loadCsvFile(filePath);

            foreach(string tt in test)
            {
                Console.WriteLine("Eto izy:" + tt);
            }
        }


        public static List<string> loadCsvFile(string filePath)
        {
            var reader = new StreamReader(File.OpenRead(filePath));
            List<string> searchList = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                searchList.Add(line);
            }
            return searchList;
        }



    }


}
