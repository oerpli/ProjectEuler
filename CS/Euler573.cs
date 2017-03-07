using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Collections;



namespace EulerSharp
{
    class Problem573
    {
        private Random rnd = new Random();
        private int N;
        double[] inv;
        public void Solve(int N = 10)
        {
            this.N = N;

            inv = new double[N];
            for (int i = 0; i < N; i++)
            {
                inv[i] = 1.0 / (i + 1);
            }




            var winner = new int[N];
            int runs = 10000000;
            for (int i = 0; i < runs; i++)
            {
                winner[Test()]++;
            }
            double exp = 0;
            for (int i = 0; i < N; i++)
            {
                exp += (i + 1) * winner[i];
            }
            exp /= runs;
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"{i + 1}: {(double)winner[i] / runs * N * N}");
            }
            Console.WriteLine(exp);
        }

        public int Test()
        {
            var starts = new List<double>();
            for (int i = 0; i < N; i++)
            {
                starts.Add(rnd.NextDouble());
            }
            starts.Sort();
            var wtime = 10000.0;
            var winner = 0;


            for (int i = 0; i < N; i++)
            {
                var itime = starts[i] * inv[i];
                if (itime < wtime)
                {
                    wtime = itime;
                    winner = i;
                }
            }
            return winner;
        }
    }
}
