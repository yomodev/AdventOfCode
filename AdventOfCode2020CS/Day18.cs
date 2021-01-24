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
                .Sum(x => Calc1(x));

            return result;
        }

        public static long Part2(string input)
        {
            var result = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Sum(x => Calc2(x));

            return result;
        }

        public static long Calc1(string input)
        {
            long result = 0;
            int offset = 0;
            Op op = Op.Add;

            if (input == null || !input.Any())
            {
                throw new ArgumentException();
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
                            var n = Calc1(str);
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

        public static long Calc2(string input)
        {
            var tree = BuildTree(input);
            long result = tree.Evaluate();
            return result;
        }

        interface INode { }

        struct Number : INode
        {
            public long Value { get; set; }
            public Number(long value)
            {
                Value = value;
            }
        }

        class Node : INode
        {
            public Op Op { get; set; }
            public INode LValue { get; set; }
            public INode RValue { get; set; }

            public Node(Op op = Op.Add, INode left = null, INode right = null)
            {
                Op = op;
                LValue = left;
                RValue = right;
            }

            public INode Add(INode value)
            {
                if (LValue == null)
                {
                    LValue = value;
                }
                else
                {
                    RValue = value;
                }
                return value;
            }

            public Node Insert(Node value)
            {
                RValue = LValue;
                LValue = value;
                return value;
            }

            public Node AddOp(Op op)
            {
                if (RValue == null)
                {
                    Op = op;
                    return this;
                }

                var node = new Node(op, RValue);
                RValue = node;
                return node;
            }

            public long Evaluate()
            {
                if (RValue == null && LValue is Number)
                {
                    return ((Number)LValue).Value;
                }
                else if (RValue == null && LValue is Node)
                {
                    return (RValue as Node).Evaluate();
                }

                if (LValue is Number lna && RValue is Number rna && Op == Op.Add)
                {
                    return lna.Value + rna.Value;
                }

                if (LValue is Number lnm && RValue is Number rnm && Op == Op.Multiply)
                {
                    return lnm.Value * rnm.Value;
                }

                if (LValue is Node && RValue is Node)
                {
                    var Lnode = LValue as Node;
                    var Rnode = RValue as Node;
                    if (Lnode.Op == Op.Add)
                    {
                        return Lnode.Evaluate() + 0;
                    }
                }

                return 0;
            }
        }

        private static Node BuildTree(string input)
        {
            if (input == null || !input.Any())
            {
                throw new ArgumentException();
            }

            var root = new Node();
            var node = root;

            int offset = 0;
            while (offset < input.Length)
            {
                switch (input[offset])
                {
                    case '(':
                        {
                            var end = FindMatchingParenthesis(input, offset);
                            offset++;
                            var str = input[offset..end];
                            node = node.Insert(BuildTree(str));
                            offset = end + 1;
                            break;
                        }
                    case ' ':
                        {
                            offset++;
                            break;
                        }
                    case '+':
                        {
                            node = node.AddOp(Op.Add);
                            offset++;
                            break;
                        }
                    case '*':
                        {
                            node = node.AddOp(Op.Multiply);
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
                            node.Add(new Number(n));
                        }
                        break;
                }
            }

            return root;
        }

    }

}
