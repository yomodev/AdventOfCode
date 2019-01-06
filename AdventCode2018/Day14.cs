using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AdventCode2018
{
    public class Day14
    {

        public static string Test1(int recipes)
        {
            List<int> list = new List<int> { 3, 7, 1, 0 };
            long step = 0;
            int o1 = 0;
            int o2 = 1;

            while (true)
            {
                step++;
                int v1 = list[o1];
                int v2 = list[o2];

                int n = v1 + v2;
                if (n > 9)
                {
                    list.Add(1);
                    n -= 10;
                }
                list.Add(n);

                o1 = (o1 + v1 + 1) % (list.Count);
                o2 = (o2 + v2 + 1) % (list.Count);

                if (recipes + 10 <= list.Count)
                {
                    string result = string.Join("", list.Skip(recipes).Take(10));
                    Console.WriteLine(result);
                    return result;
                }
            }
        }

        public static long Test2(string score)
        {
            LinkedList<int> list = new LinkedList<int>();
            LinkedList<int> scorel = new LinkedList<int>();
            foreach (var item in score)
            {
                scorel.AddLast(item - '0');
            }

            long step = 0;
            LinkedListNode<int> e1 = list.AddLast(3);
            LinkedListNode<int> e2 = list.AddLast(7);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            
            while (true)
            {
                step++;
                int n = e1.Value + e2.Value;
                if (n > 9)
                {
                    list.AddLast(1);

                    if (Compare(list, scorel))
                    {
                        break;
                    }
                }

                list.AddLast(n % 10);
                if (Compare(list, scorel))
                {
                    break;
                }

                // move elvs
                for (int i = e1.Value; i >= 0; i--)
                {
                    e1 = e1.Next ?? list.First;
                }
                for (int i = e2.Value; i >= 0; i--)
                {
                    e2 = e2.Next ?? list.First;
                }

                /*if (sw.ElapsedMilliseconds >= 5000)
                {
                    Console.WriteLine("speed {0}, len {1}", step - prevStep, list.Count);
                    prevStep = step;
                    sw.Restart();
                }*/
            }

            long result = list.Count - scorel.Count;
            Console.WriteLine("{0} {1}", sw.ElapsedMilliseconds, result);
            return result;
        }

        private static bool Compare(LinkedList<int> l1, LinkedList<int> l2)
        {
            if (l1.Count < l2.Count)
            {
                return false;
            }

            var x1 = l1.Last;
            var x2 = l2.Last;
            for (int i = 0; i < l2.Count; i++)
            {
                if (x1.Value != x2.Value)
                {
                    return false;
                }
                x1 = x1.Previous;
                x2 = x2.Previous;
            }

            return true;
        }

        private static void print(List<int> list, int o1, int o2, long step)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                string v = list[i].ToString();
                if (o1 == i)
                {
                    v = "(" + v + ")";
                }
                else if (o2 == i)
                {
                    v = "[" + v + "]";
                }
                sb.Append(" " + v);
            }

            string s = sb.ToString();
            Console.WriteLine("{0} {1} {2} | {3}", step, o1, o2, s);
            //File.AppendAllText("day14_test1.txt", s + Environment.NewLine);
        }
    }

}
