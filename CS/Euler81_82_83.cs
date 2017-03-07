using System;
using System.IO;

namespace ConsoleApplication
{
    public class Program81_82_83
    {
        private static int[,] data;
        private static int N;

        static bool test = false;
        static bool three = true;
        static bool two = false;
        public static void Main2(string[] args)
        {
            // test instance
            var path = @"Y:\OneDrive\Projects\ProjectEuler\data\p083_matrix-small.txt";
            path = @"Y:\OneDrive\Projects\ProjectEuler\data\test.txt";
            // real instance
            var path2 = @"Y:\OneDrive\Projects\ProjectEuler\data\p083_matrix.txt";

            data = readData(test ? path : path2);
            Solve();
        }


        public static void Solve()
        {


            for (int a = 0; a < N; a++)
            {
                for (int b = 0; b < N; b++)
                {

                    Console.Write("\t" + data[a, b]);

                }
                Console.WriteLine();
            }

            var X = 0;
            var Y = 0;
            var visited = new bool[N, N];
            var path = new int[N, N];

            path[0, 0] = data[0, 0];
            var min = int.MaxValue;
            for (int i = 0; three && i < N; i++)
            {
                path[i, 0] = data[i, 0];
                if (data[i, 0] < min)
                {
                    min = data[i, 0];
                    X = i;
                }
            }

            int curr = path[X, Y];

            while ((three && Y != N - 1) || !three && (X != N - 1 || Y != N - 1))
            {

                if (test) Console.WriteLine();
                for (int a = 0; test && a < N; a++)
                {
                    for (int b = 0; b < N; b++)
                    {
                        if (a == X && b == Y || (a == X && (b - Y) == 1) || (b == Y && Math.Abs(a - X) == 1))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\t" + path[a, b] + "+");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else Console.Write("\t" + path[a, b]);

                    }
                    Console.WriteLine();
                }

                if (test)
                    Console.WriteLine();
                curr = path[X, Y];
                if (Y == N - 1)
                {
                    Console.WriteLine(curr);
                }
                var max = three || two ? 3 : 4;
                var mmin = two ? 1 : 0;
                for (int i = mmin; i < max; i++)
                {
                    var x = X;
                    var y = Y;
                    if (i < 2) { x += i == 0 ? -1 : 1; }
                    if (i >= 2) { y += i == 2 ? 1 : -1; }

                    if (0 <= x && x < N && 0 <= y && y < N)
                    {
                        // Console.WriteLine($"{X } { Y} {x } {y } ");
                        if (!visited[x, y])
                        {
                            var dest = data[x, y] + curr;
                            if (path[x, y] == 0 || dest < path[x, y])
                            {
                                path[x, y] = dest;
                            }
                        }
                    }
                }
                min = int.MaxValue;
                visited[X, Y] = true;
                for (int a = 0; a < N; a++)
                {
                    for (int b = 0; b < N; b++)
                    {
                        if (!visited[a, b] && path[a, b] > 0 && path[a, b] < min)
                        {
                            min = path[a, b];
                            X = a;
                            Y = b;
                        }
                    }
                }
            }
            Console.WriteLine(X + " " + Y + " " + path[X, Y]);
        }


        public static int[,] readData(string path)
        {

            string fileContent;

            using (StreamReader reader = File.OpenText(path))
            {
                fileContent = reader.ReadToEnd();
            }

            var lines = fileContent.Split('\n');
            Console.WriteLine($"{lines.Length} lines");
            N = lines.Length - 1;
            var x = new int[lines.Length, lines.Length];

            for (int i = 0; i < N; i++)
            {
                var line = lines[i].Split(',');
                for (int j = 0; j < N; j++)
                    x[i, j] = int.Parse(line[j]);
            }

            return x;
        }
    }
}