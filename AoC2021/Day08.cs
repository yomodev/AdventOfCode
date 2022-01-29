using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021Lib
{
    public class Day08
    {
        public int Part1(IEnumerable<string> data)
        {
            var output = data.Select(x => x.Split('|').Last().Trim().Split(' '));
            var sum = output.Sum(x => x.Where(d => d.Length != 5 && d.Length != 6).Count());
            return sum;
        }

        public long Part2(IEnumerable<string> data)
        {
            var io = data.Select(x => x.Split('|'))
                .Select(x => new
                {
                    input = Extract(x.First()),
                    output = Extract(x.Last())
                });

            var sum = 0;
            foreach (var line in io)
            {
                Dictionary<string, string> map = new();
                map[line.input.First(x=>x.Count == 2).ToString()] = "1";
                
                var seven = line.input.First(x => x.Count == 3);
                map[seven.ToString()] = "7";
                
                map[line.input.First(x=>x.Count == 4).ToString()] = "4";
                map[line.input.First(x=>x.Count == 7).ToString()] = "8";

                // [0 | 6 | 9] -7 == 4 ?=> 6
                var six = line.input.Where(x => x.Count == 6).First(x => x.Except(seven).Count() == 4);
                map[six.ToString()] = "6";

                // [2 | 3 | 5] -7 == 2 ?=> 3
                var three = line.input.Where(x => x.Count == 5).First(x => x.Except(seven).Count() == 2);
                map[three.ToString()] = "3";

                // [0 -6 9] -3
                var ie09 = line.input.Where(x => x.Count == 6 && x.ToString() != six.ToString()).ToList();
                map[ie09.First(x => x.Except(three).Count() == 2).ToString()] = "0";
                map[ie09.First(x => x.Except(three).Count() == 1).ToString()] = "9";

                // [2 -3 5] -6
                var ie25 = line.input.Where(x => x.Count == 5 && x.ToString() != three.ToString()).ToList();
                map[ie25.First(x => x.Except(six).Count() == 0).ToString()] = "5";
                map[ie25.First(x => x.Except(six).Count() == 1).ToString()] = "2";

                var output = int.Parse(string.Join(null, line.output.Select(x => map[x.ToString()])));
                sum += output;
            }

            return sum;
        }

        private IEnumerable<Digit> Extract(string v)
        {
            return v.Trim().Split(' ').Select(w => new Digit(w));
        }

        public class Digit : HashSet<char>
        {
            public Digit(IEnumerable<char> collection) : base(collection)
            {
            }

            public override string ToString()
            {
                return string.Join(null, this.OrderBy(y => y));
            }
        }
    }
}
