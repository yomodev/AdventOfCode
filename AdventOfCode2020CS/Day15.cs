using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020CS
{
    public class Day15
    {

        public static int Part1(string input, int steps = 2020)
        {
            var dict = input.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select((x, i) => new { index = i, n = int.Parse(x) })
                .ToDictionary(k => k.n, v => v.index + 1);
            
            dict.EnsureCapacity(steps);
            var last = 0;
            for (int i = dict.Count + 1; i < steps; i++)
            {
                if (dict.TryGetValue(last, out int value))
                {
                    var n = i - value;
                    dict[last] = i;
                    last = n;
                    continue;
                }

                dict[last] = i;
                last = 0;
            }

            return last;
        }

        public static int Part2(string input)
        {
            var result = Part1(input, 30000000);
            return result;
        }

    }

}
