using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventCode2018
{
    class Day03
    {
        public static void Test1()
        {
            Dictionary<Tuple<int, int>, int> dict = new Dictionary<Tuple<int, int>, int>();
            long result = 0;
            foreach (string line in File.ReadLines("day3_1.txt"))
            {
                string[] split = line.Split(new char[] { '#', ' ', '@', ',', ':', 'x' }, StringSplitOptions.RemoveEmptyEntries);
                //Console.WriteLine(string.Join(",", split));

                int x = Int32.Parse(split[1]);
                int y = Int32.Parse(split[2]);
                int w = Int32.Parse(split[3]);
                int h = Int32.Parse(split[4]);
                //Console.WriteLine("{0} {1} {2} {3}", x,y,w,h);
                for (int i = 0; i < w; i++)
                {
                    for (int j = 0; j < h; j++)
                    {
                        Tuple<int, int> key = new Tuple<int, int>(x + i, y + j);
                        if (dict.ContainsKey(key))
                        {
                            dict[key] = 1;
                        }
                        else
                        {
                            dict[key] = 0;
                        }
                    }
                }
            }

            result = dict.Values.Sum();
            Console.WriteLine(result);
        }

        public static void Test2()
        {
            Dictionary<Tuple<int, int>, int> dict = new Dictionary<Tuple<int, int>, int>();
            //long result = 0;
            HashSet<int> set = new HashSet<int>();

            foreach (string line in File.ReadLines("day3_1.txt"))
            {
                string[] split = line.Split(new char[] { '#', ' ', '@', ',', ':', 'x' }, StringSplitOptions.RemoveEmptyEntries);
                //Console.WriteLine(string.Join(",", split));
                int o = Int32.Parse(split[0]);
                int x = Int32.Parse(split[1]);
                int y = Int32.Parse(split[2]);
                int w = Int32.Parse(split[3]);
                int h = Int32.Parse(split[4]);
                
                set.Add(o);
                //Console.WriteLine("{0} {1} {2} {3}", x,y,w,h);
                for (int i = 0; i < w; i++)
                {
                    for (int j = 0; j < h; j++)
                    {
                        Tuple<int, int> key = new Tuple<int, int>(x + i, y + j);
                        if (dict.ContainsKey(key))
                        {
                            if (set.Contains(dict[key]))
                            {
                                set.Remove(dict[key]);
                            }
                            if (set.Contains(o))
                            {
                                set.Remove(o);
                            }

                            dict[key] = 0;                            
                        }
                        else
                        {
                            dict[key] = o;
                        }
                    }
                }
                
            }

            Console.WriteLine(string.Join(",", set.ToList()));
        }


    }
}
