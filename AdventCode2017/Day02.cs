using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2017
{
    class Day02
    {
        public static void Day2_test1()
        {
            string input = "5 1 9 5\n7 5 3\n2 4 6 8";
            input = File.ReadAllText("day02_file1.txt");
            long checksum = 0;
            string[] lines = input.Split(new char[] { '\n' });
            foreach (string line in lines)
            {
                //Console.WriteLine(line);
                long min = long.MaxValue;
                long max = long.MinValue;
                foreach (string num in line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    //Console.WriteLine(num);
                    long n = long.Parse(num);
                    min = n < min ? n : min;
                    max = n > max ? n : max;
                }
                checksum += max - min;
            }

            Console.WriteLine(checksum);
        }


        public static void Day2_test2()
        {
            string input = "5 9 2 8\n9 4 7 3\n3 8 6 5";
            input = File.ReadAllText("day02_file2.txt");
            long checksum = 0;
            string[] lines = input.Split(new char[] { '\n' });
            foreach (string line in lines)
            {
                long div = 0;
                List<long> list = new List<long>();

                foreach (string num in line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    //Console.WriteLine(num);
                    long n = long.Parse(num);
                    list.Add(n);
                }

                for (int i = 0; i < list.Count; i++)
                {
                    long c = list[i];
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        long d = list[j];
                        long x = Math.Max(c, d);
                        long y = Math.Min(c, d);
                        if (x % y == 0)
                        {
                            div = x / y;
                        }
                    }
                }

                checksum += div;
            }

            Console.WriteLine(checksum);
        }

        

    }
}
