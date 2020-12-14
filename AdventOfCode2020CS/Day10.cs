using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020CS
{
    public class Day10
    {

        public static int Part1(string input)
        {
            var dict = new Dictionary<int, int>
            {
                { 1, 1 },
                { 3, 1 }
            };

            var numbers = input.Split(Environment.NewLine)
                .Select(x => int.Parse(x)).OrderBy(x => x)
                .ToArray();

            for (int i = 1; i < numbers.Length; i++)
            {
                var diff = numbers[i] - numbers[i - 1];
                ++dict[diff];
            }

            var result = dict[1] * dict[3];
            return result;
        }

        public static int Part2(string input)
        {
            return 0;
        }

    }

}
