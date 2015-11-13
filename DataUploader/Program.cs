using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataUploader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please write the path to the file you wish to import the data");
            var filePath = Console.ReadLine();

            using (var textReader = new StreamReader(filePath))
            {
                string line = textReader.ReadLine();
                while (line != null)
                {

                    line = textReader.ReadLine();
                }
            }
        }
    }
}
