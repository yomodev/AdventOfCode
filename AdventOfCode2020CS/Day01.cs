using System;
using System.Linq;

namespace AdventOfCode2020CS
{
    public class Day01
    {
        public static long Test1(string input)
        {
            var result = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => int.Parse(line)).ToArray()
                .DifferentCombinations(2)
                .Where(x => x.Sum() == 2020).FirstOrDefault()
                .Aggregate(1, (acc, val) => acc * val);

            return result;
        }

        public static long Test2(string input)
        {
            var result = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => int.Parse(line)).ToArray()
                .DifferentCombinations(3)
                .Where(x => x.Sum() == 2020).FirstOrDefault()
                .Aggregate(1, (acc, val) => acc * val);

            return result;
        }

    }

}
