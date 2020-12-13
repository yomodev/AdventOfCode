using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020CS
{
    public class Day09
    {

        public static long Part1(string input, int preamble)
        {
            var numbers = input.Split(Environment.NewLine)
                .Select((x, i) => new { i, value = long.Parse(x) });

            var result = numbers.Skip(preamble)
                .Where(x => numbers
                    .Skip(x.i - preamble)
                    .Take(preamble)
                    .DifferentCombinations(2)
                    .Select(x => x.Sum(y => y.value))
                    .Contains(x.value) == false)
                .Select(x => x.value)
                .First();

            return result;
        }

        public static long Part2(string input, int preamble)
        {
            var invalid = Part1(input, preamble);
            var numbers = input.Split(Environment.NewLine)
                .Select(x => long.Parse(x))
                .ToArray();

            IEnumerable<long> seq = Enumerable.Empty<long>();
            foreach (var i in Enumerable.Range(0, numbers.Length).Where(x => numbers[x] < invalid))
            {
                var j = 2;
                long sum;
                do
                {
                    seq = numbers.Skip(i).Take(j++);
                    sum = seq.Sum();
                }
                while (sum < invalid);

                if (sum == invalid)
                {
                    break;
                }
            }

            var result = seq.Min() + seq.Max();
            return result;
        }

    }

}
