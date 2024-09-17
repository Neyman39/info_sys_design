using System;

namespace _1_Laba_3sem
{
    class Income
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Source { get; set; }
        public int Amount { get; set; }

        public static string FromString(string input)
        {
            Income income = new Income();

            string[] parts = input.Split(':');
            string[] words = parts[0].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string word = words[0];
            if (words.Length > 1)
            {
                for (int i = 1; i < words.Length; i++)
                {
                    word += $" {words[i]}";
                }
            }
            income.Type = word;

            string[] properties = parts[1].Split(',');
            foreach (string property in properties)
            {
                string[] kv = property.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string key = kv[0];
                string value = kv[1];
                if (kv.Length > 2)
                {
                    for (int i = 2; i < kv.Length; i++)
                    {
                        value += $" {kv[i]}";
                    }
                }

                if (key == "дата")
                {
                    income.Date = DateTime.ParseExact(value, "yyyy.MM.dd", null);
                }
                else if (key == "источник")
                {
                    income.Source = value.Trim('"');
                }
                else if (key == "сумма")
                {
                    income.Amount = Convert.ToInt32(value);
                }
            }

            return $"Тип: {income.Type}\nДата: {income.Date.ToString("yyyy.MM.dd")}\nИсточник: {income.Source}\nСумма: {income.Amount} р";
        }
    }

}