using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventCode2018
{
    class Day07
    {
        
        public static string Test1(string file)
        {
            var steps = new List<Tuple<char, char>>();

            foreach (var item in File.ReadLines(file))
            {
                string[] split = item.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                steps.Add(new Tuple<char, char>(split[1][0], split[7][0]));
            }
            
            List<char> letters = steps.Select(x => x.Item1)
                .Union(steps.Select(x => x.Item2)).OrderBy(x => x).ToList();

            var result = string.Empty;

            while (letters.Any())
            {
                // first letter having no more dependencies
                char c = letters.Where(le => !steps.Any(s => s.Item2 == le)).First();

                result += c;

                letters.Remove(c);
                steps.RemoveAll(s => s.Item1 == c);
            }

            Console.WriteLine(result);
            return result;
        }


    }
}
