using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace _1_Laba_3sem
{
    class MainString
    {
        public static string[] StrFromFiles(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);
            return fileContent.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static List<string> ParseString(string input)
        {
            return Regex.Matches(input, @"[\""].+?[\""]|[^ ]+")
                         .Cast<Match>()
                         .Select(m => m.Value)
                         .ToList();
        }

        public static List<BasicIncomeType> ObjectOutput(string[] lists)
        {
            List<BasicIncomeType> ObjectsList = new List<BasicIncomeType>();
            foreach (string stroka in lists)
            {
                var parts = ParseString(stroka);
                
                if (parts[0].Trim('"') == "Доходы")
                {
                    Income obj = new Income();
                    obj.ReadFromString(parts);
                    ObjectsList.Add(obj);
                }
                else if (parts[0].Trim('"') == "Доходы компании")
                {
                    Operation obj = new Operation();
                    obj.ReadFromString(parts);
                    ObjectsList.Add(obj);
                }
                else
                {
                    IncomeFromAnIndividual obj = new IncomeFromAnIndividual();
                    obj.ReadFromString(parts);
                    ObjectsList.Add(obj);
                }     
            }
            return ObjectsList;
        }
    }
}