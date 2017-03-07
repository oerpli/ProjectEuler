using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Collections;

namespace EulerSharp
{
    class Problem23b
    {

        //public static void Main(string[] args)
        //{
        //    new Problem23b().BruteForce();
        //}
        public List<int> abundants = new List<int>();
        public bool[] canBeWrittenasAbundent;

        public void BruteForce()
        {
            Stopwatch clock = Stopwatch.StartNew();

            const int limit = 22000;
            List<int> abundants = new List<int>();
            int[] primelist = ESieve((int)Math.Sqrt(limit));


            long sum = 0;

            // Find all abundant numbers
            for (int i = 2; i <= limit; i++)
            {
                if (sumOfFactorsPrime(i, primelist) > i)
                {
                    abundants.Add(i);
                }
            }

            Console.WriteLine(abundants.Count);

            // Make all the sums of two abundant numbers
            canBeWrittenasAbundent = new bool[limit + 1];
            for (int i = 0; i < abundants.Count; i++)
            {
                for (int j = i; j < abundants.Count; j++)
                {
                    int v = abundants[i] + abundants[j];
                    if (v <= limit)
                    {
                        switch (v)
                        {
                            case 1771: Console.WriteLine(v + " " + abundants[i] + " " + abundants[j]); break;
                            case 1141: Console.WriteLine(v + " " + abundants[i] + " " + abundants[j]); break;
                            case 7621: Console.WriteLine(v + " " + abundants[i] + " " + abundants[j]); break;
                        }
                        canBeWrittenasAbundent[v] = true;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            int c = 0;
            //Sum the numbers which are not sums of two abundant numbers
            for (int i = 1; i <= limit; i++)
            {
                if (!canBeWrittenasAbundent[i])
                {
                    c++;
                    sum += i;
                }
            }

            Console.WriteLine("Count nonsum: " + c);
            clock.Stop();
            Console.WriteLine("The sum of all numbers that cannot be written as the sum of two abundant numbers is {0}", sum);
            Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
        }

        private int sumOfFactorsPrime(int number, int[] primelist)
        {
            int n = number;
            int sum = 1;
            int p = primelist[0];
            int j;
            int i = 0;

            while (p * p <= n && n > 1 && i < primelist.Length)
            {
                p = primelist[i];
                i++;
                if (n % p == 0)
                {
                    j = p * p;
                    n = n / p;
                    while (n % p == 0)
                    {
                        j = j * p;
                        n = n / p;
                    }
                    sum = sum * (j - 1) / (p - 1);
                }
            }

            //A prime factor larger than the square root remains, so add that
            if (n > 1)
            {
                sum *= n + 1;
            }
            return sum - number;
        }

        public int[] ESieve(int upperLimit)
        {

            int sieveBound = (int)(upperLimit - 1) / 2;
            int upperSqrt = ((int)Math.Sqrt(upperLimit) - 1) / 2;

            BitArray PrimeBits = new BitArray(sieveBound + 1, true);

            for (int i = 1; i <= upperSqrt; i++)
            {
                if (PrimeBits.Get(i))
                {
                    for (int j = i * 2 * (i + 1); j <= sieveBound; j += 2 * i + 1)
                    {
                        PrimeBits.Set(j, false);
                    }
                }
            }

            List<int> numbers = new List<int>((int)(upperLimit / (Math.Log(upperLimit) - 1.08366)));
            numbers.Add(2);
            for (int i = 1; i <= sieveBound; i++)
            {
                if (PrimeBits.Get(i))
                {
                    numbers.Add(2 * i + 1);
                }
            }

            return numbers.ToArray();
        }


    }
}


namespace EulerSharp
{
    class Problem23
    {

        public List<int> abundants = new List<int>();
        //public int M = 20;
        public int M = 22000;


        public List<int> getDivisors(int n)
        {
            var x = new List<int>();

            x.Add(1);
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    x.Add(i);
                    if (n != i * i)
                        x.Add(n / i);
                }
            }
            return x;
        }

        public bool isAbundant(int n, List<int> x)
        {
            return n < x.Sum();
        }


        public int Solve()
        {
            summable = new bool[M + 1];
            for (int i = 1; i < M + 100; i++)
            {
                if (isAbundant(i, getDivisors(i)))
                {
                    abundants.Add(i);
                }
            }

            Console.WriteLine(abundants.Count);

            int sum = 0;
            fillSummable();
            int c = 0;
            for (int i = 0; i <= M; i++)
            {
                if (!summable[i])
                {
                    //Console.WriteLine(i);
                    sum += i;
                    c++;
                }
            }
            Console.WriteLine("Count nonsum: " + c);

            return sum;
        }


        int maxindex = 0;

        public bool[] summable;


        private void fillSummable()
        {
            for (int i = 0; i < abundants.Count; i++)
            {
                for (int j = 0; j < abundants.Count; j++)
                {
                    var v = abundants[i] + abundants[j];
                    if (v > M) { break; }
                    summable[v] = true;
                }
            }
        }

        private bool isSummable(int n)
        {
            if (n < 24) return false;

            while (n > abundants[maxindex + 1])
            {
                maxindex++;
            }
            int lower = 0;
            int maxer = maxindex;
            while (lower <= maxer)
            {
                var v = abundants[lower] + abundants[maxer];
                if (v == n)
                {
                    //Console.WriteLine(n + ": " + abundants[lower] + " " + abundants[maxer]);
                    return true;
                }
                if (v > n)
                    maxer--;
                if (v < n)
                {
                    maxer = maxindex;
                    lower++;
                }
            }
            return false;
        }

        public void PrintList(List<int> x)
        {
            Console.WriteLine(x.Select(a => $" {a}").Aggregate("", (a, b) => a + b));
        }
    }
}
