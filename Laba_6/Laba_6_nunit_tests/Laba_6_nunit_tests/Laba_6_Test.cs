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

        // ############## 1 Test ##############
        [TestCase]
        public void TestInches_to_cm()
        {
            Assert.AreEqual(7.62, calculator.inches_to_cm(3));
        }


        // ############## 2 Test ##############
        [TestCase]
        public void TestIsEven()
        {
            Assert.IsTrue(calculator.isEven(4));
            Assert.IsFalse(calculator.isEven(5));
        }


        // ############## 3 Test ##############
        [TestCase]
        public void TestMax_in_arr()
        {
            int [] arr  = { 1, 2, 3 };
            Assert.AreEqual(3, calculator.max_in_arr(arr));
        }


        // ############## 4 Test ##############
        [TestCase]
        public void TestRemainder_of_division()
        {
            Assert.AreEqual(1, calculator.remainder_of_division(7, 2));
            Assert.AreEqual(0, calculator.remainder_of_division(8, 2));
        }

    }
}
