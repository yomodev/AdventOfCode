using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2020CS
{
    class Day02
    {
        public static void Test1(string filePath)
        {
            Console.WriteLine(
                File.ReadLines(filePath)
                .Select(line => line.Split(' ', '-', ':'))
                .Select(a => new { min = int.Parse(a[0]), max = int.Parse(a[1]), c = a[2][0], pass = a[4], count = a[4].Count(x => x == a[2][0]) })
                .Where(x => x.count >= x.min && x.count <= x.max)
                .Count()
                );
        }

        public static void Test2(string filePath)
        {
            Console.WriteLine(
                File.ReadLines(filePath)
                .Select(line => line.Split(' ', '-', ':'))
                .Select(a => new { p1 = int.Parse(a[0]), p2 = int.Parse(a[1]), c = a[2][0], pass = a[4] })
                .Where(x => x.pass[x.p1-1] == x.c ^ x.pass[x.p2-1] == x.c)
                .Count()
                );
        }



    }

}
