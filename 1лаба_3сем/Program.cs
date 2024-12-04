using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IncomeLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("=== Вывод из файла ===");
            foreach (BasicIncomeType linefile in IncomeFactory.ListToObjects(IncomeFactory.StrFromFiles("3laba.txt")))
            {
                Console.WriteLine(linefile.LineOutput());
            }

            Console.ReadKey();
        }
    }
}