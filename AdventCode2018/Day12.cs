using System;
using System.Collections.Generic;
using System.IO;

namespace AdventCode2018
{
    public class Day12
    {
        public static long Test1(string file, long gen)
        {
            Dictionary<string, char> dict = new Dictionary<string, char>();
            string state = string.Empty;

            foreach (string line in File.ReadLines(file))
            {
                string[] split = line.Split(new char[] { '=', '>', ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (state == string.Empty)
                {
                    state = split[2];
                }
                else if (!string.IsNullOrWhiteSpace(line))
                {
                    dict[split[0]] = split[1][0];
                }
            }

            long result = 0;
            long offset = 0;
            string nextState = string.Empty;
            for (int j = 0; j < gen; j++)
            {
                int pos = state.IndexOf('#');
                if (pos > -1 && pos < 4)
                {
                    state = new string('.', 4 - pos) + state;
                    offset -= 2 - pos;
                }
                state = state.TrimEnd(new char[] { '.' }) + "....";

                /*if (state.Replace("#....", "").Replace(".", "").Length == 0)
                {
                    break;
                }*/

                for (int i = 0; i < state.Length - 4; i++)
                {
                    string slice = state.Substring(i, 5);
                    //Console.WriteLine(slice);
                    if (!dict.ContainsKey(slice))
                    {
                        //Console.WriteLine("slice not found {0}", slice);
                        nextState += ".";
                    }
                    else
                    {
                        nextState += dict[slice];
                    }
                }

                result = Score(state, offset);

                Console.WriteLine("{0,02} {1} {2} {3}", j + 1, nextState, offset, result);
                state = nextState;

                nextState = string.Empty;
                //Console.WriteLine("{0,02} {1}", j + 1, state);

            }

            Console.WriteLine("result {0}", result);
            return result;
        }


        public static long Score(string pattern, long offset)
        {
            long result = 0;
            for (int i = 0; i < pattern.Length; i++)
            {
                if (pattern[i] == '#')
                {
                    result += i + offset;
                }
            }

            return result;
        }


        public static long Test2()
        {
            long offset = 50000000000 - 200 + 125;
            string pattern = "...#.......#...........#.......#.......#.....#......#......#.......#......#.....#.......#.......#..............#.......#.....#.....#......#.....#......#......#.......#.....#.";
            long result = Score(pattern, offset);

            Console.WriteLine("result {0}", result);
            return result;
        }

    }

}
