using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.IO;




namespace _1_Laba_3sem
{
    abstract class BasicIncomeType : ICloneable
    {
        //object ICloneable.Clone()
        //{
        //    return Clone();
        //}
        //public virtual Clone();
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public virtual void ReadFromString(List<string> parts)
        { }
        public virtual string LineOutput()
        {
            return "Тип: его элементы";
        }
    }
    class Income : BasicIncomeType 
    { 
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Source { get; set; }
        public int Amount { get; set; }

        public override void ReadFromString(List<string> parts)
        {
            Type = parts[0].Trim('"');
            Date = DateTime.ParseExact(parts[1], "yyyy.MM.dd", null);
            Source = parts[2].Trim('"');
            Amount = Convert.ToInt32(parts[3]);
        }
        public override string LineOutput()
        {
            return $"{Type}:\n Дата: {Date.ToString("yyyy.MM.dd")}\n Источник: {Source}\n Сумма: {Amount} р\n";
        }
    }
    class Operation : BasicIncomeType
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Source { get; set; }
        public int Amount { get; set; }
        public string TypeOfOperation { get; set; }

        public override void ReadFromString(List<string> parts)
        {
            Type = parts[0].Trim('"');
            Date = DateTime.ParseExact(parts[1], "yyyy.MM.dd", null);
            Source = parts[2].Trim('"');
            Amount = Convert.ToInt32(parts[3]);
            TypeOfOperation = parts[4].Trim('"');
        }
        public override string LineOutput()
        {
            return $"{Type}:\n Дата: {Date.ToString("yyyy.MM.dd")}\n Источник: {Source}\n Сумма: {Amount} р\n Тип операции: {TypeOfOperation}\n";
        }
    }
    class IncomeFromAnIndividual : BasicIncomeType
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Source { get; set; }
        public int Amount { get; set; }
        public string SenderName { get; set; }

        public override void ReadFromString(List<string> parts)
        {
            Type = parts[0].Trim('"');
            Date = DateTime.ParseExact(parts[1], "yyyy.MM.dd", null);
            Source = parts[2].Trim('"');
            Amount = Convert.ToInt32(parts[3]);
            SenderName = parts[4].Trim('"');
        }
        public override string LineOutput()
        {
            return $"{Type}:\n Дата: {Date.ToString("yyyy.MM.dd")}\n Источник: {Source}\n Сумма: {Amount} р\n Имя отправителя: {SenderName}\n";
        }
    }
}