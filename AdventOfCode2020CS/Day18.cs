using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020CS
{
    public class Day18
    {
        internal enum Op
        {
            Add,
            Multiply,
        }

        public static long Part1(string input)
        {
            var result = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Sum(x => Calc(x));

            return result;
        }

        public static long Calc(string input)
        {
            long result = 0;
            int offset = 0;
            Op op = Op.Add;

            if (input == null || !input.Any())
            {
                return result;
            }

            while (offset < input.Length)
            {
                switch (input[offset])
                {
                    case '(':
                        {
                            var end = FindMatchingParenthesis(input, offset);
                            offset++;
                            var str = input[offset..end];
                            var n = Calc(str);
                            offset = end + 1;
                            result = ApplyOp(op, result, n);
                            break;
                        }
                    case ' ':
                        {
                            offset++;
                            break;
                        }
                    case '+':
                        {
                            op = Op.Add;
                            offset++;
                            break;
                        }
                    case '*':
                        {
                            op = Op.Multiply;
                            offset++;
                            break;
                        }
                    default:
                        if (char.IsDigit(input[offset]))
                        {
                            var end = FindNumber(input, offset);
                            var str = input[offset..end];
                            var n = long.Parse(str);
                            offset = end + 1;
                            result = ApplyOp(op, result, n);
                        }
                        break;
                }
            }
            return result;
        }

        private static long ApplyOp(Op op, long a, long b)
        {
            switch (op)
            {
                case Op.Add:
                    return a + b;
                case Op.Multiply:
                    return a * b;
                default:
                    throw new InvalidOperationException(op.ToString());
            }
        }

        internal static int FindNumber(string str, int start)
        {
            for (int i = start + 1; i < str.Length; i++)
            {
                if (false == char.IsDigit(str[i]))
                {
                    return i;
                }
            }

            return str.Length;
        }

        internal static int FindMatchingParenthesis(string str, int start)
        {
            int count = 1;
            int i = start;
            do
            {
                i++;
                if (i == str.Length)
                {
                    throw new FormatException();
                }
                else if (str[i] == '(')
                {
                    count++;
                }
                else if (str[i] == ')')
                {
                    count--;
                }
            } while (count > 0);

            return i;
        }

    }

}
