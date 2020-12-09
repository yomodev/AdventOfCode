using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020CS
{
    public class Day07
    {
        public static int Test1(string input)
        {
            Dictionary<string, Dictionary<string, int>> bags = BuildBagDict(input);
            HashSet<string> result = ShinyGoldContainers(bags);

            return result.Count();
        }

        public static long Test2(string input)
        {
            Dictionary<string, Dictionary<string, int>> bags = BuildBagDict(input);
            //HashSet<string> result = ShinyGoldContainers(bags);

            var bag = new Bag("shiny gold");
            var count = bag.Content(bags);
            
            return count -1;
        }

        public static HashSet<string> ShinyGoldContainers(Dictionary<string, Dictionary<string, int>> bags)
        {
            var stack = new Stack<string>(
                            bags.Where(x => x.Value.ContainsKey("shiny gold"))
                            .Select(x => x.Key)
                            );

            var result = new HashSet<string>();
            while (stack.Any())
            {
                var check = stack.Pop();
                if (!result.Contains(check))
                {
                    result.Add(check);
                    bags.Where(x => x.Value.ContainsKey(check))
                        .Select(x => x.Key)
                        .ToList()
                        .ForEach(stack.Push);
                }
            }

            return result;
        }

        public static Dictionary<string, Dictionary<string, int>> BuildBagDict(string input)
        {
            var bags = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                            .Select(line => line.Split(" ,.".ToArray(), StringSplitOptions.RemoveEmptyEntries))
                            .ToDictionary(words => $"{words[0]} {words[1]}", words =>
                            {
                                var d = new Dictionary<string, int>();
                                if (!words.Contains("other"))
                                {
                                    for (int i = 4; i < words.Length; i += 4)
                                    {
                                        d.Add($"{words[i + 1]} {words[i + 2]}", int.Parse(words[i]));
                                    }
                                }
                                return d;
                            });

            return bags;
        }
    }

    internal class Bag
    {
        private string name;

        public Bag(string v)
        {
            this.name = v;
        }

        internal long Content(Dictionary<string, Dictionary<string, int>> bags)
        {
            var cur = bags[name];
            var n = cur.Sum(x => x.Value * new Bag(x.Key).Content(bags));
            return 1 + n;
        }
    }
}
