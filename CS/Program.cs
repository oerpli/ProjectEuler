using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EulerSharp
{
    class Program
    {

        static void Main(string[] args)
        {
            var s = new Stopwatch();
            var x = new Problem243b();
            {
                s.Start();
                var b = x.Solve();

                //for (int z = 0; z < 1000; z++)
                //{
                //    b = x.Solve();
                //}
                s.Stop();
                Console.WriteLine(s.ElapsedMilliseconds + "ms" + " " + b);
            }
            Console.ReadKey(true);
        }
    }
}
