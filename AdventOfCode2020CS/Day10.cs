using System;
using System.Collections.Generic;
using System.Diagnostics;
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


        public static long Part2(string input)
        {
            var numbers = input.Split(Environment.NewLine)
                .Select(x => int.Parse(x))
                .OrderBy(x => x)
                .ToList();
            numbers.Insert(0, 0);
            numbers.Add(numbers.Last() + 3);

            var cache = new Dictionary<long, long>();

            long calc(int n = 0) 
            {
                if (n == numbers.Count - 1)
                {
                    return 1;
                }

                if (cache.ContainsKey(n)) 
                {
                    return cache[n];
                }

                long res = 0;
                for (int i = n + 1; i < numbers.Count; i++)
                {
                    //Debug.WriteLine(i);
                    if (numbers[i] - numbers[n] <= 3)
                    {
                        var c = calc(i);
                        Debug.WriteLine($"n = {n}, i = {i} - res {res +c} = {res} + {c}({i}) ");
                        res += c;
                    }
                }

                cache[n] = res;
                return res;
            };

            return calc();
        }

    }

}
