using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.IO;


namespace IncomeLab
{
    public class IncomeFactory
    {
        public static string[] StrFromFiles(string filePath)
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

        public static List<string> exceptionlist = new List<string>();

        public static List<BasicIncomeType> ListToObjects(string[] lists)
        {
            List<BasicIncomeType> ObjectsList = new List<BasicIncomeType>();

            Dictionary<string, BasicIncomeType> strToIncome = new Dictionary<string, BasicIncomeType> { 
                {"Доходы", new Income() },
                {"Доходы компании", new Operation()},
                {"Доходы физ.лица", new IncomeFromAnIndividual()}
            };
            

            foreach (string stroka in lists)
            {
                try
                {
                    var parts = ParseString(stroka);

                    string firstWord = parts[0].Trim('"');
                    if (!new List<string>{"Доходы", "Доходы компании", "Доходы физ.лица"}.Contains(firstWord))       
                    {
                        throw new Exception($"Неизвестный тип дохода: {firstWord}");
                    }
                    strToIncome[firstWord].ReadFromString(parts);
                    ObjectsList.Add((BasicIncomeType)strToIncome[firstWord].Clone());
                }
                catch (Exception ex)
                {
                    exceptionlist.Add($"Ошибка: {ex.Message}");
                }
            }
            return ObjectsList;
        }
    }














}