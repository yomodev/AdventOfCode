using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020CS
{
    public class Day16
    {

        public static int Part1(string input)
        {
            var data = input.Split(Environment.NewLine + Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            IEnumerable<(string name, int s1, int e1, int s2, int e2)> fields = ParseFields(data[0]);
            IEnumerable<int[]> nearby = ParseNearby(data[2]);
            var range = BuildRange(fields, nearby);
            var result = nearby.SelectMany(x => x)
                .Where(x => x >= range.Length || !range[x]);

            return result.Sum();
        }

        private static bool[] BuildRange(IEnumerable<(string name, int s1, int e1, int s2, int e2)> fields, IEnumerable<int[]> nearby)
        {
            var max = fields.Max(x => Math.Max(x.e1, x.e2));
            var range = new bool[max + 1];

            fields.Select(x => Enumerable.Range(x.s1, x.e1 - x.s1 + 1))
                .SelectMany(x => x)
                .Concat(fields.Select(x => Enumerable.Range(x.s2, x.e2 - x.s2 + 1))
                .SelectMany(x => x))
                .ForEach(x => range[x] = true);

            return range;
        }

        private static IEnumerable<int[]> ParseNearby(string data)
        {
            var result = data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Select(x => x.Split(',').Select(n => int.Parse(n)).ToArray());

            return result;
        }

        private static IEnumerable<(string name, int s1, int e1, int s2, int e2)> ParseFields(string data)
        {
            var result = data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Split(new string[] { ": ", "-", " or " }, StringSplitOptions.RemoveEmptyEntries))
                .Select(x => (
                    name: x[0],
                    s1: int.Parse(x[1]),
                    e1: int.Parse(x[2]),
                    s2: int.Parse(x[3]),
                    e2: int.Parse(x[4])
                ));
            return result;
        }

        public static Dictionary<string, int> Decode(string input)
        {
            var data = input.Split(Environment.NewLine + Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var fields = ParseFields(data[0]).ToList();
            var nearby = ParseNearby(data[2]);
            var range = BuildRange(fields, nearby);
            nearby = nearby.Where(x => !x.Any(n => n >= range.Length || !range[n])).ToList();

            var combo = new List<string>[fields.Count];
            for (int i = 0; i < fields.Count; i++)
            {
                combo[i] = GetMatchingFields(i, nearby, fields);
            }

            /*var single = combo.FirstOrDefault(x => x.Count == 1);
            while (single != null)
            {
                combo.re
            }*/

            return null;
        }

        private static List<string> GetMatchingFields(int index, IEnumerable<int[]> nearby, List<(string name, int s1, int e1, int s2, int e2)> fields)
        {
            var partition = nearby.Select(x => x[index]).ToArray();
            var min = partition.Min();
            var max = partition.Max();
            var result = fields
                .Where(x=>x.s1 <= min && x.e2 >= max && Enumerable.Range(x.e1 +1, x.s2 - x.e1).Intersect(partition).IsEmpty())
                .Select(x => x.name)
                .ToList();

            return result;
        }
    }

}
