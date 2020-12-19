using System;
using System.Linq;

namespace AdventOfCode2020CS
{
    public class Day12
    {
        enum Dir
        {
            N = 90,
            S = 270,
            E = 0,
            W = 180,
            L = 1,
            R = -1,
            F = 2,
        }

        public static int Part1(string input)
        {
            var actions = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new { dir = Enum.Parse<Dir>($"{x[0]}", true), value = int.Parse(x[1..]) });

            var curDir = Dir.E;
            var x = 0;
            var y = 0;

            foreach (var action in actions)
            {
                switch (action.dir)
                {
                    case Dir.F when curDir == Dir.N:
                    case Dir.N:
                        y -= action.value;
                        break;
                    case Dir.F when curDir == Dir.S:
                    case Dir.S:
                        y += action.value;
                        break;
                    case Dir.F when curDir == Dir.E:
                    case Dir.E:
                        x += action.value;
                        break;
                    case Dir.F when curDir == Dir.W:
                    case Dir.W:
                        x -= action.value;
                        break;
                    case Dir.L:
                    case Dir.R:
                        curDir = (Dir)((360 + (int)curDir + action.value * (int)action.dir) % 360);
                        break;
                    default:
                        break;
                }
            }

            var result = Math.Abs(x) + Math.Abs(y);
            return result;
        }

    }

}
