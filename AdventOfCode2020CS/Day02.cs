using System;
using System.Linq;

namespace AdventOfCode2020CS
{
    public class Day02
    {
        public static int Part1(string input)
        {
            var result = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Split(' ', '-', ':'))
                .Select(a => new { min = int.Parse(a[0]), max = int.Parse(a[1]), c = a[2][0], pass = a[4], count = a[4].Count(x => x == a[2][0]) })
                .Where(x => x.count >= x.min && x.count <= x.max)
                .Count();

            return result;
        }

        public static int Part2(string input)
        {
            var result = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Split(' ', '-', ':'))
                .Select(a => new { p1 = int.Parse(a[0]), p2 = int.Parse(a[1]), c = a[2][0], pass = a[4] })
                .Where(x => x.pass[x.p1 - 1] == x.c ^ x.pass[x.p2 - 1] == x.c)
                .Count();

            return result;
        }

    }

}
