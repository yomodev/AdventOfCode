using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021Lib
{
    public class Day02
    {
        class Coords { 
            public int x; 
            public int y; 
            public int aim;

            public Coords H(int amount)
            {
                x += amount;
                return this;
            }

            public Coords V(int amount)
            {
                y += amount;
                return this;
            }

            public Coords A(int amount)
            {
                aim += amount;
                return this;
            }
        };


        public int Part1(IEnumerable<string> enumerable)
        {
            var cmd = new Dictionary<string, Func<Coords, int, Coords>>
            {
                { "forward", (coords, amount) => coords.H(amount) },
                { "up", (coords, amount) => coords.V(-amount) },
                { "down", (coords, amount) => coords.V(amount) },
            };

            var coords = enumerable.Aggregate(
                new Coords(),
                (accum, item) => cmd[item.Split(' ').First()](accum, Int32.Parse(item.Split(' ').Last())));

            return coords.x * coords.y;
        }

        public int Part1v1(IEnumerable<string> enumerable)
        {
            var x = 0;
            var y = 0;

            foreach (var cmd in enumerable)
            {
                var cmds = cmd.Split(' ');
                var amount = Int32.Parse(cmds.Last());
                switch (cmds.First())
                {
                    case "forward":
                        x += amount;
                        break;
                    case "up":
                        y -= amount;
                        break;
                    case "down":
                        y += amount;
                        break;
                    default:
                        throw new Exception(cmds.First());
                }
            }

            var result = x * y;
            return result;
        }


        public int Part2(IEnumerable<string> enumerable)
        {
            var cmd = new Dictionary<string, Func<Coords, int, Coords>>
            {
                { "forward", (coords, amount) => coords.H(amount).V(coords.aim * amount) },
                { "up", (coords, amount) => coords.A(-amount) },
                { "down", (coords, amount) => coords.A(amount) },
            };

            var coords = enumerable.Aggregate(
                new Coords(),
                (accum, item) => cmd[item.Split(' ').First()](accum, Int32.Parse(item.Split(' ').Last())));

            return coords.x * coords.y;
        }

        public int Part2v1(IEnumerable<string> enumerable)
        {
            var x = 0;
            var y = 0;
            var aim = 0;

            foreach (var cmd in enumerable)
            {
                var cmds = cmd.Split(' ');
                var amount = Int32.Parse(cmds.Last());
                switch (cmds.First())
                {
                    case "forward":
                        x += amount;
                        y += aim * amount;
                        break;
                    case "up":
                        aim -= amount;
                        break;
                    case "down":
                        aim += amount;
                        break;
                    default:
                        throw new Exception(cmds.First());
                }
            }

            var result = x * y;
            return result;
        }



    }
}
