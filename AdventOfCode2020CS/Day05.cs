﻿using System;
using System.Linq;

namespace AdventOfCode2020CS
{
    public class Day05
    {
        public static int Part1(string input)
        {
            var result = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(GetSeatID)
                .Max();
            return result;
        }

        public static int Part2(string input)
        {
            var seats = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(GetSeatID);

            var result = Enumerable.Range(seats.Min(), seats.Max() + 1)
                .Except(seats)
                .First();

            return result;
        }

        public static int GetSeatID(string v)
        {
            v = v.Replace('F', '1').Replace('B', '0').Replace('L', '1').Replace('R', '0');
            var row = 127 - Convert.ToInt32(v.Substring(0, 7), 2);
            var column = 7 - Convert.ToInt32(v[7..], 2);
            var seat = row * 8 + column;
            return seat;
        }

    }

}
