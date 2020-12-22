using System;
using System.Diagnostics;
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
            var buses = input.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select((x, i) => new { id = x, offset = i })
                .Where(x => x.id != "x")
                .Select(x => new { id = int.Parse(x.id), x.offset })
                .OrderByDescending(x => x.id)
                .ToArray();

            long increment = buses[0].id;
            long delta = buses[0].offset;
            int skip = 1;
            long result = 0;

            while (true)
            {
                result += increment;

                for (int i = skip; i < buses.Length; i++)
                {
                    if ((result - delta + buses[i].offset) % buses[i].id != 0)
                    {
                        goto skipLabel;
                    }
                    else if (i != buses.Length - 1)
                    {
                        //Debug.WriteLine($"{i} {cur} {buses[x].id}");
                        increment *= buses[i].id;
                        skip++;
                        goto skipLabel;
                    }
                }
                break;

            skipLabel:
                continue;
            }

            result -= delta;
            return result;
        }

    }

}
