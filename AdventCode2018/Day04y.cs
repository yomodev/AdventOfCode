using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventCode2018
{
    class Pisolino
    {
        public Pisolino(int lastDay, int lastGuard)
        {
            Day = lastDay;
            Guard = lastGuard;
        }

        public int Guard { get; set; }
        public int Day { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public int Asleep { get { return End - Start; } }
    }


    class Day04
    {
        public static long Test1(string file)
        {
            string[] lines = File.ReadAllLines(file);
            List<Pisolino> list = new List<Pisolino>();

            Pisolino p = new Pisolino(0, 0);
            p.Start = 60;
            p.End = -1;

            int lastGuard = -1;
            int lastDay = -1;
            foreach (string line in lines.OrderBy(x => x))
            {
                string[] split = line.Split(new char[] { '[', ']', ' ', '-', ':', '#' }, StringSplitOptions.RemoveEmptyEntries);
                if (line.Contains("#"))
                {
                    if (!list.Contains(p) && p.Start >= 0)
                    {
                        p.End = 59;
                        list.Add(p);
                    }
                    lastGuard = Int32.Parse(split[6]);
                    lastDay = Int32.Parse(split[1]) * 100 + Int32.Parse(split[2]);
                }
                else if (line.Contains("falls"))
                {
                    p = new Pisolino(lastDay, lastGuard);
                    p.Start = Int32.Parse(split[3]) * 60 + Int32.Parse(split[4]);
                }
                else if (line.Contains("wakes"))
                {
                    p.End = Int32.Parse(split[3]) * 60 + Int32.Parse(split[4]);
                    list.Add(p);
                }
            }
            Console.WriteLine("count {0}", list.Count);

            var results = from l in list
                          group l by l.Guard into g
                          select new { g.Key, Sum = g.Sum(x => x.Asleep), List = g.ToList() };


            //Console.WriteLine(results.Where(x => x.Sum == results.Max(y => y.Sum)).First().Key);
            var max2 = results.OrderByDescending(x => x.Sum);
            var max = results.OrderByDescending(x => x.Sum).First();
            List<Pisolino> pisolini = max.List;
            Console.WriteLine("guard {0} pisolini {1} sleep {2}", max.Key, pisolini.Count, max.Sum);

            foreach (var pisolino in pisolini)
            {
                for (int i = 0; i < 60; i++)
                {
                    bool x = pisolino.Start <= i && pisolino.End > i;
                    Console.Write("{0}", x ? '#' : '.');
                }

                Console.WriteLine(" {0}", pisolino.Day);
            }


            int minute = -1;
            int prevCount = 0;
            for (int i = 0; i < 60; i++)
            {
                int count = 0;
                foreach (var pisolino in pisolini)
                {
                    if (pisolino.Start <= i && pisolino.End > i)
                    {
                        count++;
                    }
                }

                //Console.WriteLine("minute {0}: {1}", i, count);
                if (count > prevCount)
                {
                    prevCount = count;
                    minute = i;
                }
            }

            long result = max.Key * minute;
            Console.WriteLine("guard {0}  minute {1} = {2}", max.Key, minute, result);
            return result;
        }



        public static long Test2(string file)
        {
            string[] lines = File.ReadAllLines(file);
            List<Pisolino> list = new List<Pisolino>();

            Pisolino p = new Pisolino(0, 0);
            p.Start = 60;
            p.End = -1;

            int lastGuard = -1;
            int lastDay = -1;
            foreach (string line in lines.OrderBy(x => x))
            {
                string[] split = line.Split(new char[] { '[', ']', ' ', '-', ':', '#' }, StringSplitOptions.RemoveEmptyEntries);
                if (line.Contains("#"))
                {
                    if (!list.Contains(p) && p.Start >= 0)
                    {
                        p.End = 59;
                        list.Add(p);
                    }
                    lastGuard = Int32.Parse(split[6]);
                    lastDay = Int32.Parse(split[1]) * 100 + Int32.Parse(split[2]);
                }
                else if (line.Contains("falls"))
                {
                    p = new Pisolino(lastDay, lastGuard);
                    p.Start = Int32.Parse(split[3]) * 60 + Int32.Parse(split[4]);
                }
                else if (line.Contains("wakes"))
                {
                    p.End = Int32.Parse(split[3]) * 60 + Int32.Parse(split[4]);
                    list.Add(p);
                }
            }
            //Console.WriteLine("count {0}", list.Count);

            var results = from l in list
                          group l by l.Guard into g
                          select new { g.Key, Sum = g.Sum(x => x.Asleep), List = g.ToList() };


            //Console.WriteLine(results.Where(x => x.Sum == results.Max(y => y.Sum)).First().Key);
            //var max2 = results.OrderByDescending(x => x.Sum);
            var max = results.OrderByDescending(x => x.Sum).First();
            List<Pisolino> pisolini = max.List;
            //Console.WriteLine("guard {0} pisolini {1} sleep {2}", max.Key, pisolini.Count, max.Sum);

            int dormiglione = -1;
            int minuto = -1;
            int prevCount = 0;
            foreach (var guard in results)
            {

                for (int i = 0; i < 60; i++)
                {
                    //bool x = pisolino.Start <= i && pisolino.End > i;
                    //Console.Write("{0}", x ? '#' : '.');
                    int count = 0;
                    foreach (var pisolino in guard.List)
                    {
                        if (pisolino.Start <= i && pisolino.End > i)
                        {
                            count++;
                        }
                    }

                    //Console.WriteLine("minute {0}: {1}", i, count);
                    if (count > prevCount)
                    {
                        prevCount = count;
                        minuto = i;
                        dormiglione = guard.Key;
                    }
                    //Console.WriteLine(" {0}", pisolino.Day);
                }
            }
            
            long result = dormiglione * minuto;
            Console.WriteLine("guard {0}  minute {1} = {2}", dormiglione, minuto, result);
            return result;
        }


    }
}
