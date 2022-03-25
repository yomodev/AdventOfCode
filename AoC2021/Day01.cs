using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021Lib
{
    public class Day01
    {
        public int Part1(IEnumerable<int> list)
        {
            return list.Aggregate((inc: 0, prev: Int32.MaxValue),
                (acc, cur) => (inc: acc.inc + (cur > acc.prev ? 1 : 0), prev: cur)
            ).inc;
        }

        public int Part2(IEnumerable<int> enumerable)
        {
            return Part1(enumerable.Buffer(3, 2).Select(w => w.Sum()));
        }

        public int Part2v2(IEnumerable<int> enumerable)
        {
            return Part1(enumerable
                .Select((x, i) => new { x, i })
                .Skip(2)
                .GroupBy(k => k.i,
                (k, list) => enumerable.Skip(k - 2).Take(3).Sum()));
        }

        public int Part1v1(IEnumerable<int> enumerable)
        {
            var inc = 0;
            var prev = enumerable.First();
            foreach (var cur in enumerable.Skip(1))
            {
                if (cur > prev)
                {
                    inc++;
                }
                prev = cur;
            }
            return inc;
        }

        public int Part1v2(IEnumerable<int> list)
        {
            return list.Aggregate((increment: 0, previous: Int32.MaxValue), (accumulator, current) =>
            {
                var inc = accumulator.increment;
                if (current > accumulator.previous)
                {
                    inc++;
                }
                return (increment: inc, previous: current);
            }).increment;
        }

        public int Part2v1(IEnumerable<int> enumerable)
        {
            var list = enumerable.ToList();
            var inc = 0;
            var prev = list.Take(3).Sum();
            for (int i = 1; i < list.Count; i++)
            {
                if (i + 3 > list.Count)
                {
                    break;
                }

                var cur = list.Skip(i).Take(3).Sum();
                if (cur > prev)
                {
                    inc++;
                }
                prev = cur;
            }
            return inc;
        }
    }
}
