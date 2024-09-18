using System;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace _1_Laba_3sem
{
    class Income
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Source { get; set; }
        public int Amount { get; set; }

        public Income(string input)
        {
            //Operation income = new Operation();

            var parts = Regex.Matches(input, @"[\""].+?[\""]|[^ ]+").Cast<Match>().Select(m => m.Value).ToList();
            Date = DateTime.ParseExact(parts[0], "yyyy.MM.dd", null);
            Source = parts[1].Trim('"');
            Amount = Convert.ToInt32(parts[2]);
        }

        public override string ToString()
        {

            return $"Доходы\nДата: ыапыоап {Date.ToString("yyyy.MM.dd")}";
        }
    }

    class Operation : Income
    {
        public string TypeOfOperation { get; set; }

        public Operation(string input) : base(input)
        {
            var parts = Regex.Matches(input, @"[\""].+?[\""]|[^ ]+").Cast<Match>().Select(m => m.Value).ToList();
            TypeOfOperation = parts[3].Trim('"');
        }

        public override string ToString()
        {
            return $"Доходы компании\nДата: ыапыоап {Date}";
        }
    }

    class MainString
    {
        public void ASDas(string stroka)
        {
            var parts = Regex.Matches(stroka, @"[\""].+?[\""]|[^ ]+").Cast<Match>().Select(m => m.Value).ToList();
            if (parts.Count == 3)
            {
                Income qwe = new Income(stroka);
                Console.WriteLine($"{qwe.Source}");
            }
            else if (parts.Count == 4)
            {
                Operation zxc = new Operation(stroka);
                Console.WriteLine($"{zxc.TypeOfOperation}, {zxc.Source}");
            }
                
        }

        public void MakeList(@"C:\Users\neyman\Desktop\2лаба.txt")
        {

        }

    }

}