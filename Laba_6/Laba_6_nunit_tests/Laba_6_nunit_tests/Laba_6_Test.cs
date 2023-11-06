using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// подключение NUnit
using NUnit.Framework;

namespace Laba_6_nunit_tests
{
    // атрибут, указывающий на то, что это класс содержит тесты
    [TestFixture]
    internal class Laba_6_Test
    {
        Calculator calculator = new Calculator();
        // атрибут, указывающий на то, что это тестовый метод
        [TestCase]
        public void TestAdd()
        {
            // тестирование функции сложения
            // если результат вызова функции не равен 33, тест не будет пройден
            Assert.AreEqual(33, calculator.add(3, 30));
        }
        
        [TestCase]
        public void TestSub()
        {
            // тестирование функции вычитания
            Assert.AreEqual(323, calculator.sub(326, 3));
        }

        [TestCase]
        public void TestMod()
        {
            // получение исключения
            var exception = Assert.Throws<ArgumentException>(() => calculator.mod(2, 0));
            // сравнение полученного сообщения с ожидаемым
            Assert.That(exception.Message, Is.EqualTo("Делитель должен быть >= 0"));
            // проверка выполняется успешно, если исключение не было сгенерировано
            Assert.DoesNotThrow(() => calculator.mod(2, 1));
        }

        [TestCase]
        public void TestIsEven()
        {
            // проверка возвращаемого значения
            // в первом случае оно должно быть истинно, во втором ложно
            Assert.IsTrue(calculator.isEven(4));
            Assert.IsFalse(calculator.isEven(5));
        }




    }
}
