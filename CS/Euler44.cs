using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
namespace ConsoleApplication
{
    public class Program44
    {
        private static string[] data;

        static bool test = false;
        public static void Main2(string[] args)
        {
            Solve();
        }

        public static void Solve()
        {
            var x = Enumerable.Range(0, 1000).Select(y => GetTriangles(y)).ToArray();
            var m = x.Max();
            for (int i = 0; i < x.Count(); i++)
            {
                if (x[i] == m)
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static int GetTriangles(int n)
        {
            int x = 0;
            for (int a = 1; a < n - 1; a++)
            {
                for (int b = a; b < n - 1; b++)
                {
                    int c = n - (a + b);
                    if (a * a + b * b == c * c)
                    {
                        // Console.WriteLine($"{a} {b} {c}");
                        x++;
                    }
                }
            }
            return x;
        }
    }
}