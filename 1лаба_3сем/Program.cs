using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1_Laba_3sem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.OutputEncoding = Encoding.UTF8;
            MainString mainstr = new MainString();

            string income1 = "\"Доходы компании\" 2023.05.01 \"Сдача гаража в аренду\" 35000 \"Перевод на сбер\"";
            string income2 = "\"Доходы\" 2023.05.01 \"Продажа акций\" 7000";
            string income3 = "\"Доходы\" 2023.05.04 \"Зарплата\" 120500";
            string income4 = "\"Доходы физ.лица\" 2023.05.04 \"Возврат долга\" 1500 \"Иванов И.И.\"";

            //Console.WriteLine(mainstr.ObjectOutput(income2).LineOutput());

            Console.WriteLine("Вывод из строк");
            string[] provera = new string[] { income1, income2, income3, income4 };
            foreach (string linestr in provera)
            {
                Console.WriteLine(mainstr.ObjectOutput(linestr).LineOutput());
            }

            Console.WriteLine("\nВывод из файла");
            foreach (string linefile in mainstr.StrFromFiles("types.txt"))
            {
                Console.WriteLine(mainstr.ObjectOutput(linefile).LineOutput());
            }
        }
    }

}