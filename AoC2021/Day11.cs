using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021Lib
{
    public class Day11
    {
        record Point(int x, int y);

        public int Part1(IEnumerable<string> data)
        {
            var dict = data
                .SelectMany((line, y) => line.Select((c, x) => new { x, y, n = c - '0' }))
                .ToDictionary(k => new Point(k.x, k.y), v => v.n);

            int flashes = 0;
            for (int step = 1; step <= 100; step++)
            {
                var cur = new Dictionary<Point, int>();
                dict.Keys.ToList().ForEach(x => Increase(cur, dict, x));
                flashes += cur.Values.Where(x => x == 0).Count();
                dict = cur;
                //Print(step, cur);
            }

            return flashes;
        }

        private void Print(int step, Dictionary<Point, int> dict)
        {
            Console.WriteLine($"step {step}");
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    Console.Write($"{dict[new Point(x, y)]}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private void Increase(Dictionary<Point, int> cur, Dictionary<Point, int> dict, Point point)
        {
            if (!dict.ContainsKey(point) || cur.ContainsKey(point) && cur[point] == 0)
            {
                return;
            }

            cur[point] = 1 + (cur.ContainsKey(point) ? cur[point] : dict[point]);

            if (cur[point] > 9)
            {
                cur[point] = 0;
                Increase(cur, dict, new Point(point.x - 1, point.y - 1));//nw
                Increase(cur, dict, new Point(point.x, point.y - 1));//n
                Increase(cur, dict, new Point(point.x - 1, point.y));//w
                Increase(cur, dict, new Point(point.x - 1, point.y + 1));//sw
                Increase(cur, dict, new Point(point.x, point.y + 1));//s
                Increase(cur, dict, new Point(point.x + 1, point.y + 1));//se
                Increase(cur, dict, new Point(point.x + 1, point.y));//e
                Increase(cur, dict, new Point(point.x + 1, point.y - 1));//ne
            }
        }

        public long Part2(IEnumerable<string> data)
        {
            var dict = data
                .SelectMany((line, y) => line.Select((c, x) => new { x, y, n = c - '0' }))
                .ToDictionary(k => new Point(k.x, k.y), v => v.n);

            int step = 0;
            do
            {
                var cur = new Dictionary<Point, int>();
                dict.Keys.ToList().ForEach(x => Increase(cur, dict, x));
                dict = cur;
                step++;
            }
            while (!dict.Values.All(v => v == 0));

            return step;
        }

    }
}
