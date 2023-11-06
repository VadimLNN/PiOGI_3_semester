using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    1. Реализовать набор функций:
         функция конвертации дюймов в сантиметры;
         функция проверки числа на чётность;
         функция выбора наибольшего значения из массива целых чисел;
         функция вычисления остатка от деления.
    В случае возникновения ошибки, функции должны возвращать код ошибки.

    2. Написать набор тестовых сценариев для реализованных тестовых функций. Тестовые
        сценарии должны охватывать все ветви выполнения функций.
 */
namespace Laba_6_nunit_tests
{
    internal class Calculator
    {
        // ############## 1 ##############
        public double inches_to_cm(int a)
        { 
            return a * 2.54; 
        }

        // ############## 2 ##############
        public bool isEven(int n)
        {
            return n % 2 == 0;
        }

        // ############## 3 ##############
        public int max_in_arr(int[] a)
        {
            return a.Max(); 
        }

        // ############## 4 ##############
        public int remainder_of_division(int a, int b) 
        {
            return a % b;
        }

        static void Main(string[] args)
        {

        }
    }
}
