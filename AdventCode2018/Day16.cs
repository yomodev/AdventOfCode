using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventCode2018
{
    class Day16
    {
        public static void Test2()
        {
            List<Move> moves = parse("s1, x3/4, pe/b");
            string result = process(moves, "abcde", 0);
            Console.WriteLine("{0} {1}", result, result == "baedc" ? "OK" : "ERROR!");
            //result = process(moves, "abcde", (long)1e9);
            //Console.WriteLine("result {0}", result);

            string input = File.ReadAllText("day16.txt");
            moves = parse(input);
            result = process(moves, "abcdefghijklmnop", 0);
            Console.WriteLine("{0} {1}", result, result == "ebjpfdgmihonackl" ? "OK" : "ERROR!");

            result = process(moves, "abcdefghijklmnop", (long)1e9);
            Console.WriteLine("result {0}", result);
            
            Console.ReadKey();
        }



        public enum MoveType
        {
            Spin,
            Exchange,
            Partner
        }

        public struct Move
        {
            public MoveType mt;
            public object a, b;

            public Move(MoveType mt = MoveType.Spin, object a = null, object b = null)
            {
                this.mt = mt;
                this.a = a;
                this.b = b;
            }
        }


        static List<Move> parse(string input)
        {
            //https://www.myregextester.com/index.php
            List<Move> moves = new List<Move>();
            Regex re = new Regex(@"(.)(\w+)/?(\w+)?[, ]*", RegexOptions.Singleline);
            MatchCollection mc = re.Matches(input);
            for (int i = 0; i < mc.Count; i++)
            {
                Move move = new Move();
                Match match = mc[i];
                switch (match.Groups[1].Value[0])
                {
                    case 's':
                        move = new Move(MoveType.Spin, int.Parse(match.Groups[2].Value));
                        break;
                    case 'x':
                        move = new Move(MoveType.Exchange, int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value));
                        break;
                    case 'p':
                        move = new Move(MoveType.Partner, match.Groups[2].Value[0], match.Groups[3].Value[0]);
                        break;
                }

                moves.Add(move);
            }

            return moves;
        }


        static string process(List<Move> moves, string input, long cycles = 0)
        {
            string match = string.Empty;
            //Dictionary<string, long> dict = new Dictionary<string, long>();
            long i = 0;
            while (i < cycles)
            {
                foreach (Move move in moves)
                {
                    if (move.mt == MoveType.Spin)
                    {
                        int s = input.Length - (int)move.a;
                        input = input.Substring(s) + input.Substring(0, s);
                    }
                    else if (move.mt == MoveType.Exchange)
                    {
                        char[] a = input.ToCharArray();
                        char temp = a[(int)move.a];
                        a[(int)move.a] = a[(int)move.b];
                        a[(int)move.b] = temp;
                        input = string.Join("", a);
                    }
                    else
                    {
                        input = input.Replace((char)move.b, 'z')
                            .Replace((char)move.a, (char)move.b)
                            .Replace('z', (char)move.a);
                    }
                }
                
                if (match == input)
                {
                    Console.WriteLine("found {0} {1}", input, i);
                    i = cycles - cycles % i;
                }
                else if (match == string.Empty)
                {
                    match = input;
                    if (cycles == 0)
                    {
                        break;
                    }
                }
                /*
                if (i % 1e6 == 0)
                {
                    Console.WriteLine(i);
                }*/
                i++;
            }
            return input;
        }


    }
}
