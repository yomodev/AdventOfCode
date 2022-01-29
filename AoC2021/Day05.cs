using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021Lib
{
    public class Day05
    {
        public record Point
        {
            public int X { get; private set; }
            public int Y { get; private set; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public Point(Point other)
            {
                X = other.X;
                Y = other.Y;
            }

            public override string ToString()
            {
                return $"{X},{Y}";
            }
        }

        public int Part1(IEnumerable<string> data, bool processDiagonalLines = false)
        {
            Dictionary<Point, int> board = new();
            data.Select(s => s
                    .Replace(" -> ", ",")
                    .Split(",")
                    .Select(Int32.Parse)
                    .ToList())
                .Select(n => new { a = new Point(n[0], n[1]), b = new Point(n[2], n[3]) })
                .ToList()
                .ForEach(point => AddLine(point.a, point.b, board, processDiagonalLines));

            var draw = Draw(board);

            var count = board.Values.Count(v => v > 1);
            return count;
        }

        private void AddLine(Point a, Point b, Dictionary<Point, int> board, bool processDiagonalsLines)
        {
            if (a.X != b.X && a.Y != b.Y)
            {
                if (!processDiagonalsLines)
                {
                    return;
                }
                else if (Math.Abs(b.X - a.X) != Math.Abs(b.Y - a.Y))
                {
                    return;
                }
            }

            var point = new Point(a);
            AddPoint(point, board);

            while (!point.Equals(b))
            {
                var x = point.X;
                var y = point.Y;

                var cx = b.X.CompareTo(a.X);
                var cy = b.Y.CompareTo(a.Y);

                x += cx != 0 && x != b.X ? cx : 0;
                y += cy != 0 && y != b.Y ? cy : 0;

                point = new Point(x, y);
                AddPoint(point, board);
            }
        }

        private static void AddPoint(Point point, Dictionary<Point, int> board)
        {
            var value = 0;
            if (board.ContainsKey(point))
            {
                value = board[point];
            }
            board[point] = ++value;
        }

        public int Part2(IEnumerable<string> data)
        {
            return Part1(data, processDiagonalLines: true);
        }

        private static string Draw(Dictionary<Point, int> board)
        {
            var lines = string.Empty;
            for (int y = 0; y < 10; y++)
            {
                var line = string.Empty;
                for (int x = 0; x < 10; x++)
                {
                    var value = 0;
                    var p = new Point(x, y);
                    if (board.ContainsKey(p))
                    {
                        value = board[p];
                    }

                    line += value > 0 ? value.ToString() : ".";
                }
                lines += line + Environment.NewLine;
            }

            return lines;
        }
    }
}
