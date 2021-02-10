using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AdventOfCode2020CS
{
    public class Day19
    {

        public static long Part1(string input)
        {
            var parts = input.Split(Environment.NewLine + Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var tree = BuildRules(parts.First().Split(Environment.NewLine));
            var result = parts.Last().Split(Environment.NewLine).Count(x => Match(tree, x));
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
                    if (andList.Any() && (item == "|" || i == items.Length - 1))
                    {
                        orList.Add(new And(andList));
                        andList.Clear();
                        continue;
                    }

                    andList.Add(Parse(input, int.Parse(item)));
                }

                return new Or(orList);
            }

            return new And(items.Select(x => Parse(input, int.Parse(x))));
        }

        public static IRule BuildRules(string[] strArray)
        {
            return Parse(
                strArray.Select(s => s.Split(new char[] { ' ', ':', '"' }, StringSplitOptions.RemoveEmptyEntries))
                .Select(x => new { key = int.Parse(x.First()), items = x.Skip(1).ToArray() })
                .ToDictionary(k => k.key, v => v.items)
                );
        }

        public static bool Match(IRule rule, string str)
        {
            if (str.Length == 0 && (rule as Sub)?.Rules.Count == 0)
            {
                return true;
            }
            
            var cur = str[0];
            if(str.Length == 1)
            {
                return (rule as Letter)?.Contains(cur) ?? false;
            }

            if (rule.Contains(cur))
            {
                bool any = false;
                var rules = rule.StartsWith(cur);
                foreach (var sub in rule.StartsWith(cur))
                {
                    if (sub is Or || sub is Letter)
                    {

                    }

                    var andList = (sub as And).Rules.Skip(1);
                    any |= Match(new And(andList), str[1..]);
                }

                return any;
                /* if (str.Length > 1)
                {

                    return rules.Any(rul => Match(rul, str[1..]));
                }*/
            }

            return false;
        }
    }

    public interface IRule
    {
        bool Contains(char c);
        IEnumerable<IRule> StartsWith(char c);
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

        public bool Contains(char c)
        {
            return Char == c;
        }

        public IEnumerable<IRule> StartsWith(char c)
        {
            return Enumerable.Empty<IRule>();
        }
    }

    abstract class Sub
    {
        bool? containsA;
        bool? containsB;
        public List<IRule> Rules { get; set; }

        public Sub(IEnumerable<IRule> rules)
        {
            Rules = rules.ToList();
        }

        public bool Contains(char c)
        {
            if (c == 'a')
            {
                if (!containsA.HasValue)
                {
                    containsA = Rules.Any(x => x.Contains(c));
                }
                return containsA.Value;
            }

            if (!containsB.HasValue)
            {
                containsB = Rules.Any(x => x.Contains(c));
            }
            return containsB.Value;
        }

    }

    class And : Sub, IRule
    {
        public And(IEnumerable<IRule> rules) : base(rules) { }

        public override string ToString()
        {
            return $"({string.Join(" & ", Rules)})";
        }

        public IEnumerable<IRule> StartsWith(char c)
        {
            if (Rules.Count > 0 && Rules.First().Contains(c))
            {
                return new List<IRule> { new And(Rules) };
            }
            return Enumerable.Empty<IRule>();
        }
    }

    class Or : Sub, IRule
    {
        public Or(IEnumerable<IRule> rules) : base(rules) { }

        public override string ToString()
        {
            return $"({string.Join(" | ", Rules)})";
        }

        public IEnumerable<IRule> StartsWith(char c)
        {
            return Rules.Where(x => x.Contains(c) && x.StartsWith(c).Any());
        }
    }

}
