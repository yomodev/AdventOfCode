using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventCode2018
{
    public class Day05
    {
        public static int Test1(string file)
        {
            List<char> l = File.ReadAllText(file).ToList();
            int result = React(l);

            Console.WriteLine("result {0}", result);
            return result;
        }

        public static int Test2(string file)
        {
            List<char> l = File.ReadAllText(file).ToList();

            Dictionary<char, int> d = new Dictionary<char, int>();
            foreach (var c in l)
            {
                char x = char.ToUpper(c);
                if (!d.ContainsKey(x))
                {
                    d[x] = 1;
                }
                else
                {
                    d[x]++;
                }
            }

            int result = Int32.MaxValue;
            foreach (var item in d.OrderByDescending(x => x.Value))
            {
                List<char> l2 = string.Join("", l)
                    .Replace(item.Key.ToString().ToUpper(), "")
                    .Replace(item.Key.ToString().ToLower(), "")
                    .ToList();

                result = Math.Min(result, React(l2));
                Console.WriteLine("{0} {1}", item.Key, result);
            }
            
            Console.WriteLine("result {0}", result);
            return result;
        }



        private static int React(List<char> l)
        {
            int result = l.Count;
            int prevLen = result;
            int offset = 0;
            do
            {
                prevLen = result;

                for (int i = offset; i < l.Count - 1; i++)
                {
                    if (char.ToUpper(l[i]) == char.ToUpper(l[i + 1]) && l[i] != l[i + 1])
                    {
                        l.RemoveRange(i, 2);
                        offset = Math.Max(0, i - 2);
                        break;
                    }
                }

                result = l.Count;
            } while (result < prevLen);
            return result;
        }
    }

}
