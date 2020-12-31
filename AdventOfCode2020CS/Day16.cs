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
            IEnumerable<int> result = GetInvalidNearby(fields, nearby);

            return result.Sum();
        }

        private static IEnumerable<int> GetInvalidNearby(IEnumerable<(string name, int s1, int e1, int s2, int e2)> fields, IEnumerable<int[]> nearby)
        {
            var max = fields.Max(x => Math.Max(x.e1, x.e2));
            var range = new bool[max + 1];
            
            fields.Select(x => Enumerable.Range(x.s1, x.e1 - x.s1 + 1))
                .SelectMany(x => x)
                .Concat(fields.Select(x => Enumerable.Range(x.s2, x.e2 - x.s2 + 1))
                .SelectMany(x => x))
                .ForEach(x => range[x] = true);

            var result = nearby.SelectMany(x => x)
                .Where(x => x > max || !range[x]);

            return result;
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

            return null;
        }
    }

}
