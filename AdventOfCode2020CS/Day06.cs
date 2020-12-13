using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020CS
{
    public class Day06
    {
        public static int Part1(string input)
        {
            var result = input.Split(Environment.NewLine + Environment.NewLine)
                .Select(x => x.Replace(Environment.NewLine, string.Empty).Trim())
                .Sum(x => new HashSet<char>(x).Count());

            return result;
        }

        public static int Part2(string input)
        {
            var result = input.Split(Environment.NewLine + Environment.NewLine)
                .Select((s, i) => new { s, i })
                .GroupBy(k => k.i, v => v.s.Split(Environment.NewLine), (k, v) => v.First())
                .Sum(x => x.Concat()
                        .GroupBy(c => c)
                        .Where(c => c.Count() == x.Count())
                        .Count());
            
            return result;
        }

    }

}
