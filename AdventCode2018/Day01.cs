using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2018
{
    class Day01
    {
        public static void Test1()
        {
            long result = 0;
            foreach (string line in File.ReadLines("day1_1.txt"))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                long value;
                if (long.TryParse(line, out value))
                {
                    result += value;
                }
                else
                {
                    Console.WriteLine("invalid value {0}", line);
                }
            }

            Console.WriteLine(result);
        }

        public static void Test2()
        {
            long result = 0;
            bool loop = true;
            HashSet<long> set = new HashSet<long>() { 0 };
            while (loop)
            {
                foreach (string line in File.ReadLines("day1_1.txt"))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    long value;
                    if (long.TryParse(line, out value))
                    {
                        result = result + value;
                        if (set.Contains(result))
                        {
                            Console.WriteLine("found {0}", result);
                            loop = false;
                            break;
                        }
                        else
                        {
                            set.Add(result);
                        }
                    }
                    else
                    {
                        Console.WriteLine("invalid value {0}", line);
                    }
                }

                Console.WriteLine("len {0}", set.Count);
            }

            //Console.WriteLine("no result");
        }


    }
}
