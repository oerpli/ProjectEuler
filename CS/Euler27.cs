using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Collections;

namespace EulerSharp
{
    class Problem27
    {
        public int Solve()
        {
            int maxa = a;
            int maxb = b;
            int maxcount = 0;
            while (a < 1000)
            {
                int n = 0;
                int count = 0;


                while (isPrime(Polynom(n)))
                {
                    n = n + 1;
                    count = count + 1;
                }
                if (count > maxcount)
                {
                    maxa = a;
                    maxb = b;
                    maxcount = count;
                    Console.WriteLine($"{count}: a = {a}, b={b}");
                }
                b++;
                if (b == 1000)
                {
                    a++;
                    b = 0;
                }
            }
            return maxa * maxb;
        }

        public bool isPrime(int n)
        {
            if (n < 3) return n == 2;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        private int a = -999, b = -999;
        public int Polynom(int n)
        {
            return n * n + a * n + b;
        }
    }
}
