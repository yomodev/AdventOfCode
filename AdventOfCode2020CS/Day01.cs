using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020CS
{
    class Day01
    {
        public static void Test1a(string filePath)
        {
            Test1(File.ReadLines(filePath));
        }

        public static void Test1(IEnumerable<string> lines)
        {
            Test1(lines.Select(line => int.Parse(line)).ToArray());
        }

        public static void Test1(int[] entries)
        {
            long result = 0;
            for (int i = 0; i < entries.Length - 2; i++)
            {
                for (int j = i + 1; j < entries.Length - 1; j++)
                {
                    if (entries[i] + entries[j] == 2020)
                    {
                        result = entries[i] * entries[j];
                        goto Found;
                    }
                }
            }

        Found:
            Console.WriteLine(result);
        }

        public static void Test1(string filePath)
        {
            Console.WriteLine(
                File.ReadLines(filePath)
                .Select(line => int.Parse(line)).ToArray()
                .DifferentCombinations(2)
                .Where(x => x.Sum() == 2020).FirstOrDefault()
                .Aggregate(1, (acc, val) => acc * val));
        }



        public static void Test2(string filePath)
        {
            Console.WriteLine(
                File.ReadLines(filePath)
                .Select(line => int.Parse(line)).ToArray()
                .DifferentCombinations(3)
                .Where(x => x.Sum() == 2020).FirstOrDefault()
                .Aggregate(1, (acc, val) => acc * val));
        }


        public static void Test2A(string filePath)
        {
            var entries = File.ReadLines(filePath).Select(line => int.Parse(line)).ToList();
            
            entries.ForEach(x => entries.ForEach(y => entries.ForEach(z =>
            {
                if (x != y && y != z && x != z && x + y + z == 2020)
                {
                    Console.WriteLine(x * y * z);
                }
            })));
        }

    }
}
