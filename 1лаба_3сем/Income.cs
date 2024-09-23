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
            var parts = MainString.ParseString(input);
            Type = parts[0].Trim('"');
            Date = DateTime.ParseExact(parts[1], "yyyy.MM.dd", null);
            Source = parts[2].Trim('"');
            Amount = Convert.ToInt32(parts[3]);
        }

        public virtual string LineOutput()
        {
            return $"{Type}: Дата: {Date.ToString("yyyy.MM.dd")}, Источник: {Source}, Сумма: {Amount}";
        }
    }
    class Operation : Income
    {
        public string TypeOfOperation { get; set; }

        public Operation(string input) : base(input)
        {
            var parts = MainString.ParseString(input);
            TypeOfOperation = parts[4].Trim('"');
        }

        public override string LineOutput()
        {
            return $"{Type}: Дата: {Date.ToString("yyyy.MM.dd")}, Источник: {Source}, Сумма: {Amount}, Тип операции: {TypeOfOperation}";
        }
    }
    class IncomeFromAnIndividual : Income
    {
        public string SenderName { get; set; }

        public IncomeFromAnIndividual(string input) : base(input)
        {
            var parts = MainString.ParseString(input);
            SenderName = parts[4].Trim('"');
        }
        public override string LineOutput()
        {
            return $"{Type}: Дата:  {Date.ToString("yyyy.MM.dd")} , Источник:  {Source} , Сумма:  {Amount}, Имя отправителя: {SenderName}";
        }
    }

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

        public string ObjectOutput(string stroka)
        {
            var parts = ParseString(stroka);

            if (parts[0].Trim('"') == "Доходы")
            {
                Income type1 = new Income(stroka);
                 return type1.LineOutput();
            }
            else if (parts[0].Trim('"') == "Доходы компании")
            {
                Operation type2 = new Operation(stroka);
                return type2.LineOutput();
            }
            else if (parts[0].Trim('"') == "Доходы физ.лица")
            {
                IncomeFromAnIndividual type3 = new IncomeFromAnIndividual(stroka);
                return type3.LineOutput();
            }
            else
                return "Возникла ошибка";
        }
    }
}