using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021Lib
{
    public class Day15
    {
        public int Part1(string data)
        {
            var board = ReadFile(data);
            var cur = new Point(0, 0);
            var prev = new List<Point> { cur };
            var end = board.Keys.MaxBy(p => p.X * 1000 + p.Y);
            var sum = 0;
            while (cur != end)
            {
                // seguire piu path, minby no ok
                var next = Cross(cur, board).Except(prev).MinBy(p => board[p]);
                sum += board[next];
                prev.Add(cur);
                cur = next;
            }
            return sum;
        }

        private IEnumerable<Point> Cross(Point cur, Dictionary<Point, int> board)
        {
            var points = new[]
            {
                new Point(cur.X -1, cur.Y),
                new Point(cur.X, cur.Y +1),
                new Point(cur.X +1, cur.Y),
                new Point(cur.X, cur.Y -1),
            }.Where(p => board.ContainsKey(p));
            return points;
        }

        private Dictionary<Point, int> ReadFile(string data)
        {
            var dict = data.Split(Environment.NewLine)
                .Select((line, y) =>
                    line.Select((c, x) =>
                        new { point = new Point(x, y), value = c - '0' }))
                .SelectMany(x => x)
                .ToDictionary(k => k.point, v => v.value);
            return dict;
        }

        public int Part2(string data)
        {
            return 0;
        }
    }
}
