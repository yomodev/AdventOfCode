using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020CS
{
    public class Day19
    {

        public static long Part1(string input)
        {
            var parts = input.Split(Environment.NewLine + Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var tree = Parse(
                parts.First()
                .Split(Environment.NewLine)
                .Select(s => s.Split(new char[] { ' ', ':', '"' }, StringSplitOptions.RemoveEmptyEntries))
                .Select(x => new { key = int.Parse(x.First()), items = x.Skip(1).ToArray() })
                .ToDictionary(k => k.key, v => v.items)
            );
            var result = parts.Last().Split(Environment.NewLine).Count(x => tree.Match(x) == string.Empty);
            return result;
        }

        public static IRule Parse(Dictionary<int, string[]> input, int index = 0)
        {
            var items = input[index];
            if (char.IsLetter(items[0][0]))
            {
                return new Letter(items[0][0]);
            }
            else if (items.Contains("|"))
            {
                var orList = new List<IRule>();
                var andList = new List<IRule>();
                for (int i = 0; i < items.Length; i++)
                {
                    var item = items[i];
                    if (andList.Any() && item == "|")
                    {
                        orList.Add(new And(andList));
                        andList.Clear();
                        continue;
                    }

                    andList.Add(Parse(input, int.Parse(item)));
                }

                if (andList.Any())
                {
                    orList.Add(new And(andList));
                }

                return new Or(orList);
            }

            return new And(items.Select(x => Parse(input, int.Parse(x))));
        }
    }

    public interface IRule
    {
        string Match(string test);
    }

    class Letter : IRule
    {
        public char Char { get; set; }

        public Letter(char c)
        {
            Char = c;
        }

        public override string ToString()
        {
            return Char.ToString();
        }

        public string Match(string test)
        {
            return test?.First() == Char ? test[1..] : null;
        }
    }

    abstract class Sub
    {
        protected char separator = '?';

        public List<IRule> Rules { get; set; }

        public Sub(IEnumerable<IRule> rules, char separator)
        {
            Rules = rules.ToList();
            this.separator = separator;
        }

        public override string ToString()
        {
            return $"({string.Join(separator, Rules)})";
        }
    }

    class And : Sub, IRule
    {
        public And(IEnumerable<IRule> rules) : base(rules, '+') { }

        public string Match(string test)
        {
            foreach (var rule in Rules)
            {
                if (test == null)
                {
                    break;
                }
                test = rule.Match(test);
            }

            return test;
        }

    }

    class Or : Sub, IRule
    {
        public Or(IEnumerable<IRule> rules) : base(rules, '*') { }

        public string Match(string test)
        {
            var results = new List<string>();
            foreach (var rule in Rules)
            {
                results.Add(rule.Match(test));
            }

            return results.FirstOrDefault(x => x != null);
        }

    }

}
