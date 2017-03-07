using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Collections;



namespace EulerSharp
{


    class Problem566
    {
        public long G(int n)
        {
            long res = 0;
            for (int a = 9; a < n; a++)
            {
                for (int b = a + 1; b < n; b++)
                {
                    for (int c = b + 1; c < n; c++)
                    {
                        res += F(a, b, c);
                    }
                }
            }
            return res;
        }


        private List<bool> markers = new List<bool>();

        private List<double> borders = new List<double>();


        public void Solve(int n = 2)
        {
            ////var x = F(6, 6, 36);


            //cake.AddIntervall(new Interval(0, 60));
            //cake.PrintCake();
            //cake.AddIntervall(new Interval(60, 300));
            //cake.PrintCake();
            //cake.AddIntervall(new Interval(300, 400));
            //cake.PrintCake();


            var cake = new Cake();
            while (true)
            {
                Console.WriteLine("Start End: ");
                var x = Console.ReadLine().Split(' ');
                int s = Convert.ToInt32(x[0]);
                int e = Convert.ToInt32(x[1]);

                cake.AddIntervall(new Interval(s, e));

                cake.PrintCake();
            }
            //var x = F(10, 14, 16);
            //Console.WriteLine(x);
        }
        public long F(int a, int b, int c)
        {
            double A = 360.0 / a;
            double B = 360.0 / b;
            double C = 360.0 / Math.Sqrt((double)c);

            double[] X = { A, B, C };

            var cake = new Cake();
            long i = 0;
            double p = 0;
            bool finished = false;
            do
            {
                if (p >= 360)
                {
                    p -= 360;
                }
                var old = p;
                p += X[i++ % 3];
                finished = cake.AddIntervall(new Interval(old, p));
                if (i % 10000 == 0)
                    cake.PrintCake();
                //Console.ReadKey(true);
            }
            while (!finished);

            return i;
        }

        class Interval
        {
            public double Start;
            public double End;
            public bool Flipped;

            public Interval(double a, double b)
            {
                Start = a;
                End = b;
            }
            public Interval(double a, double b, bool x)
            {
                Start = a;
                End = b;
                Flipped = x;
            }

            public override string ToString()
            {
                return $"{Start} \t{End} \t:{Flipped}";
            }
        }

        class Cake
        {
            public List<Interval> Regions = new List<Interval>();
            public List<Interval> Active = new List<Interval>();

            public int R { get { return Regions.Count; } }
            public int A { get { return Active.Count; } }

            public Cake()
            {
                Regions.Add(new Interval(0, 360));
            }


            public bool AddIntervall(Interval x)
            {
                //Console.WriteLine("Adding: \t" + x.ToString());
                Active = new List<Interval>();
                if (x.End <= 360)
                {
                    AddInt(x);
                    Flip(x);
                }
                else
                {
                    AddInt(new Interval(0, x.End - 360));

                    AddInt(new Interval(x.Start < 360 ? x.Start : x.Start - 360, 360));

                    foreach (var a in Active)
                    {
                        if (a.End < x.Start)
                        {
                            a.Start += 360;
                            a.End += 360;
                        }
                        Active = Active.OrderBy(y => y.Start).ToList();
                    }

                    Flip(x);
                }
                return Merge();
            }

            private void AddInt(Interval x)
            {
                // first find active interval at start
                int i = 0;
                while (i < R && x.Start >= Regions[i].End)
                {
                    i++;
                }
                if (i < R)
                {
                    Active.Add(Regions[i]);

                    //split if first not completely contained
                    if (Active[A - 1].Start < x.Start)
                    {
                        Regions.Insert(i, new Interval(Active[0].Start, x.Start, Active[0].Flipped));
                        Active[0].Start = x.Start;
                    }
                }
                // then find all intervals completely inside new interval
                while (i < R - 1 && x.Start < Regions[i].Start && x.End > Regions[i].End)
                {
                    Active.Add(Regions[i]);
                    i++;
                }

                // then find interval active at end
                while (i < R - 1 && x.Start < Regions[i].Start && x.End < Regions[i].End)
                {
                    Active.Add(Regions[i]);
                    i++;
                }
                // Split if necessary
                if (i < R && Regions[i].End > x.End)
                {
                    Regions.Insert(i + 1, new Interval(x.End, Regions[i].End, Regions[i].Flipped));
                    Active[A - 1].End = x.End;
                }

            }

            public void Flip(Interval x)
            {
                // flip everything
                foreach (var a in Active)
                {
                    a.Flipped = !a.Flipped;
                    var s = a.Start;
                    var e = a.End;
                    a.Start = x.Start + (x.End - e);
                    a.End = x.End - (s - x.Start);
                }


            }

            private bool Merge()
            {
                var addR = new List<Interval>();
                foreach (var r in Regions)
                {
                    if (r.Start < 360 && r.End > 360)
                    {
                        addR.Add(new Interval(0, r.End - 360, r.Flipped));
                        r.End = 360;
                    }
                    else if (r.Start > 360 && r.End > 360)
                    {
                        r.Start -= 360;
                        r.End -= 360;
                    }
                }
                Regions.AddRange(addR);
                Regions = Regions.OrderBy(a => a.Start).ToList();
                // merge intervals if possible
                for (int f = 0; f < R; f++)
                {
                    while (f >= 0 && f < R - 1 && Regions[f].Flipped == Regions[f + 1].Flipped)
                    {
                        Regions[f].End = Regions[f + 1].End;
                        Regions.RemoveAt(f + 1);
                        f--;
                    }
                }
                if (Regions[0].Start == 0 && Regions[0].End == 360 && Regions[0].Flipped == false)
                {
                    return true;
                }
                return false;
            }
            public void PrintCake()
            {
                foreach (var R in Regions)
                {
                    Console.WriteLine(R.ToString());
                }
                Console.WriteLine();
            }
        }
    }
}
