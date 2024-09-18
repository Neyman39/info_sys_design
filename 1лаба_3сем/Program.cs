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
            string incomeStr = "2023.05.01 \"Продажа акций\" 5000 \"Перевод на сбер\"";
            string incoStr = "2023.05.01 \"Сдача гаража в аренду\" 5000";
            //Income income = new Income("2023.05.01 \"Сдача гаража в аренду\" 5000");
            //Operation inc = new Operation("2023.05.01 \"Сдача гаража в аренду\" 5000 \"Перевод на сбер\"");
            //Console.WriteLine(income.ToString());
            //Console.WriteLine(inc.ToString());

            MainString mstr = new MainString();
            mstr.ASDas(incomeStr);
            mstr.ASDas(incoStr);

        }
    }

}