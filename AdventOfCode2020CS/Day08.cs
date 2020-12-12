using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020CS
{
    public class Day08
    {
        enum Operation
        {
            acc,
            jmp,
            nop,
        }

        struct Code
        {
            public Operation Operation { get; set; }
            public int Value { get; set; }
            public int Line { get; set; }
        }

        class CPU
        {
            Dictionary<Operation, Func<int, int>> Operators;
            public int Acc { get; set; }
            
            public CPU()
            {
                Operators = new()
                {
                    { Operation.acc, (arg) => { Acc+= arg; return 1; } },
                    { Operation.jmp, (arg) => arg },
                    { Operation.nop, (arg) => 1 }
                };
            }

            public int Execute(Code code)
            {
                return Operators[code.Operation].Invoke(code.Value);
            }
        }

        private static IEnumerable<Code> ParseProgram(string input)
        {
            var code = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Split(' '))
                .Select((x,i) => new Code 
                { 
                    Operation = Enum.Parse<Operation>(x[0]), 
                    Value = int.Parse(x[1]) ,
                    Line = i
                });
            return code;
        }


        public static int Test1(string input)
        {
            var code = ParseProgram(input).ToArray();
            var cpu = new CPU();
            
            int ip = 0;
            var consumed = new HashSet<int>();
            while (!consumed.Contains(ip))
            {
                consumed.Add(ip);
                ip += cpu.Execute(code[ip]);
            }

            return cpu.Acc;
        }

        public static int Test2(string input)
        {
            var code = ParseProgram(input).ToArray();

            var lookup = new string[] { "jmp", "nop" };

            int? swapIndex = -1;
            while (
                (swapIndex = code.Skip(swapIndex.Value + 1)
                    .Where(x => lookup.Contains(x.Operation.ToString()))
                    .Select(x => x.Line).FirstOrDefault()) != null)
            {
                var cpu = new CPU();
                int ip = 0;
                var consumed = new HashSet<int>();
                while (!consumed.Contains(ip) || ip >= code.Length)
                {
                    consumed.Add(ip);
                    var op = code[ip].Operation;
                    if (ip == swapIndex)
                    {
                        op = op == Operation.jmp ? Operation.nop : Operation.jmp;
                    }
                    var inc = cpu.Execute(new Code { Value = code[ip].Value, Operation = op});
                    if (ip == code.Length - 1)
                    {
                        return cpu.Acc;
                    }

                    ip += inc;
                }
            }

            return 0;
        }

    }

}
