using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
namespace ConsoleApplication
{
    public class Program42
    {
        private static string[] data;
        private static int N;

        public static void Main2(string[] args)
        {
            // test instance
            var path = @"Y:\OneDrive\Projects\ProjectEuler\data\p042_words.txt";
            data = readData(path);
            Solve();
        }

        public static void Solve()
        {
            var vals = data.Select(x => Value(x));
            var vmax = vals.Max();
            var tri = Triangles().TakeWhile(x => x < vmax);
            var count = vals.Where(x => tri.Contains(x)).Count();
            Console.WriteLine(count);
        }

        public static bool Tri(int t)
        {
            double n = (Math.Sqrt(8 * (double)(t) + 1) - 1) / 2;
            return n == (int)n;
        }
        private static void Nicer()
        {
            var words = File.ReadAllText("p042_words.txt").Split(',').Select(e => e.Trim('\"'));
            var twords = words.Where(w => Tri(w.Sum(c => c - 'A' + 1))).Count();
        }
        public static IEnumerable<int> Triangles()
        {
            int i = 0;
            while (true)
            {
                i++;
                yield return i * (i + 1) / 2;
            }
        }

        public static int Value(string word)
        {
            const string alph = "0ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return word.ToCharArray().Select(a => alph.IndexOf(a)).Sum();
        }

        public static string[] readData(string path)
        {

            string fileContent;

            using (StreamReader reader = File.OpenText(path))
            {
                fileContent = reader.ReadToEnd();
            }

            var words = fileContent.Replace("\"", "").Split(',');
            return words;
        }
    }
}