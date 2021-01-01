using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020CS
{
    public class Day16
    {
        struct Rule
        {
            public string Name { get; set; }
            public int Start1 { get; set; }
            public int End1 { get; set; }
            public int Start2 { get; set; }
            public int End2 { get; set; }
        }

        class Partition
        {
            public int[] Values { get; set; }
            public int Min { get; set; }
            public int Max { get; set; }
            public int Index { get; set; }
        }

        public static int Part1(string input)
        {
            var data = input.Split(Environment.NewLine + Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            IEnumerable<Rule> fields = ParseFields(data[0]);
            IEnumerable<int[]> tickets = ParseTickets(data[2]);
            var range = BuildValidFieldsRange(fields);
            var result = tickets.SelectMany(x => x)
                .Where(x => x >= range.Length || !range[x]);

            return result.Sum();
        }

        private static bool[] BuildValidFieldsRange(IEnumerable<Rule> fields)
        {
            var max = fields.Max(x => Math.Max(x.End1, x.End2));
            var range = new bool[max + 1];

            fields.Select(x => Enumerable.Range(x.Start1, x.End1 - x.Start1 + 1))
                .SelectMany(x => x)
                .Concat(fields.Select(x => Enumerable.Range(x.Start2, x.End2 - x.Start2 + 1))
                .SelectMany(x => x))
                .ForEach(x => range[x] = true);

            return range;
        }

        private static IEnumerable<int[]> ParseTickets(string data)
        {
            var result = data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Select(x => x.Split(',').Select(n => int.Parse(n)).ToArray());

            return result;
        }

        private static IEnumerable<Rule> ParseFields(string data)
        {
            var result = data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Split(new string[] { ": ", "-", " or " }, StringSplitOptions.RemoveEmptyEntries))
                .Select(x => new Rule
                {
                    Name = x[0],
                    Start1 = int.Parse(x[1]),
                    End1 = int.Parse(x[2]),
                    Start2 = int.Parse(x[3]),
                    End2 = int.Parse(x[4])
                });
            return result;
        }

        public static Dictionary<string, int> DecodeTicket(string input)
        {
            var data = input.Split(Environment.NewLine + Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var fields = ParseFields(data[0]).ToList();
            List<int[]> valids = ValidTickets(data[2], fields);

            var partitions = Enumerable.Range(0, fields.Count)
                .Select(i => valids.Select(x => x[i]).ToArray())
                .Select((x, i) => new Partition { Values = x, Min = x.Min(), Max = x.Max(), Index = i })
                .ToArray();

            var indexes = fields.ToDictionary(k => k.Name, v => GetMatchingIndexes(v, partitions));

            var mapping = new Dictionary<string, int>();
            while (mapping.Count < fields.Count)
            {
                var single = indexes.Single(x => x.Value.Count == 1 && !mapping.ContainsKey(x.Key));
                var index = single.Value.Single();
                mapping.Add(single.Key, index);
                indexes.Remove(single.Key);
                foreach (var item in indexes.Where(x => x.Value.Contains(index)))
                {
                    item.Value.Remove(index);
                }
            }

            var result = data[1].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Skip(1)
                .Select(x => x.Split(',').Select(y => int.Parse(y)))
                .SelectMany(x => x)
                .Select((x, i) => (i,x))
                .ToDictionary(k => mapping.Where(x => x.Value == k.i).Select(k => k.Key).Single(), v => v.x);

            return result;
        }

        private static List<int[]> ValidTickets(string data, List<Rule> fields)
        {
            var range = BuildValidFieldsRange(fields);
            var tickets = ParseTickets(data);
            var valids = tickets.Where(x => !x.Any(n => n >= range.Length || !range[n])).ToList();
            return valids;
        }

        private static List<int> GetMatchingIndexes(Rule rule, IEnumerable<Partition> partitions)
        {
            var range = Enumerable.Range(rule.End1 + 1, rule.Start2 - rule.End1 - 1);
            var result = partitions
                .Where(p => rule.Start1 <= p.Min && rule.End2 >= p.Max && range.Intersect(p.Values).IsEmpty())
                .Select(x => x.Index)
                .ToList();

            return result;
        }

        public static long Part2(string input)
        {
            var result = DecodeTicket(input)
                .Where(x => x.Key.StartsWith("departure"))
                .Select(x => x.Value)
                .Multiply(x => x);

            return result;
        }

    }

}
