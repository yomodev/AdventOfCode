using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020CS
{
    class Day03
    {
        public static void Test1a(string filePath)
        {
            var map = File.ReadLines(filePath).ToArray();
            var w = map[0].Length;
            int trees = 0;
            int x = 3;
            foreach (var line in map.Skip(1))
            {
                trees += line[x] == '#' ? 1 : 0;
                x = (x + 3) % w;
            }

            Console.WriteLine(trees);
        }

        public static void Test1(string filePath)
        {
            var trees = File.ReadLines(filePath)
                .Skip(1)
                .Aggregate(
                    (trees: 0, x: 3), 
                    (prev, line) => (trees: prev.trees + (line[prev.x] == '#' ? 1 : 0), x :(prev.x +3) % line.Length),
                    res => res.trees
                );
            Console.WriteLine(trees);
        }

        public static void Test2(string filePath)
        {
            var slopes = new List<(int right, int down)> { (1,1), (3,1), (5,1), (7,1), (1,2) };
            var map = File.ReadLines(filePath).ToArray().Select((x, i) => new { line = x, i });

            var result = slopes.Multiply(
                slope => CountTrees(slope.right, map.Skip(slope.down).Where(x=>x.i % slope.down == 0).Select(x=>x.line))
            );

            Console.WriteLine(result);
        }

        private static long CountTrees(int right, IEnumerable<string> map)
        {
            var result = map.Aggregate(
                    (trees: 0, x: right),
                    (prev, line) => (trees: prev.trees + (line[prev.x] == '#' ? 1 : 0), x: (prev.x + right) % line.Length),
                    res => res.trees
                );
            Console.WriteLine("{0} {1}", right, result);
            return result;
        }

    }



}
