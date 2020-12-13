using System;
using System.Linq;

namespace AdventOfCode2020CS
{
    public class Day09
    {

        public static long Part1(string input, int preamble)
        {
            var code = input.Split(Environment.NewLine)
                .Select((x, i) => new { i, value = long.Parse(x) });

            var result = code.Skip(preamble)
                .Where(x => code
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
            var code = input.Split(Environment.NewLine)
                .Select((x, i) => new { i, value = long.Parse(x) });

            var result = code.Skip(preamble)
                .Where(x => code
                    .Skip(x.i - preamble)
                    .Take(preamble)
                    .DifferentCombinations(2)
                    .Select(x => x.Sum(y => y.value))
                    .Contains(x.value) == false)
                .Select(x => x.value)
                .First();

            return result;
        }


    }

}
