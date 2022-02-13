using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021Lib
{
    public class Day14
    {
        public long Part1(string data, int steps)
        {
            var (list, dict) = ReadInput(data);
            Enumerable.Range(0, steps).ToList().ForEach(x => list = Apply(list, dict));
            var group = list.GroupBy(k => k, (k, v) => v.LongCount());
            var result = group.Max() - group.Min();
            return result;
        }

        private static List<char> Apply(List<char> list, Dictionary<string, char> dict)
        {
            //var len = Math.Min(list.Count, 20);// list.Count;
            var len = list.Count;
            var result = new List<char> { list.First() };
            for (int i = 1; i < len; i++)
            {
                var cur = list[i];
                result.Add(dict[new string(new char[] { list[i - 1], cur })]);
                result.Add(cur);
            }
            Console.WriteLine(string.Join(null, result));
            return result;
        }

        private static (List<char>, Dictionary<string, char>) ReadInput(string data)
        {
            var splitted = data.Split(Environment.NewLine + Environment.NewLine);
            var list = splitted.First().ToList();
            var dict = splitted.Last()
                .Split(Environment.NewLine)
                .Select(line => line.Split(" -> "))
                .ToDictionary(k => k.First(), v => v.Last().First());
            return (list, dict);
        }

        public long Part2(string data, int steps)
        {
            var result = Part1(data, steps);
            return result;
        }

    }
}
