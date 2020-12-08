using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2020CS
{
    public class Day05
    {

        public static void Test1(string filePath)
        {
            var result = File.ReadLines(filePath)
                .Select(x => GetSeatID(x))
                .Max();
            Console.WriteLine(result);
        }

        public static void Test2(string filePath)
        {
            var seats = File.ReadLines(filePath)
                .Select(x => GetSeatID(x));

            var result = Enumerable.Range(seats.Min(), seats.Max() + 1)
                .Except(seats)
                .First();

            Console.WriteLine(result);
        }

        public static int GetSeatID(string v)
        {
            v = v.Replace('F', '1').Replace('B', '0').Replace('L', '1').Replace('R', '0');
            var row = 127 - Convert.ToInt32(v.Substring(0, 7), 2);
            var column = 7 - Convert.ToInt32(v.Substring(7), 2);
            var seat = row * 8 + column;
            return seat;
        }

    }

}
