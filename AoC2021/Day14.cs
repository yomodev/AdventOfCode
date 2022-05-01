using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021Lib
{
    public class Day14
    {
        record struct Couple(char A, char B)
        {
            public override string ToString()
            {
                return $"{A}{B}";
            }
        }

        class CoupleDict : Dictionary<Couple, long>
        {
            public CoupleDict() : base()
            { }

            public CoupleDict(IEnumerable<Couple> enumerable)
            {
                enumerable.ToList().ForEach(x => Add(x));
            }

            public new void Add(Couple couple, long count = 1)
            {
                if (ContainsKey(couple))
                {
                    this[couple] += count;
                    return;
                }
                this[couple] = Math.Max(count, 1);
            }
        }

        public long Part1(string data, int steps)
        {
            var (input, setup) = ReadInput(data);
            var counters = Enumerable.Range(0, 26).ToDictionary(k => (char)('A' + k), v => 0L);
            counters[input.First().Key.A]++;

            foreach (var step in Enumerable.Range(0, steps))
            {
                var repetitions = new CoupleDict();
                foreach (var item in input)
                {
                    var k = item.Key;
                    repetitions.Add(new Couple(k.A, setup[k]), item.Value);
                    repetitions.Add(new Couple(setup[k], k.B), item.Value);
                }

                input = repetitions;
            }

            input.ToList().ForEach(x => counters[x.Key.B] += x.Value);
            var result = counters.Values.Max() - counters.Values.Where(x => x > 0).Min();
            return result;
        }

        private static (CoupleDict input, Dictionary<Couple, char> setup) ReadInput(string data)
        {
            var splitted = data.Split(Environment.NewLine + Environment.NewLine);

            var input = new CoupleDict(splitted.First().Buffer(2, 1).ToList()
                .Select(x => new Couple(A: x.First(), B: x.Last())));

            var setup = splitted.Last()
                .Split(Environment.NewLine)
                .Select(line => line.Split(" -> "))
                .ToDictionary(
                    k => new Couple(A: k.First().First(), B: k.First().Last()),
                    v => v.Last().First());

            return (input, setup);
        }

        public long Part2(string data, int steps)
        {
            var result = Part1(data, steps);
            return result;
        }

        public long Part1V1(string data, int steps)
        {
            var (list, dict) = ReadInputV1(data);
            Enumerable.Range(0, steps).ToList().ForEach(x => list = Apply(list, dict));
            var group = list.GroupBy(k => k, (k, v) => v.LongCount());
            var result = group.Max() - group.Min();
            return result;
        }

        private static (List<char>, Dictionary<string, char>) ReadInputV1(string data)
        {
            var splitted = data.Split(Environment.NewLine + Environment.NewLine);
            var list = splitted.First().ToList();
            var dict = splitted.Last()
                .Split(Environment.NewLine)
                .Select(line => line.Split(" -> "))
                .ToDictionary(k => k.First(), v => v.Last().First());
            return (list, dict);
        }

        private static List<char> Apply(List<char> list, Dictionary<string, char> dict)
        {
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
    }
}
