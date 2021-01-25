using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AdventOfCode2020CS
{
    public class Day18
    {
        internal enum Op
        {
            [Description("+")]
            Add,

            [Description("*")]
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

        interface INode
        {
            long Evaluate();
        }

        struct Number : INode
        {
            public long Value { get; set; }
            public Number(long value)
            {
                Value = value;
            }

            public override string ToString()
            {
                return Value.ToString();
            }

            public long Evaluate()
            {
                return Value;
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
                if (RValue == null)
                {
                    RValue = LValue;
                    LValue = value;
                    return this;
                }

                var node = new Node(Op, LValue, RValue);
                RValue = node;
                LValue = value;
                return node;
            }

            public Node AddOp(Op value)
            {
                if (RValue == null)
                {
                    Op = value;
                    return this;
                }

                var node = new Node(Op, LValue, RValue);
                LValue = node;
                Op = value;
                RValue = null;
                return this;
            }

            public long Evaluate()
            {
                switch (Op)
                {
                    case Op.Add:
                        return LValue.Evaluate() + RValue?.Evaluate() ?? 0;
                    case Op.Multiply:
                        return LValue.Evaluate() * RValue?.Evaluate() ?? 1;
                    default:
                        throw new InvalidOperationException();
                }
            }

            public override string ToString()
            {
                return $"{LValue}" + (RValue != null ? $" {Op.Description()} {RValue}" : string.Empty);
            }
        }

        private static Node BuildTree(string input)
        {
            if (input == null || !input.Any())
            {
                throw new ArgumentException();
            }

            var node = new Node();

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

            return node;
        }
    }



    public static class EnumEx
    {
        public static string Description<T>(this T enumerationValue) where T : struct
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }

            //Tries to find a DescriptionAttribute for a potential friendly name for the enum
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    //Pull out the description value
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            //If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString();
        }

    }

}
