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

        static IEnumerable<Code[]> Swap(IEnumerable<Code> code)
        {
            var program = code.ToArray();
            for (int i = 0; i < program.Length; i++)
            {
                if (program[i].Operation == Operation.jmp)
                {
                    var clone = (Code[])program.Clone();
                    clone[i].Operation = Operation.nop;
                    yield return clone;
                }
                else if (program[i].Operation == Operation.nop)
                {
                    var clone = (Code[])program.Clone();
                    clone[i].Operation = Operation.jmp;
                    yield return clone;
                }
            }
        }

        class CPU
        {
            Dictionary<Operation, Func<int, int>> Operators;
            public int Acc { get; set; }
            public int Ip { get; set; }
            
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
                Ip +=  Operators[code.Operation].Invoke(code.Value);
                return Ip;
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

        public static int Part1(string input)
        {
            var code = ParseProgram(input).ToArray();
            var cpu = new CPU();
            
            var consumed = new HashSet<int>();
            while (consumed.Add(cpu.Ip))
            {
                cpu.Execute(code[cpu.Ip]);
            }
            return cpu.Acc;
        }

        public static int Part2(string input)
        {
            var program = ParseProgram(input);
            foreach (var code in Swap(program))
            {
                var cpu = new CPU();
                var consumed = new HashSet<int>();
                while (consumed.Add(cpu.Ip) && cpu.Ip < code.Length)
                {
                    cpu.Execute(code[cpu.Ip]);
                    if (cpu.Ip == code.Length)
                    {
                        return cpu.Acc;
                    }
                }
            }
            return -1;
        }

    }

}
