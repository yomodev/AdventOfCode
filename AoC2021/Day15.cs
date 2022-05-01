using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021Lib
{
    public class Day15
    {
        public int Part1(string data)
        {
            var board = ReadFile(data);
            return 0;
        }

        private Dictionary<Point,int> ReadFile(string data)
        {
            var dict = data.Split(Environment.NewLine)
                .Select((line, y) => 
                    line.Select((c, x) => 
                        new { point = new Point(x, y), value = c - '0' }))
                .SelectMany(x => x)
                .ToDictionary(k => k.point, v => v.value);
            return dict;
        }

        public int Part2(string data)
        {
            return 0;
        }
    }
}
