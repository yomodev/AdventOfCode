using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020CS
{
    public class Day15
    {

        public static int Part1_old(string input, int steps = 2020)
        {
            var dict = input.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select((x, i) => new { index = i, n = int.Parse(x) })
                .ToDictionary(k => k.n, v => v.index + 1);

            dict.EnsureCapacity(steps);
            var last = 0;
            for (int step = dict.Count + 1; step < steps; step++)
            {
                if (dict.TryGetValue(last, out int value))
                {
                    //Console.WriteLine($"step: {step} value: {value} size: {dict.Count}");
                    var n = step - value;
                    dict[last] = step;
                    last = n;
                    continue;
                }

                dict[last] = step;
                last = 0;
            }

            return last;
        }

        public static int Part1(string input, int steps = 2020)
        {
            var array = new int[steps];
            var parsed = input.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select((x, i) => new { index = i, n = int.Parse(x) }).ToArray();
            parsed.ForEach(x => array[x.n] = x.index + 1);

            var last = 0;
            for (int step = parsed.Length + 1; step < steps; step++)
            {
                var value = array[last];
                if (value != 0)
                {
                    var n = step - value;
                    array[last] = step;
                    last = n;
                    continue;
                }

                array[last] = step;
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
