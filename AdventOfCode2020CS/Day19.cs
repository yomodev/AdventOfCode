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
            var tree = Parse(RulesDict(parts.First()));
            var result = parts.Last().Split(Environment.NewLine).Count(x => tree.Match(x));
            return result;
        }

        public static long Part2(string input)
        {
            var parts = input.Split(Environment.NewLine + Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<int, string[]> dict = RulesDict(parts.First());

            dict[8] = "42 | 42 8".Split(' ');
            dict[11] = "42 31 | 42 11 31".Split(' ');
            var tree = Parse(dict);
            var result = parts.Last().Split(Environment.NewLine).Count(x => tree.Match(x));
            return result;
        }

        private static Dictionary<int, string[]> RulesDict(string rulesSection)
        {
            return rulesSection.Split(Environment.NewLine)
                .Select(s => s.Split(new char[] { ' ', ':', '"' }, StringSplitOptions.RemoveEmptyEntries))
                .Select(x => new { key = int.Parse(x.First()), items = x.Skip(1).ToArray() })
                .ToDictionary(k => k.key, v => v.items);
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
                var andList = new List<IRule>();
                var or = new Or(new List<IRule>());

                for (int i = 0; i < items.Length; i++)
                {
                    var item = items[i];
                    if (andList.Any() && item == "|")
                    {
                        or.Rules.Add(new And(andList));
                        andList.Clear();
                        continue;
                    }

                    var subIndex = int.Parse(item);
                    var subRule = subIndex == index ? or : Parse(input, subIndex);
                    andList.Add(subRule);
                }

                if (andList.Any())
                {
                    or.Rules.Add(new And(andList));
                }

                return or;
            }

            var and = new And(new List<IRule>());
            and.Rules.AddRange(items.Select(x => int.Parse(x)).Select(x => x == index ? and : Parse(input, x)));
            return and;
        }
    }

    public interface IRule
    {
        IEnumerable<string> Matches(string test);

        bool Match(string test)
        {
            return Matches(test).Any(x => x == string.Empty);
        }
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

        public IEnumerable<string> Matches(string test)
        {
            if (test.Any() && test.First() == Char)
            {
                return new List<string> { test[1..] };
            }
            return Enumerable.Empty<string>();
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
    }

    class And : Sub, IRule
    {
        public And(IEnumerable<IRule> rules) : base(rules, '+') { }

        public IEnumerable<string> Matches(string test)
        {
            var tests = new List<string> { test };
            List<string> results = new List<string>();
            foreach (var rule in Rules)
            {
                results.Clear();
                foreach (var subTest in tests)
                {
                    results.AddRange(rule.Matches(subTest));
                }

                if (!results.Any())
                {
                    return Enumerable.Empty<string>();
                }

                tests = results.ToList();
            }

            return results;
        }

    }

    class Or : Sub, IRule
    {
        public Or(IEnumerable<IRule> rules) : base(rules, '*') { }

        public IEnumerable<string> Matches(string test)
        {
            var results = new List<string>();
            Rules.ForEach(rule => results.AddRange(rule.Matches(test)));
            return results.Where(x => x != null);
        }

    }

}
