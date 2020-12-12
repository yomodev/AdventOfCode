using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020CS
{
    public class Day08
    {

        public static int Test1(string input)
        {
            var code = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Split(' '))
                .Select(x => new { operation = x[0], argument = int.Parse(x[1]) }).ToArray();

            int acc = 0;
            var processor = new Dictionary<string, Func<int, int>>
            {
                { "acc", (arg) => { acc+= arg; return 1; } },
                { "jmp", (arg) => arg },
                { "nop", (arg) => 1 }
            };

            int ip = 0;
            var consumed = new HashSet<int>();
            while (!consumed.Contains(ip))
            {
                consumed.Add(ip);
                var op = code[ip].operation;
                var arg = code[ip].argument;
                ip += processor[op].Invoke(arg);
            }

            return acc;
        }

        public static int Test2(string input)
        {
            var code = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Split(' '))
                .Select((x, i) => new { line = i, operation = x[0], argument = int.Parse(x[1]) }).ToArray();

            int acc = 0;
            var processor = new Dictionary<string, Func<int, int>>
            {
                { "acc", (arg) => { acc+= arg; return 1; } },
                { "jmp", (arg) => arg },
                { "nop", (arg) => 1 }
            };

            var consumed = new HashSet<int>();
            var lookup = new string[] { "jmp", "nop" };
            var swapIndex = -1;
            var swapCount = code.Where(x => lookup.Contains(x.operation)).Count();
            while (swapCount-- >= 0)
            {
                swapIndex = code.Skip(swapIndex + 1)
                    .Where(x => lookup.Contains(x.operation))
                    .Select(x => x.line).First();

                acc = 0;
                int ip = 0;
                consumed.Clear();
                while (!consumed.Contains(ip))
                {
                    consumed.Add(ip);
                    var op = code[ip].operation;
                    if (ip == swapIndex)
                    {
                        op = op == "jmp" ? "nop" : "jmp";
                    }
                    var arg = code[ip].argument;
                    if (ip == code.Length -1)
                    {
                        Console.WriteLine("ip {0}, acc {0}", ip, acc);
                        processor[op].Invoke(arg);
                        return acc;
                    }

                    ip += processor[op].Invoke(arg);
                    if (ip >= code.Length)
                    {
                        break;
                    }
                }
            }

            return acc;
        }

    }

}
