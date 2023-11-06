using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_6_nunit_tests
{
    internal class Calculator
    {
        public int add(int x, int y) {
                return x + y;    
        }
        public int sub(int x, int y)
        {
            return x - y;
        }

        public int mod(int a, int b)
        {
            if (b <= 0) throw new ArgumentException("Делитель должен быть >= 0");
            return a % b;
        }

        public bool isEven(int n)
        {
            return n % 2 == 0;
        }


        static void Main(string[] args)
        {
            


        }
    }
}
