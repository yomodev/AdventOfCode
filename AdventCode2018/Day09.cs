using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCode2018
{
    public class Day09
    {
        public static long Test1(int elves = 9, int marbles = 25)
        {
            List<int> list = new List<int>(marbles) { 0 };
            Dictionary<int, long> scores = new Dictionary<int, long>();
            int marble = 1;
            int elve = 1;
            int current = 0;
            while (marble <= marbles)
            {
                if (marble % 10000 == 0)
                {
                    Console.WriteLine(marble);
                }
                if (marble % 23 == 0)
                {
                    if (!scores.ContainsKey(elve))
                    {
                        scores[elve] = 0;
                    }

                    current -= 7;
                    current = current < 0 ? list.Count + current : current;
                    //Console.WriteLine("c {0}, list {1}", current, list.Count);
                    int value = list[current];
                    list.RemoveAt(current);

                    if (current == list.Count)
                    {
                        current = 0;
                    }
                    scores[elve] += marble + value;
                }
                else if (current == list.Count - 1)
                {
                    current = 1;
                    list.Insert(current, marble);
                }
                else if (current + 1 == list.Count)
                {
                    current++;
                    list.Add(marble);
                }
                else
                {
                    current += 2;
                    list.Insert(current, marble);
                }

                //printa(list, current, elve);
                marble++;
                elve = elve + 1 > elves ? 1 : elve + 1;
            }

            long result = scores.Values.Max();
            Console.WriteLine("done {0}", result);
            return result;
        }

        private static void printa(List<int> list, int current, int elve)
        {
            Console.Write("[{0}]", elve);

            for (int i = 0; i < list.Count; i++)
            {
                if (current == i)
                {
                    Console.Write(" ({0})", list[i]);
                }
                else
                {
                    Console.Write(" {0}", list[i]);
                }
            }

            Console.WriteLine("");
        }



        public static long Test2(int elves, int marbles)
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(0);
            Dictionary<int, long> scores = new Dictionary<int, long>();
            int marble = 1;
            int elve = 1;
            LinkedListNode<int> current = list.Last;
            while (marble <= marbles)
            {
                /*
                if (marble % 10000 == 0)
                {
                    Console.WriteLine(marble);
                }
                */
                if (marble % 23 == 0)
                {
                    if (!scores.ContainsKey(elve))
                    {
                        scores[elve] = 0;
                    }

                    for (int i = 0; i < 7; i++)
                    {
                        current = current.Previous;
                        if (current == null)
                        {
                            current = list.Last;
                        }
                    }

                    LinkedListNode<int> nodeToRemove = current;
                    int value = current.Value;
                    scores[elve] += marble + value;
                    current = current.Next == null ? list.First : current.Next;
                    list.Remove(nodeToRemove);
                }
                else if (current == list.Last)
                {
                    current = list.AddAfter(list.First, marble);
                }
                else if (current == list.Last.Previous)
                {
                    current = list.AddLast(marble);
                }
                else
                {
                    current = list.AddAfter(current.Next, marble);
                }

                //printL(list, current, elve);
                marble++;
                elve = elve + 1 > elves ? 1 : elve + 1;
            }

            long result = scores.Values.Max();
            Console.WriteLine("done {0}", result);
            return result;
        }

        private static void printL(LinkedList<int> list, LinkedListNode<int> current, int elve)
        {
            Console.Write("[{0}]", elve);

            foreach (var item in list)
            {   
                if (current.Value == item)
                {
                    Console.Write(" ({0})", item);
                }
                else
                {
                    Console.Write(" {0}", item);
                }
            }

            Console.WriteLine("");
        }
    }
}
