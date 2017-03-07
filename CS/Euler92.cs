using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Collections;



namespace EulerSharp
{
    class Problem92
    {
        const int digits = 7;
        const int max = digits * 81;

        bool[] filter = new bool[max + 1];

        public long Solve()
        {

            Filter();
            long result = 0;
            for (int i = 1; i <= max; i++)
            {
                if (filter[i]) // if this digitsquaresum leads to 89 take the number of possible ways to sum up to this number with digits squares of a digit
                    result += g(i, digits);
            }
            Console.WriteLine(result);
            return 0;
        }

        private void Filter()
        {
            for (int i = 0; i <= max; i++)
            {
                filter[i] = Status(i);
            }
        }

        private bool Status(int n)
        {
            if (n <= 1) return false;
            if (n == 89) return true;
            return Status(squaresum(n));
        }

        private int squaresum(int n)
        {
            if (n == 0) return 0;
            return (n % 10) * (n % 10) + squaresum(n / 10);
        }

        long f(int n, int k)
        {
            long result = 0;
            for (int i = 0; i < 10; i++)
            {
                result += g(n - i * i, k - 1); // recurrence formula: number to sum up to n with k digits is equal to the number to sum up all ways to the previous number
            }
            return result;
        }

        long?[,] G = new long?[max + 1, digits + 1];
        long g(int n, int k) // memoization
        {
            if (n < 0) return 0;
            if (G[n, k] == null)
            {
                if (n > 0 && k == 0) G[n, k] = 0;
                else if (n == 0 && k == 0) G[n, k] = 1;
                else G[n, k] = f(n, k);
            }
            return G[n, k] ?? 0;
        }
    }
}


