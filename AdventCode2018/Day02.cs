using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventCode2018
{
    class Day02
    {
        public static void Test1()
        {
            long sum2 = 0;
            long sum3 = 0;
            foreach (string line in File.ReadLines("day2_1.txt"))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                Dictionary<char, int> dict = new Dictionary<char, int>();
                foreach (char c in line)
                {
                    if (dict.ContainsKey(c))
                    {
                        dict[c]++;
                    }
                    else
                    {
                        dict[c] = 1;
                    }
                }

                sum2 += dict.ContainsValue(2) ? 1 : 0;
                sum3 += dict.ContainsValue(3) ? 1 : 0;
            }

            Console.WriteLine(sum2 * sum3);
        }


        public static void Test2()
        {
            string result = string.Empty;
            string[] lines = File.ReadAllLines("day2_1.txt");
            int linesCount = lines.Count();
            for (int i = 0; i < linesCount -1; i++)
            {
                string compare = lines[i];
                for (int j = i + 1; j < linesCount; j++)
                {
                    string line = lines[j];
                    int diff = 0;
                    for (int k = 0; k < line.Length; k++)
                    {
                        if (compare[k] == line[k])
                        {
                            result += line[k];
                        }
                        else
                            diff++;
                    }

                    if (diff == 1)
                    {
                        Console.WriteLine(result);
                        linesCount = 0;
                    }

                    result = string.Empty;
                }
            }

            //Console.WriteLine(result);
        }
    }
}
