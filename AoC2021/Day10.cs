using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021Lib
{
    public class Day10
    {
        enum Parenthesis
        {
            None = 0,
            Round = 3,
            Bracket = 57,
            Curly = 1197,
            Angle = 25137,
        }

        public int Part1(IEnumerable<string> data)
        {
            var result = data.Sum(Score1);
            return result;
        }

        private int Score1(string line)
        {
            return TryParse(line, out Stack<Parenthesis> stack) ? 0 : (int)stack.Peek();
        }

        public long Part2(IEnumerable<string> data)
        {
            var scores = data.Select(x =>
            {
                var complete = TryParse(x, out Stack<Parenthesis> stack);
                return new { complete, stack };
            }).Where(x => x.complete)
            .Select(x => Score2(x.stack))
            .OrderBy(x => x)
            .ToList();

            var result = scores[scores.Count / 2];
            return result;
        }

        private long Score2(Stack<Parenthesis> stack)
        {
            return stack
                .Where(x => x != Parenthesis.None)
                .Aggregate(0L, (acc, p) =>
                 acc * 5 + Array.IndexOf(Enum.GetValues<Parenthesis>(), p));
        }

        private bool TryParse(string line, out Stack<Parenthesis> stack)
        {
            stack = new Stack<Parenthesis>();
            stack.Push(Parenthesis.None);
            foreach (var c in line)
            {
                switch (c)
                {
                    case '(': stack.Push(Parenthesis.Round); break;
                    case '[': stack.Push(Parenthesis.Bracket); break;
                    case '{': stack.Push(Parenthesis.Curly); break;
                    case '<': stack.Push(Parenthesis.Angle); break;
                    case ')' when stack.Peek() == Parenthesis.Round:
                    case ']' when stack.Peek() == Parenthesis.Bracket:
                    case '}' when stack.Peek() == Parenthesis.Curly:
                    case '>' when stack.Peek() == Parenthesis.Angle:
                        stack.Pop(); break;
                    case ')': stack.Push(Parenthesis.Round); return false;
                    case ']': stack.Push(Parenthesis.Bracket); return false;
                    case '}': stack.Push(Parenthesis.Curly); return false;
                    case '>': stack.Push(Parenthesis.Angle); return false;
                    default:
                        break;
                }
            }
            return true;
        }
    }
}
