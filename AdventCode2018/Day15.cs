using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2018
{
    class Day15
    {
        public static void Test1()
        {
            long ap = 65;
            long bp = 8921;
            ap = 591;
            bp = 393;
            long pow = (long)Math.Pow(2, 16);

            long i = 0;

            for (int j = 0; j <= 40e6; j++)
            {
                ap = (ap * 16807) % 2147483647;
                bp = (bp * 48271) % 2147483647;
                i += ap % pow == bp % pow ? 1 : 0;

                if (j % 1000000 == 0)
                {
                    Console.WriteLine("{0} {1}", j, i);
                }
            }

            Console.WriteLine("{0}", i);
            Console.ReadKey();
        }


        public static void Test2()
        {
            long ap = 65;
            long bp = 8921;
            ap = 591;
            bp = 393;
            long pow = (long)Math.Pow(2, 16);

            long i = 0;

            for (int j = 0; j <= 5e6; j++)
            {
                Task<Double>[] taskArray = {
                    Task<Double>.Factory.StartNew(() => DoComputation(16807, ap, 4)),
                    Task<Double>.Factory.StartNew(() => DoComputation(48271, bp, 8))
                };

                ap = (long)taskArray[0].Result;
                bp = (long)taskArray[1].Result;
                i += ap % pow == bp % pow ? 1 : 0;

                if (j % 50000 == 0)
                {
                    Console.WriteLine("{0} {1}", j, i);
                }
            }

            Console.WriteLine("{0}", i);
            Console.ReadKey();
        }


        private static long DoComputation(long factor, long prev, int mul)
        {
            while (true)
            {
                prev = (prev * factor) % 2147483647;
                if (prev % mul == 0)
                {
                    return prev;
                }
            }        
        }




    }
}
