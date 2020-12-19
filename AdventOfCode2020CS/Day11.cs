using System;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2020CS
{
    public class Day11
    {

        public static int Part1(string input)
        {
            var seats = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] prev;
            int step = 0;
            do
            {
                prev = (string[])seats.Clone();
                seats = Step(seats, step, AlgorithmPart1);
            }
            while (Different(seats, prev, step++));

            var result = seats.Aggregate((a, b) => a + b).Count(c => c == '#');
            return result;
        }

        private static bool Different(string[] s1, string[] s2, int step)
        {
            var str1 = s1.Aggregate((a, b) => a + b);
            var str2 = s2.Aggregate((a, b) => a + b);
            var res = str1 == str2;
            if (!res)
            {
                Debug.WriteLine(step);
                Debug.WriteLine(string.Join(Environment.NewLine, s1));
            }
            return !res;
        }

        private static string[] Step(string[] seats, int step, Func<int, int, int, string[], char> calc)
        {
            var target = (string[])seats.Clone();
            for (int y = 0; y < seats.Length; y++)
            {
                char[] line = target[y].ToArray();
                for (int x = 0; x < seats[y].Length; x++)
                {
                    line[x] = calc(x, y, step, seats);
                }
                target[y] = string.Join(null, line);
            }
            return target;
        }

        private static char AlgorithmPart1(int x, int y, int step, string[] s)
        {
            var c = s[y][x];
            var p = new string(' ', 8).ToArray();
            p[0] = y > 0 ? (x > 0 ? s[y - 1][x - 1] : '.') : '.';
            p[1] = y > 0 ? s[y - 1][x] : '.';
            p[2] = y > 0 ? (x < s[y - 1].Length - 1 ? s[y - 1][x + 1] : '.') : '.';
            p[3] = x > 0 ? s[y][x - 1] : '.';
            p[4] = x < s[y].Length - 1 ? s[y][x + 1] : '.';
            p[5] = y < s.Length - 1 ? (x > 0 ? s[y + 1][x - 1] : '.') : '.';
            p[6] = y < s.Length - 1 ? s[y + 1][x] : '.';
            p[7] = y < s.Length - 1 ? (x < s[y + 1].Length - 1 ? s[y + 1][x + 1] : '.') : '.';

            if (c == 'L' && !p.Contains('#'))
            {
                return '#';
            }
            else if (c == '#' && p.Count(x => x == '#') >= 4)
            {
                return 'L';
            }

            return c;
        }

        public static int Part2(string input)
        {
            var seats = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] prev;
            int step = 0;
            do
            {
                prev = (string[])seats.Clone();
                seats = Step(seats, step, AlgorithmPart2);
            }
            while (Different(seats, prev, step++));

            var result = seats.Aggregate((a, b) => a + b).Count(c => c == '#');
            return result;
        }

        private static char AlgorithmPart2(int x, int y, int step, string[] s)
        {
            var c = s[y][x];
            var p = new string(' ', 8).ToArray();
            p[0] = Find(x, y, s, -1, -1);
            p[1] = Find(x, y, s, 0, -1);
            p[2] = Find(x, y, s, 1, -1);
            p[3] = Find(x, y, s, -1, 0);
            p[4] = Find(x, y, s, 1, 0);
            p[5] = Find(x, y, s, -1, 1);
            p[6] = Find(x, y, s, 0, 1);
            p[7] = Find(x, y, s, 1, 1);

            if (c == 'L' && !p.Contains('#'))
            {
                return '#';
            }
            else if (c == '#' && p.Count(x => x == '#') >= 5)
            {
                return 'L';
            }

            return c;
        }

        private static char Find(int x, int y, string[] s, int dx, int dy)
        {
            var w = s[0].Length - 1;
            var h = s.Length - 1;

            if ((y == 0 && dy == -1)
                || (y == h && dy == 1)
                || (x == w && dx == 1)
                || (x == 0 && dx == -1))
            {
                return '.';
            }

            int cx = x + dx;
            int cy = y + dy;

            while (cx <= w && cx >= 0 && cy <= h && cy >= 0)
            {
                var c = s[cy][cx];
                if (c != '.')
                {
                    return c;
                }
                cx += dx;
                cy += dy;
            }

            return '.';
        }
    }

}
