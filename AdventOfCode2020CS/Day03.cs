using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020CS
{
    public class Day03
    {
        public static int Part1(string input)
        {
            var trees = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Aggregate(
                    (trees: 0, x: 3),
                    (prev, line) => (
                        trees: prev.trees + (line[prev.x] == '#' ? 1 : 0),
                        x: (prev.x + 3) % line.Length
                        ),
                    res => res.trees
                );
            return trees;
        }

        public static long Part2(string input)
        {
            var slopes = new List<(int right, int down)>
                { (1,1), (3,1), (5,1), (7,1), (1,2) };

            var map = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .ToArray()
                .Select((x, index) => new { line = x, index });

            var result = slopes.Multiply(
                slope => CountTrees(slope.right,
                    map.Skip(slope.down)
                        .Where(x => x.index % slope.down == 0)
                        .Select(x => x.line))
            );

            return result;
        }

        public static long CountTrees(int right, IEnumerable<string> map)
        {
            var result = map.Aggregate(
                    (trees: 0, x: right),
                    (prev, line) => (
                        trees: prev.trees + (line[prev.x] == '#' ? 1 : 0),
                        x: (prev.x + right) % line.Length
                        ),
                    res => res.trees
                );

            return result;
        }

    }

}
