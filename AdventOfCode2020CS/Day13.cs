using System;
using System.Collections.Generic;
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

        public static long Part2(string input)
        {
            var stack = new Stack<(long id, int offset)>(input.Split(',')
                .Select((x, i) => new { id = x, offset = i })
                .Where(x => x.id != "x")
                .Select(x => (id: long.Parse(x.id), x.offset))
                .OrderByDescending(x => x.id)
                );

            var (increment, delta) = stack.Pop();
            long result = 0;

            while (stack.Any())
            {
                result += increment;

                var (id, offset) = stack.Peek();
                if ((result - delta + offset) % id != 0)
                {
                    continue;
                }
                else
                {
                    increment *= id;
                    stack.Pop();
                }
            }

            result -= delta;
            return result;
        }

    }

}
