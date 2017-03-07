using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Collections;



namespace EulerSharp
{
    class Extensions
    {

    }

    class Problem571
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
                if (CheckNPan(x))
                {
                    res.Add(x);
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

        int N = 12;
        public void Solve(int NN = 10)
        {
            string str = "0123456789ABCDEFG".Substring(0, N);
            char[] arr = str.ToCharArray();

            var result = new List<string>();
            GetPer(result, str.ToCharArray());

            result.Sort();
            var x = result.Take(10).Select(a => ArbitraryToDecimalSystem(a, N)).Sum();
            Console.WriteLine(x);
        }


        public bool CheckNPan(string number)
        {
            long i = ArbitraryToDecimalSystem(number, N);
            //Console.WriteLine(y.ToString());
            for (int r = N; r > 1; r--)
            {
                if (!IsNPanDigital(i, r))
                    return false;
            }
            return true;
        }

        // http://stackoverflow.com/questions/923771/quickest-way-to-convert-a-base-10-number-to-any-base-in-net
        // To get the representation in base n
        public static bool IsNPanDigital(long decimalNumber, int radix)
        {
            var DigitsTaken = new bool[radix];

            int x = 0;
            while (decimalNumber != 0)
            {
                int remainder = (int)(decimalNumber % radix);
                if (!DigitsTaken[remainder])
                {
                    x++;
                    if (x == radix)
                        return true;
                    DigitsTaken[remainder] = true;
                }
                decimalNumber = decimalNumber / radix;
            }
            return false;
        }

        public static long ArbitraryToDecimalSystem(string number, int radix)
        {
            const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            // Make sure the arbitrary numeral system number is in upper case
            //number = number.ToUpperInvariant();

            long result = 0;
            long multiplier = 1;
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
