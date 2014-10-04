using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSharp {
    class Problem14 {
        const long N = 1000000;
        long[] n = new long[N + 1];
        HashSet<long> active = new HashSet<long>(); //Save all elements that are computed at the moment

        public long Solve() {
            n[1] = 0;
            int index = 2;
            while(index < N) {
                while(index < N && n[index] != 0) {
                    index++;// iterate to get smallest not yet computed result
                }

                long current = index;
                active.Add(current); // smallest index that has n[index] == 0 will be active for now
                do {
                    foreach(var act in active) {
                        n[act]++;
                    }
                    current = collatz(current);
                    if(current <= N) {
                        if(active.Add(current) && n[current] > 0) {
                            active.Remove(current);
                            foreach(var act in active) {
                                n[act] += n[current];
                            }
                            current = 1; //to break the loop
                        }
                    }
                } while(current != 1);
                active.Clear();
            }
            long max = n.Max();
            int imax = n.ToList().FindIndex(t => t == max);
            Console.WriteLine(imax + ": " + n[imax+1]);
            return imax;
        }


        public long Solve2() {
            n[1] = 0;
            int index = 2;
            while(index < N) {
                while(index < N && n[index] != 0) {
                    index++;// iterate to get smallest not yet computed result
                }

                long current = index;
                long count = 0;
                do {
                    count++;
                    current = collatz(current);
                    if(current <= N && n[current] > 0) {
                        count += n[current];
                        current = 1;
                    }
                } while(current != 1);
                n[index] = count;
                active.Clear();
            }
            long max = n.Max();
            int imax = n.ToList().FindIndex(t => t == max);
            Console.WriteLine(imax + ": " + n[imax]);
            return imax;
        }

        private long collatz(long n) {
            if(n == 1) return 1;
            if(n % 2 == 0)
                return n / 2;
            else
                return 3 * n + 1;
        }
    }
}
