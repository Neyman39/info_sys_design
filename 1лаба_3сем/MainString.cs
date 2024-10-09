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

            Dictionary<string, BasicIncomeType> strToIncome = new Dictionary<string, BasicIncomeType> { 
                {"Доходы", new Income() },
                {"Доходы компании", new Operation()},
                {"Доходы физ.лица", new IncomeFromAnIndividual()} 
            };

            foreach (string stroka in lists)
            {
                var parts = ParseString(stroka);

                string firstWord = parts[0].Trim('"');
                strToIncome[firstWord].ReadFromString(parts);

                // exception

                ObjectsList.Add((BasicIncomeType)strToIncome[firstWord].Clone());
            }
            return ObjectsList;
        }
    }
}