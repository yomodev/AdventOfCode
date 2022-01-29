using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2021Lib
{
    record Point(int X, int Y);

    public class Day13
    {
        public int Part1(string data)
        {
            var splitted = data.Split(Environment.NewLine + Environment.NewLine);
            var dict = CreateSet(splitted.First());
            var instr = ReadInstructions(splitted.Last());
            var result = Fold(dict, instr.First()).Count();
            return result;
        }

        public string Part2(string data)
        {
            var splitted = data.Split(Environment.NewLine + Environment.NewLine);
            var dict = CreateSet(splitted.First());
            var instr = ReadInstructions(splitted.Last());
            var folded = instr.Aggregate(dict, Fold);
            var result = Draw(folded);
            Console.WriteLine(result);
            return result;
        }

        private string Draw(HashSet<Point> points)
        {
            int mx = points.Max(p => p.X);
            int my = points.Max(p => p.Y);
            var sb = new StringBuilder();
            for (int y = 0; y <= my; y++)
            {
                for (int x = 0; x <= mx; x++)
                {
                    sb.Append(points.Contains(new Point(x, y)) ? '#' : '.');
                }
                sb.AppendLine();
            }
            sb.Length -= Environment.NewLine.Length;
            var result = sb.ToString();
            return result;
        }

        private static IEnumerable<Point> ReadInstructions(string str)
        {
            return str
                .Split(Environment.NewLine)
                .Select(line =>
                {
                    var split = line.Split('=');
                    var n = int.Parse(split.Last());
                    return split.First().Contains("x")
                        ? new Point(n, 0)
                        : new Point(0, n);
                });
        }

        private static HashSet<Point> CreateSet(string str)
        {
            return str
                .Split(Environment.NewLine)
                .Select(line => new Point(
                    int.Parse(line.Split(',').First()),
                    int.Parse(line.Split(',').Last())
                )).ToHashSet();
        }

        private HashSet<Point> Fold(HashSet<Point> set, Point fold)
        {
            var result = new HashSet<Point>();
            foreach (var p in set)
            {
                if (fold.X > 0 && p.X > fold.X)
                {
                    var x = 2 * fold.X - p.X;
                    result.Add(new Point(x, p.Y));
                }
                else if (fold.Y > 0 && p.Y > fold.Y)
                {
                    var y = 2 * fold.Y - p.Y;
                    result.Add(new Point(p.X, y));
                }
                else
                {
                    result.Add(p);
                }
            }
            return result;
        }
    }
}
