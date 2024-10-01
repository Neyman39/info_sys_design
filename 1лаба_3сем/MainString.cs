using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace _1_Laba_3sem
{
    class MainString
    {
        public string[] StrFromFiles(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);
            return fileContent.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static List<string> ParseString(string input)
        {
            return Regex.Matches(input, @"[\""].+?[\""]|[^ ]+")
                         .Cast<Match>()
                         .Select(m => m.Value)
                         .ToList();
        }

        public BaseStr ObjectOutput(string stroka)
        {
            var parts = ParseString(stroka);

            if (parts[0].Trim('"') == "Доходы")
            {
                return new Income(parts[0].Trim('"'), DateTime.ParseExact(parts[1], "yyyy.MM.dd", null), parts[2].Trim('"'), Convert.ToInt32(parts[3]));
            }
            else if (parts[0].Trim('"') == "Доходы компании")
            {
                return new Operation(parts[0].Trim('"'), DateTime.ParseExact(parts[1], "yyyy.MM.dd", null), parts[2].Trim('"'), Convert.ToInt32(parts[3]), parts[4].Trim('"'));
            }
            else
            {
                return new IncomeFromAnIndividual(parts[0].Trim('"'), DateTime.ParseExact(parts[1], "yyyy.MM.dd", null), parts[2].Trim('"'), Convert.ToInt32(parts[3]), parts[4].Trim('"'));
            }
        }
    }
}