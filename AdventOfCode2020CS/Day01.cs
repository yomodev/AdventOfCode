using System;
using System.Linq;

namespace AdventOfCode2020CS
{
    public class Day01
    {
        public static long Part1(string input)
        {
            var result = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray()
                .DifferentCombinations(2)
                .Where(x => x.Sum() == 2020).FirstOrDefault()
                .Multiply(x => x);

            return result;
        }

        public static long Part2(string input)
        {
            var result = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray()
                .DifferentCombinations(3)
                .Where(x => x.Sum() == 2020).FirstOrDefault()
                .Multiply(x => x);

            return result;
        }

    }

}
