using System;
using System.Globalization;

namespace _1_Laba_3sem
{

    abstract class BaseStr
    {
        public virtual string LineOutput()
        {
            return "";
        }
    }
    class Income : BaseStr
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Source { get; set; }
        public int Amount { get; set; }

        public Income(string type, DateTime date, string source, int amount)
        {
            //var parts = MainString.ParseString(input);
            Type = type;
            Date = date;
            Source = source;
            Amount = amount;
            //Type = parts[0].Trim('"');
            //Date = DateTime.ParseExact(parts[1], "yyyy.MM.dd", null);
            //Source = parts[2].Trim('"');
            //Amount = Convert.ToInt32(parts[3]);
        }

        public override string LineOutput()
        {
            return $"{Type}:\n Дата: {Date.ToString("yyyy.MM.dd")}\n Источник: {Source}\n Сумма: {Amount} р\n";
        }
    }
    class Operation : BaseStr
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Source { get; set; }
        public int Amount { get; set; }
        public string TypeOfOperation { get; set; }

        public Operation(string type, DateTime date, string source, int amount, string operation)
        {
            //var parts = MainString.ParseString(input);
            Type = type;
            Date = date;
            Source = source;
            Amount = amount;
            TypeOfOperation = operation;
        }

        public override string LineOutput()
        {
            return $"{Type}:\n Дата: {Date.ToString("yyyy.MM.dd")}\n Источник: {Source}\n Сумма: {Amount} р\n Тип операции: {TypeOfOperation}\n";
        }
    }
    class IncomeFromAnIndividual : BaseStr
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Source { get; set; }
        public int Amount { get; set; }
        public string SenderName { get; set; }

        public IncomeFromAnIndividual(string type, DateTime date, string source, int amount, string name)
        {
            //var parts = MainString.ParseString(input);
            Type = type;
            Date = date;
            Source = source;
            Amount = amount;
            SenderName = name;
        }
        public override string LineOutput()
        {
            return $"{Type}:\n Дата: {Date.ToString("yyyy.MM.dd")}\n Источник: {Source}\n Сумма: {Amount} р\n Имя отправителя: {SenderName}\n";
        }
    }
}