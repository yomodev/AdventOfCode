using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021Lib
{
    public class Day12
    {
        public Dictionary<string, HashSet<string>> Input { get; private set; }
        public List<Path> Paths { get; private set; } = new List<Path>();

        public class Path : List<string>
        {
            public Path() : base()
            { }

            public Path(IEnumerable<string> collection) : base(collection)
            { }
        }

        public int Part1(IEnumerable<string> data)
        {
            Input = CreateDict(data);
            Explore2(new Path { "start" }, x => x.Count(y => y == x.Last()) > 1);
            return Paths.Count;
        }

        public int Part2(IEnumerable<string> data)
        {
            Input = CreateDict(data);
            Explore2(new Path { "start" }, Test3);
            return Paths.Count;
        }

        private void Explore2(List<string> path, Predicate<Path> predicate)
        {
            foreach (var item in Input[path.Last()])
            {
                var curPath = new Path(path) { item };
                if (item == "end")
                {
                    Paths.Add(curPath);
                    continue;
                }

                if (item == item.ToLower() && predicate(curPath))
                {
                    continue;
                }

                Explore2(curPath, predicate);
            }
        }

        private static Dictionary<string, HashSet<string>> CreateDict(IEnumerable<string> data)
        {
            void Add(Dictionary<string, HashSet<string>> dict, string k, string v)
            {
                if (!dict.ContainsKey(k))
                {
                    dict[k] = new HashSet<string>();
                }
                dict[k].Add(v);
            }

            var dict = new Dictionary<string, HashSet<string>>();
            foreach (var item in data.Select(x => x.Split('-')))
            {
                var k = item.First();
                var v = item.Last();
                if (k != "end" && v != "start")
                {
                    Add(dict, k, v);
                }
                if (k != "start" && v != "end")
                {
                    Add(dict, v, k);
                }
            }

            return dict;
        }

        // slightly slower
        private bool Test2(Path path)
        {
            var cnt = path.Where(e => e == e.ToLower())
                .GroupBy(k => k)
                .Where(x => x.Count() > 1)
                .Sum(x => x.Count());
            return cnt > 2;
        }

        // slightly faster
        private bool Test3(Path path)
        {
            var dict = new Dictionary<string, int>();
            var set = new HashSet<string>();
            for (int i = path.Count -1; i > 0; i--)
            {
                var item = path[i];
                if (item != item.ToLower())
                {
                    continue;
                }
                var value = 0;
                if (!dict.ContainsKey(item))
                {
                    dict[item] = 1;
                }
                else
                {
                    value = ++dict[item];
                    if (value > 1)
                    {
                        set.Add(item);
                        if (set.Count > 1 || value > 2)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
