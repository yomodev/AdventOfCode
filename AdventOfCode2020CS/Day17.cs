using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020CS
{
    public class Day17
    {
        public struct Range : IRange
        {
            public int First { get; set; }
            public int Last { get; set; }
        }


        public static int Part1(string input)
        {
            var dict = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select((line, x) => line.Select((v, y) => new { key = (x, y, z: 0), active = v == '#' }))
                .SelectMany(x => x)
                .ToDictionary(k => k.key, v => v.active);

            for (int step = 0; step < 6; step++)
            {
                var prev = dict;
                dict = new Dictionary<(int x, int y, int z), bool>();
                for (int x = prev.Keys.Min(x => x.x) - 1; x < prev.Keys.Max(x => x.x) + 2; x++)
                {
                    for (int y = prev.Keys.Min(y => y.y) - 1; y < prev.Keys.Max(y => y.y) + 2; y++)
                    {
                        for (int z = prev.Keys.Min(z => z.z) - 1; z < prev.Keys.Max(z => z.z) + 2; z++)
                        {
                            var coord = (x, y, z);
                            dict[(x, y, z)] = CalcPart1(prev, coord);
                        }
                    }
                }
                //Debug(dict, step + 1);
            }

            var result = dict.Values.Count(x => x);
            return result;
        }

        private static void Debug(Dictionary<(int x, int y, int z), bool> dict, int step)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"step = {step}");

            foreach (int z in dict.Keys.Select(z => z.z).Distinct().OrderBy(z => z))
            {
                sb.AppendLine($"z = {z}");
                foreach (int y in dict.Keys.Select(y => y.y).Distinct().OrderBy(y => y))
                {
                    foreach (int x in dict.Keys.Select(x => x.x).Distinct().OrderBy(x => x))
                    {
                        sb.Append(dict[(x, y, z)] ? "#" : ".");
                    }
                    sb.AppendLine();
                }
                sb.AppendLine();
            }

            Console.WriteLine(sb);
        }

        private static bool CalcPart1(Dictionary<(int x, int y, int z), bool> prev, (int x, int y, int z) coord)
        {
            var near = new (int x, int y, int z)[]
            {
                (coord.x, coord.y, coord.z +1),
                (coord.x-1, coord.y, coord.z +1),
                (coord.x-1, coord.y+1, coord.z +1),
                (coord.x-1, coord.y-1, coord.z +1),
                (coord.x+1, coord.y, coord.z +1),
                (coord.x+1, coord.y+1, coord.z +1),
                (coord.x+1, coord.y-1, coord.z +1),
                (coord.x, coord.y+1, coord.z +1),
                (coord.x, coord.y-1, coord.z +1),

                (coord.x, coord.y, coord.z -1),
                (coord.x-1, coord.y, coord.z -1),
                (coord.x-1, coord.y+1, coord.z -1),
                (coord.x-1, coord.y-1, coord.z -1),
                (coord.x+1, coord.y, coord.z -1),
                (coord.x+1, coord.y+1, coord.z -1),
                (coord.x+1, coord.y-1, coord.z -1),
                (coord.x, coord.y+1, coord.z -1),
                (coord.x, coord.y-1, coord.z -1),

                (coord.x, coord.y+1, coord.z ),
                (coord.x, coord.y-1, coord.z ),
                (coord.x+1, coord.y, coord.z ),
                (coord.x+1, coord.y+1, coord.z ),
                (coord.x+1, coord.y-1, coord.z ),
                (coord.x-1, coord.y, coord.z ),
                (coord.x-1, coord.y+1, coord.z ),
                (coord.x-1, coord.y-1, coord.z ),

            }.Count(x => prev.ContainsKey(x) && prev[x]);

            prev.TryGetValue(coord, out bool active);
            if ((active && (near == 2 || near == 3)) || near == 3)
            {
                return true;
            }

            return false;
        }

        static string GenKey(int dim, params int[] coords)
        {
            var list = coords.ToList();
            return string.Join(',', list.Concat(Enumerable.Repeat(0, dim - coords.Length)).Take(dim));
        }

        public static int Part2(string input, int dim = 4)
        {
            var dict = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select((line, x) => line.Select((v, y) => new { key = GenKey(dim, x, y), active = v == '#' }))
                .SelectMany(x => x)
                .ToDictionary(k => k.key, v => v.active);

            for (int step = 0; step < 6; step++)
            {
                var prev = dict;
                dict = new Dictionary<string, bool>();
                foreach (int[] coord in MultiDimensionIterator(Expand(KeyStats(dim, prev.Keys.ToArray()))))
                {
                    var scoord = GenKey(dim, coord);
                    dict[scoord] = Calc(coord, prev);
                }
            }

            var result = dict.Values.Count(x => x);
            return result;
        }

        public static IEnumerable<int[]> MultiDimensionIterator(IRange[] ranges)
        {
            var step = ranges.Select(x => x.First).ToArray();
            if (ranges.Length == 0)
            {
                yield return null;
            }

            yield return step;

            var min = step.ToArray();
            var max = ranges.Select(x => x.Last).ToArray();
            int unit = ranges.Length - 1;
            while (false == Enumerable.SequenceEqual(step, max))
            {
                step[unit]++;
                int i = unit;
                while (step[i] > max[i])
                {
                    step[i] = min[i];
                    i--;
                    if (i < 0)
                    {
                        goto yld;
                    }
                    step[i]++;
                    continue;
                }

            yld:
                yield return step;
            }
        }

        private static IRange[] Expand(IEnumerable<Range> range)
        {
            var result = range.Select(x => new Range { First = x.First - 1, Last = x.Last + 1 }).Cast<IRange>().ToArray();
            return result;
        }

        private static Range[] KeyStats(int dim, string[] vs)
        {
            var splitted = vs.Select(x => x.Split(',').Select(y => Int32.Parse(y)).ToArray()).ToArray();

            var result = Enumerable.Range(0, dim)
                .Select(i => new Range { First = splitted.Min(x => x[i]), Last = splitted.Max(x => x[i]) })
                .ToArray();

            return result;
        }

        private static bool Calc(int[] coord, Dictionary<string, bool> prev)
        {
            var near = MultiDimensionIterator(
                Expand(coord.Select(x => new Range { First = x, Last = x })))
                .Count(x => { prev.TryGetValue(GenKey(x.Length, x), out bool b); return b; });

            prev.TryGetValue(GenKey(coord.Length, coord), out bool active);
            near -= active ? 1 : 0;

            bool b = (active && (near == 2 || near == 3)) || near == 3;
            return b;
        }

    }

    public interface IRange
    {
        public int First { get; }
        public int Last { get; }
    }
}
