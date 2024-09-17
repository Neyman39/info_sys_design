using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Laba_3sem
{
    class Program
    {
        static void Main(string[] args)
        {
            string incomeStr = "Доходы компании: дата 2023.05.01, источник \"Сдача гаража в аренду\", сумма 5000";
            Console.WriteLine(Income.FromString(incomeStr));
        }
    }

}