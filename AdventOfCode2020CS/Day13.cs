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
                .ToList();

            long i = 0;
            long inc = buses[0].id;
            long dif = buses[0].offset;
            buses.RemoveAt(0);
            var cur = i - inc;
            while (true)
            {
                i += inc;
                cur = i - dif;

                for (int x = 0; x < buses.Count; x++)
                {
                    if ((cur + buses[x].offset) % buses[x].id != 0)
                    {
                        goto skip;
                    }
                    else if (x != buses.Count -1)
                    {
                        //Debug.WriteLine($"{i} {cur} {buses[x].id}");
                        inc *= buses[x].id;
                        buses.RemoveAt(0);
                        goto skip;
                    }
                }
                break;

            skip:
                continue;
            }

            var result = cur;
            return result;
        }

    }

}
