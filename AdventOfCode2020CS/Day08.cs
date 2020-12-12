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

            var lookup = new string[] { "jmp", "nop" };
            int? swapIndex = -1;

            while (
                (swapIndex = code.Skip(swapIndex.Value + 1)
                    .Where(x => lookup.Contains(x.operation))
                    .Select(x => x.line).FirstOrDefault()) != null)
            {

                acc = 0;
                int ip = 0;
                var consumed = new HashSet<int>();
                while (!consumed.Contains(ip) || ip >= code.Length)
                {
                    consumed.Add(ip);
                    var op = code[ip].operation;
                    if (ip == swapIndex)
                    {
                        op = op == "jmp" ? "nop" : "jmp";
                    }
                    var arg = code[ip].argument;
                    var inc = processor[op].Invoke(arg);
                    if (ip == code.Length - 1)
                    {
                        return acc;
                    }

                    ip += inc;
                }
            }

            return acc;
        }

    }

}
