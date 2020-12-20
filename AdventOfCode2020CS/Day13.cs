using System;
using System.Linq;

namespace AdventOfCode2020CS
{
    public class Day13
    {
        public static int Part1(string input)
        {
            var data = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var ts = int.Parse(data.First());

            var bus = data.Skip(1).First().Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x != "x")
                .Select(x => int.Parse(x))
                .Select(x => new { id = x, div = (int)((ts + x) / x) })
                .Select(x => new { x.id, x.div, rem = (x.id * x.div) - ts })
                .OrderBy(x => x.rem)
                .First();

            var result = bus.id * bus.rem;
            return result;
        }

        public static int Part2(string input)
        {
            var data = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var bus = data.Skip(1).First().Split(',', StringSplitOptions.RemoveEmptyEntries);
            var result = 0;
            return result;
        }

    }

}
