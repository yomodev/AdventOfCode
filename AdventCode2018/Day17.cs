using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventCode2018
{
    class Day17
    {
        public static int calc(int step, int limit, int find)
        {
            List<int> buffer = new List<int>() { 0 };
            int pos = 1;
            int i = 1;
            while (i <= limit)
            {
                pos = (pos + step) % buffer.Count + 1;
                buffer.Insert(pos, i);
                i++;

                if (i % 50000 == 0)
                {
                    Console.WriteLine(i);
                }

                pos = buffer.IndexOf(find);
            }
            return pos + 1 < buffer.Count ? buffer[pos + 1] : buffer[0];
        }

        public static void Test()
        {
            Console.WriteLine("{0}, 638", calc(3, 2017, 2017));
            Console.WriteLine("{0}, 777", calc(376, 2017, 2017));
            Console.WriteLine("{0}", calc(376, (int)5e6, 0));
            Console.ReadKey();
        }




    }
}
