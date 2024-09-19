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
            MainString mstr = new MainString();
            string income1 = "2023.05.01 \"Сдача гаража в аренду\" 35000 \"Перевод на сбер\"";
            string income2 = "2023.05.01 \"Продажа акций\" 7000";
            string income3 = "2023.05.04 \"Зарплата\" 120500";

            string[] provera = new string[] { income1, income2, income3 };
            foreach (string li in provera)
            {
                mstr.ObjectOutput(li);
            }
            string filePath = "2.txt";

            string fileContent = File.ReadAllText(filePath);
            string[] lines = fileContent.Split(new[] { "\r\n" }, StringSplitOptions.None);

            //using (StreamReader reader = new StreamReader(filePath))
            //{
            //    string line;
            //    while ((line = reader.ReadLine()) != null)
            //    {
            //        Console.WriteLine($"{line}");
            //        zxc.ASDas(line);
            //    }
            //}

            foreach (string line in lines)
            {
                Console.WriteLine(line);
                mstr.ObjectOutput(line);
            }
        }
    }

}