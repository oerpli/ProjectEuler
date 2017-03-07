using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Collections;



namespace EulerSharp
{
    class Problem243
    {
        List<List<int>> factors = new List<List<int>>();
        const double Target = 15499.0 / 94744;
        public long Solve()
        {
            var ratio = 1.0;
            int D = 1;

            factors.Add(new List<int>());
            factors.Add(new List<int>());

            factors.Add(new List<int>() { 2 });
            var minratio = ratio;
            while (ratio >= Target)
            {
                D++;

                var tar = Target * (D - 1);
                bool abort = false;
                while (factors.Count <= D)
                {
                    factors.Add(Factor(factors.Count));
                }
                double disj = 1;
                for (int d = 2; d < D; d++)
                {
                    if (factors[D].Count < 5)
                    {
                        abort = true; break;
                    }
                    if (Disjunct(d, D))
                    {
                        disj += 1;
                        if (disj > tar)
                        {
                            //abort = true;
                            disj += 1;
                            break;
                        }
                    }
                }
                if (!abort)
                {
                    ratio = disj / (D - 1);
                    if (ratio < minratio)
                    {
                        minratio = ratio;
                        Console.WriteLine($"New minRatio {D}: {ratio} (Target: {Target}");
                    }
                }
            }
            Console.WriteLine(D);
            return 0;
        }

        private bool Disjunct(int d, int D)
        {
            var x = factors[d];
            var X = factors[D];
            int i = 0;
            int j = 0;
            while (i < x.Count && j < X.Count)
            {
                if (x[i] < X[j])
                {
                    i++;
                }
                else if (X[j] < x[i])
                {
                    j++;
                }
                else if (X[j] == x[i])
                {
                    return false;
                }
            }
            return true;
        }

        public List<int> Factor(int number)
        {
            List<int> factors = new List<int>();
            int max = (int)Math.Sqrt(number);  //round down
            for (int factor = 1; factor <= max; ++factor)
            { //test from 1 to the square root, or the int below it, inclusive.
                if (number % factor == 0)
                {
                    if (factor > 1)
                        factors.Add(factor);

                    if (factor != number / factor)
                    { // Don't add the square root twice!  Thanks Jon
                        factors.Add(number / factor);
                    }
                }
            }
            factors.Sort();
            return factors;
        }
    }


    class Problem243b
    {

        #region PrimeStuff
        List<int> Primes = new List<int>() { 2, 3, 5 }; // add the first 3 so the loop later only needs to check for prime[i] < sqrt(new_prime?)
        private void ExtendPrimes(int Max)
        {
            var n = Primes.Last() + 2;
            while (n <= Max)
            {
                var biggest = Math.Sqrt(n) + 1;
                bool prime = true;
                for (int i = 0; Primes[i] < biggest; i++)
                {
                    if (n % Primes[i] == 0)
                    {
                        prime = false;
                        break;
                    }
                }
                if (prime)
                {
                    Primes.Add(n);
                }
                n += 2;
            }
        }

        private List<int> PrimeFactors(int n)
        {
            ExtendPrimes(n);
            var x = new List<int>();
            if (Primes.Last() == n)
            {
                x.Add(n);
                return x;
            }
            int i = 0;
            int max = (int)Math.Sqrt(n) + 2;
            while (Primes[i] <= max)
            {
                if (n % Primes[i] == 0)
                {
                    x.Add(Primes[i]);
                }
                i++;
            }
            return x;
        }

        public static List<long> PrimeFactorsNaive(long number)
        {
            var primes = new List<long>();

            long div = 2;
            if (number % div == 0)
            {
                primes.Add(div);
                while (number % div == 0)
                {
                    number = number / div;
                }
            }
            for (div = 3; div <= number; div += 2)
            {
                if (number % div == 0)
                {
                    primes.Add(div);
                    while (number % div == 0)
                    {
                        number = number / div;
                    }
                }
            }
            return primes;
        }

        #endregion


        private Dictionary<int, int> Count = new Dictionary<int, int>();

        private void UpdateDictionary(IEnumerable<Tuple<int, int>> subs)
        {
            foreach (var sub in subs)
            {
                Count[sub.Item1]++;
            }
        }


        private void UpdateDictionary(List<int> primeFactors)
        {
            var subs = MultSubsets(primeFactors);
            foreach (var sub in subs)
            {
                if (Count.ContainsKey(sub.Item1))
                {
                    Count[sub.Item1]++;
                }
                else
                {
                    Count[sub.Item1] = 0;
                }
            }
        }

        private int GetPIE(List<int> primeFactors)
        {
            var subs = MultSubsets(primeFactors);
            int result = 0;

            foreach (var sub in subs)
            {
                if (Count.ContainsKey(sub.Item1))
                {
                    var factor = (sub.Item2 % 2 == 0 ? -1 : 1);
                    var add = Count[sub.Item1] * factor;
                    result += add;
                }
                else
                {
                    Count[sub.Item1] = 0; // initialize -- needed later
                }
            }
            UpdateDictionary(subs); // do this here so subsets are calculated only once. more efficient but uglier
            return result;
        }


        internal void SolveOld()
        {
            var s = new Stopwatch();

            int D = 2;
            var target = 15499.0 / 94744;
            var minratio = 1.0;
            var maxfactors = 0;
            s.Start();
            while (minratio > target)
            {
                var factors = PrimeFactors(D);
                if (factors.Count >= maxfactors)
                {
                    double pie = GetPIE(factors);
                    maxfactors = factors.Count;
                    var ratio = (D - 1 - pie) / (D - 1);
                    if (ratio < minratio)
                    {
                        s.Stop();
                        Console.WriteLine($"D = {D}, factors = {factors.Count()}: {pie}; {ratio}, {s.ElapsedMilliseconds}ms");
                        minratio = ratio;
                        s.Reset();
                        s.Start();
                    }
                }
                else
                {
                    UpdateDictionary(factors);
                }

                D++;
            }
        }
        #region General Helpers

        public static IEnumerable<IEnumerable<T>> Subsets<T>(IEnumerable<T> source)
        {
            List<T> list = source.ToList();
            int length = list.Count;
            int max = (int)Math.Pow(2, list.Count);

            for (int count = 0; count < max; count++)
            {
                List<T> subset = new List<T>();
                uint rs = 0;
                while (rs < length)
                {
                    if ((count & (1u << (int)rs)) > 0)
                    {
                        subset.Add(list[(int)rs]);
                    }
                    rs++;
                }
                yield return subset;
            }
        }
        public static IEnumerable<Tuple<int, int>> MultSubsets(List<int> list)
        {
            int length = list.Count;
            int max = (int)Math.Pow(2, list.Count);

            for (int count = 0; count < max; count++)
            {
                int subset = 1; // integer instead of list
                uint rs = 0;
                var countF = 0;
                while (rs < length)
                {
                    if ((count & (1u << (int)rs)) > 0)
                    {
                        subset *= (list[(int)rs]); // multiplication instead of .Add
                        countF++;
                    }
                    rs++;
                }
                if (countF > 0)
                    yield return new Tuple<int, int>(subset, countF);
            }
        }

        #endregion



        private long PrimeProduct(int n)
        {
            ExtendPrimes(n * n);
            long result = 1;
            for (int i = 0; i < n; i++)
            {
                result *= Primes[i];
            }
            return result;
        }

        internal long Solve()
        {
            ExtendPrimes(30);
            var p = 0;
            var ratio = 1.0;
            var target = 15499.0 / 94744;
            while (ratio > target)
            {
                ratio = Res(PrimeProduct(++p));
            }
            long D0 = PrimeProduct(--p);
            for (int i = 2; i <= Primes[p]; i++)
            {
                ratio = Res(D0 * i);
                if (ratio < target)
                {
                    Console.WriteLine($"Smallest value: {D0 * i} p = {p}, i = {i}");
                    return D0 * i;
                    //break;
                }
            }
            return -1;
        }


        public double Res(long n)
        {
            return (double)phi(n) / (n - 1);
        }

        public double Rat(long n)
        {
            return (double)n / phi(n);
        }


        long phi(long n)
        {
            double result = n;   // Initialize result as n
            var primes = PrimeFactorsNaive(n);
            foreach (var p in primes)
            {
                while (n % p == 0)
                    n /= p;
                result *= (1.0 - (1.0 / (double)p));
            }
            return (long)result;
        }


    }


}


