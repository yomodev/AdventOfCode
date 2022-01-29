using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AoC2021Lib
{
    public class Day07
    {
        static readonly int MAX = 0;
        Dictionary<int, long> Cache = new() { { MAX, 1 }, { 1, 1 } };

        public int Part1(List<int> data)
        {
            var min = data.Min();
            var max = data.Max();
            var range = Enumerable.Range(min, max - min);
            var simulations = range.Select(i => data.Sum(x => Math.Abs(x - i)));
            var result = simulations.Min();
            return result;
        }

        public long Part2(List<int> data)
        {
            var min = data.Min();
            var max = data.Max();
            var result = Enumerable.Range(min, max - min)
                .Select(i => data.Sum(x => Steps(Math.Abs(x - i))))
                .Min();
            return result;
        }

        public long Steps(int value)
        {
            if (Cache.ContainsKey(value))
            {
                return Cache[value];
            }

            var result = Cache[(int)Cache[MAX]];
            for (int i = (int)Cache[MAX] +1; i <= value; i++)
            {
                result += i;
                Cache[i] = result;
            }

            Cache[MAX] = value;
            return result;
        }

        public int Steps_old(int value)
        {
            var result = value;
            for (int i = 1; i < value; i++)
            {
                result += i;
            }
            return result;
        }
    }
}
