using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021Lib
{
    public class Day09
    {
        record Point(int x, int y);

        public int Part1(IEnumerable<string> data)
        {
            var dict = data
                .SelectMany((line, y) => line.Select((c, x) => new { x, y, n = c - '0' }))
                .ToDictionary(k => new Point(k.x, k.y), v => v.n);

            var result = dict
                .Sum(pair => IsMin(pair.Key, pair.Value, dict) ? 1 + pair.Value : 0);
            return result;
        }

        private bool IsMin(Point p, int v, Dictionary<Point, int> dict)
        {
            var pn = dict.TryGetValue(new Point(p.x, p.y - 1), out int vn);
            var ps = dict.TryGetValue(new Point(p.x, p.y + 1), out int vs);
            var pw = dict.TryGetValue(new Point(p.x - 1, p.y), out int vw);
            var pe = dict.TryGetValue(new Point(p.x + 1, p.y), out int ve);
            return (!pn || vn > v) && (!ps || vs > v) && (!pw || vw > v) && (!pe || ve > v);
        }

        public int Part2(IEnumerable<string> data)
        {
            var dict = data
                .SelectMany((line, y) => line.Select((c, x) => new { x, y, n = c - '0' }))
                .ToDictionary(k => new Point(k.x, k.y), v => v.n);
            var groups = new List<int>();

            while (dict.Count > 0)
            {
                var p = dict.Keys.First();
                var v = dict[p];
                dict.Remove(p);
                if (v == 9)
                {
                    continue;
                }

                var size = FindNear(p, dict);
                groups.Add(1 + size);
            }

            var result = groups
                .OrderByDescending(x => x)
                .Take(3)
                .Aggregate(1, (acc, x) => x * acc);
            return result;
        }

        private int FindNear(Point point, Dictionary<Point, int> dict)
        {
            var result = Find(dict, new Point(point.x, point.y - 1));
            result += Find(dict, new Point(point.x, point.y + 1));
            result += Find(dict, new Point(point.x - 1, point.y));
            result += Find(dict, new Point(point.x + 1, point.y));
            return result;
        }

        private int Find(Dictionary<Point, int> dict, Point point)
        {
            if (dict.TryGetValue(point, out int value) && value < 9)
            {
                dict.Remove(point);
                return 1 + FindNear(point, dict);
            }
            return 0;
        }

        public int Part1_old(IEnumerable<string> data)
        {
            var list = data.Select(l => l.Select(c => c - '0').ToList()).ToList();
            var width = list.First().Count;
            var height = list.Count;
            var sum = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var cur = list[y][x];
                    if ((x - 1 >= 0 ? list[y][x - 1] > cur : true)
                        && (x + 1 < width ? list[y][x + 1] > cur : true)
                        && (y - 1 >= 0 ? list[y - 1][x] > cur : true)
                        && (y + 1 < height ? list[y + 1][x] > cur : true)
                        )
                    {
                        sum += 1 + cur;
                    }
                }
            }

            return sum;
        }
    }
}
