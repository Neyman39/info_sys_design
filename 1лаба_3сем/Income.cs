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
            var parts = Regex.Matches(input, @"[\""].+?[\""]|[^ ]+").Cast<Match>().Select(m => m.Value).ToList();
            Date = DateTime.ParseExact(parts[0], "yyyy.MM.dd", null);
            Source = parts[1].Trim('"');
            Amount = Convert.ToInt32(parts[2]);
        }

        public override string ToString()
        {

            return $"Доходы\nДата: {Date.ToString("yyyy.MM.dd")}";
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
            return $"Доходы компании\nДата: {Date}";
        }
    }

    class MainString
    {
        public void ObjectOutput(string stroka)
        {
            var parts = Regex.Matches(stroka, @"[\""].+?[\""]|[^ ]+").Cast<Match>().Select(m => m.Value).ToList();
            if (parts.Count == 3)
            {
                Income type1 = new Income(stroka);
                Console.WriteLine($"{type1.Source}");
            }
            else if (parts.Count == 4)
            {
                Operation type2 = new Operation(stroka);
                Console.WriteLine($"{type2.TypeOfOperation}, {type2.Source}");
            }
            else
                Console.WriteLine("Возникла ошибка");
        }
    }
}