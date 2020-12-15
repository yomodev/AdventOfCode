using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020CS
{
    public class Day07
    {
        static readonly string SEED = "shiny gold";

        public static int Part1(string input)
        {
            Dictionary<string, Dictionary<string, int>> dict = BuildDict(input);

            var result = new HashSet<string>();
            
            var stack = new Stack<string>(
                dict.Where(x => x.Value.ContainsKey(SEED)).Select(x => x.Key));

            while (stack.Any())
            {
                var current = stack.Pop();
                if (!result.Contains(current))
                {
                    result.Add(current);
                    dict.Where(x => x.Value.ContainsKey(current))
                        .Select(x => x.Key)
                        .ToList()
                        .ForEach(stack.Push);
                }
            }

            return result.Count;
        }

        public static long Part2(string input)
        {
            Dictionary<string, Dictionary<string, int>> dict = BuildDict(input);

            long Count(string current) => 1 + dict[current].Sum(x => x.Value * Count(x.Key));
            
            var result = -1 + Count(SEED);
            return result;
        }

        public static Dictionary<string, Dictionary<string, int>> BuildDict(string input)
        {
            var dict = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Split(" ,.".ToArray(), StringSplitOptions.RemoveEmptyEntries))
                .ToDictionary(word => $"{word[0]} {word[1]}", word =>
                {
                    var content = new Dictionary<string, int>();
                    if (!word.Contains("other"))
                    {
                        for (int i = 4; i < word.Length; i += 4)
                        {
                            content.Add($"{word[i + 1]} {word[i + 2]}", int.Parse(word[i]));
                        }
                    }
                    return content;
                });

            return dict;
        }
    }

}
