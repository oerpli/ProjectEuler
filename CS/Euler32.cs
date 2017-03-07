using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Collections;



namespace EulerSharp
{
    class Problem32
    {

        private void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            a ^= b;
            b ^= a;
            a ^= b;
        }

        public void GetPer(List<string> res, char[] list)
        {
            int x = list.Length - 1;
            GetPer(res, list, 0, x);
        }

        private void GetPer(List<string> res, char[] list, int k, int m)
        {
            if (k == m && list[0] != '0')
            {
                var x = new String(list);
                if (isProd(x) > 0)
                {
                    int aa = (int)ArbitraryToDecimalSystem(x.Substring(0, 4), N);
                    if (!res.Contains(aa.ToString()))
                    {
                        res.Add(aa.ToString());
                    }
                    if (res.Count % 10 == 0) Console.WriteLine("Added 10");
                    res.Sort();
                    var sm = res.Take(10).Select(a => ArbitraryToDecimalSystem(a, N)).Sum();
                    Console.WriteLine(res.Count + ": " + sm);
                }
            }
            else
                for (int i = k; i <= m; i++)
                {
                    Swap(ref list[k], ref list[i]);
                    GetPer(res, list, k + 1, m);
                    Swap(ref list[k], ref list[i]);
                }
        }

        int N = 10;
        public void Solve(int NN = 10)
        {
            string str = "123456789".Substring(0, 9);
            char[] arr = str.ToCharArray();

            var result = new List<string>();
            GetPer(result, str.ToCharArray());

            result.Sort();
            var x = result.Take(10).Select(a => ArbitraryToDecimalSystem(a, N)).Sum();
            Console.WriteLine(x);
        }


        public int isProd(string number)
        {
            int a = ArbitraryToDecimalSystem(number.Substring(0, 4), N);
            int b = ArbitraryToDecimalSystem(number.Substring(4, 2), N);
            int c = ArbitraryToDecimalSystem(number.Substring(6, 3), N);
            if (a == b * c)
            {
                Console.WriteLine($"{b} {c}  = {a}");
                return a;
            }
            a = ArbitraryToDecimalSystem(number.Substring(0, 5), N);
            b = ArbitraryToDecimalSystem(number.Substring(5, 1), N);
            c = ArbitraryToDecimalSystem(number.Substring(6, 3), N);
            if (a == b * c)
            {
                Console.WriteLine($"{b} {c}  = {a}");
                return a;
            }
            a = ArbitraryToDecimalSystem(number.Substring(0, 4), N);
            b = ArbitraryToDecimalSystem(number.Substring(4, 4), N);
            c = ArbitraryToDecimalSystem(number.Substring(8, 1), N);
            if (a == b * c)
            {
                Console.WriteLine($"{b} {c}  = {a}");
                return a;
            }
            return 0;
        }

        public static int ArbitraryToDecimalSystem(string number, int radix)
        {
            const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            // Make sure the arbitrary numeral system number is in upper case
            //number = number.ToUpperInvariant();

            int result = 0;
            int multiplier = 1;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                char c = number[i];
                int digit = Digits.IndexOf(c);
                result += digit * multiplier;
                multiplier *= radix;
            }
            return result;
        }
    }
}
