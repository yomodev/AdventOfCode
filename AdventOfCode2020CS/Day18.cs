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
                .Sum(x => BuildTree(x).Evaluate());

            return result;
        }

        public static long Part2(string input)
        {
            var result = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Sum(x => BuildTree(x, new List<Op> { Op.Add, Op.Multiply }).Evaluate());

            return result;
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
            public Node Parent { get; set; }
            public Node Root { get => Parent?.Root ?? this; }

            public Node(Node parent = null, Op op = Op.Add, INode left = null, INode right = null)
            {
                Parent = parent;
                Op = op;
                LValue = left;
                RValue = right;
            }

            public Node Add(INode value)
            {
                if (LValue == null)
                {
                    LValue = value;
                    return this;
                }
                else if (RValue == null)
                {
                    RValue = value;
                    return this;
                }

                var node = new Node(this, Op, LValue, RValue);
                RValue = node;
                LValue = value;
                return node;
            }

            public Node Add(Op value, List<Op> opSort = null)
            {
                if (RValue == null)
                {
                    Op = value;
                    return this;
                }

                if (opSort == null || opSort.IndexOf(value) > opSort.IndexOf(Op))
                {
                    var top = new Node(null, value, Root);
                    (top.LValue as Node).Parent = top;
                    return top;
                }

                var node = new Node(this, value, RValue);
                RValue = node;
                return node;
            }

            public long Evaluate()
            {
                return Op switch
                {
                    Op.Add => LValue.Evaluate() + RValue?.Evaluate() ?? 0,
                    Op.Multiply => LValue.Evaluate() * RValue?.Evaluate() ?? 1,
                    _ => throw new InvalidOperationException(),
                };
            }

            public override string ToString()
            {
                var sb = new StringBuilder();
                sb.Append(LValue is Node ? $"({LValue})" : $"{LValue}");

                if (RValue != null)
                {
                    sb.Append($" {Op.Description()} ");
                    sb.Append(RValue is Node && (RValue as Node).RValue != null ? $"({RValue})" : $"{RValue}");
                }

                return sb.ToString();
            }
        }

        private static Node BuildTree(string input, List<Op> opSort = null)
        {
            if (input == null || !input.Any())
            {
                throw new ArgumentException("invalid", nameof(input));
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
                            var sub = BuildTree(str, opSort);
                            node = node.Add(sub);
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
                            node = node.Add(Op.Add, opSort);
                            offset++;
                            break;
                        }
                    case '*':
                        {
                            node = node.Add(Op.Multiply, opSort);
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
                            node = node.Add(new Number(n));
                        }
                        break;
                }
            }

            return node.Root;
        }
    }



    public static class EnumEx
    {
        public static string Description<T>(this T enumerationValue) where T : struct
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", nameof(enumerationValue));
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
