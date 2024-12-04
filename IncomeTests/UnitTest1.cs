using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using IncomeLab;

namespace IncomeTests
{
    [TestClass]
    public class TestForCorrectStringProcessing
    {
        [TestMethod]
        public void TestStringEnteredCorrectly()
        {
            string expected = "Доходы компании:\n Дата: 2023.05.01\n Источник: Сдача гаража в аренду\n Сумма: 35000 р\n Тип операции: Перевод на сбер\n";
            string[] lists = { "\"Доходы компании\" 2023.05.01 \"Сдача гаража в аренду\" 35000 \"Перевод на сбер\"" };

            string actual = IncomeFactory.ListToObjects(lists)[0].LineOutput();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompanyIncomeFromSrtr()
        {
            string str = "\"Доходы компании\" 223 \"Сдача гаража в аренду\" 35000";
            IncomeFactory.ListToObjects(str);

            var actual = IncomeFactory.exceptionlist[0];

            Assert.AreEqual(expected, actual);
            IncomeFactory.exceptionlist.Clear();
        }

        [TestMethod]
        public void TestNotCorrectDateFormat()
        {
            string expected = "Ошибка: Строка не распознана как действительное значение DateTime.";
            string[] lists = { "\"Доходы компании\" 223 \"Сдача гаража в аренду\" 35000" };
            IncomeFactory.ListToObjects(lists);

            var actual = IncomeFactory.exceptionlist[0];

            Assert.AreEqual(expected, actual);
            IncomeFactory.exceptionlist.Clear();
        }

        [TestMethod]
        public void TestUnknownTypeOfIncome()
        {
            string expected = "Ошибка: Неизвестный тип дохода: Доходы ИП";
            string[] lists = { "\"Доходы ИП\" 2024.10.10 \"Продажа мышек WLMouse\" 235000" };
            IncomeFactory.ListToObjects(lists);

            var actual = IncomeFactory.exceptionlist[0];

            Assert.AreEqual(expected, actual);
            IncomeFactory.exceptionlist.Clear();
        }

        [TestMethod]
        public void TestInvalidStringFormat()
        {
            string expected = "Ошибка: Входная строка имела неверный формат.";
            string[] lists = { "\"Доходы компании\" 2024.10.10 Продажа мышек WLMouse 235000 \"Перевод на сбер\"" };
            IncomeFactory.ListToObjects(lists);

            var actual = IncomeFactory.exceptionlist[0];

            Assert.AreEqual(expected, actual);
            IncomeFactory.exceptionlist.Clear();
        }
    }
}
