using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021Lib
{
    public class Board
    {
        private List<int?> numbers = new();
        public bool Binged { get; private set; } = false;

        public Board(string data)
        {
            numbers = data
                .Replace(Environment.NewLine, " ")
                .Split(' ')
                .Where(x => x.Length > 0)
                .Select(Int32.Parse)
                .Cast<int?>()
                .ToList();
        }

        public void Mark(int n)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == n)
                {
                    numbers[i] = null;
                    return;
                }
            }
        }

        public bool Test(int mod = 5)
        {
            var bingo = numbers
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / mod)
                .Select(x => x.Select(v => v.Value).All(x => x == null))
                .ToList()
                .Any(x => x);

            if (!bingo)
            {
                bingo = Enumerable.Range(0, mod)
                   .Select(c => numbers
                       .Where((_, i) => (i + c) % mod == 0)
                       .All(x => x == null))
                   .Any(x => x);
            }

            Binged = Binged || bingo;
            return bingo;
        }

        public int Sum()
        {
            return numbers.Where(x => x != null).Cast<int>().Sum();
        }

    }

    public class Day04
    {
        public int Part1(string data)
        {
            var input = data.Split(Environment.NewLine + Environment.NewLine);
            var extract = input.First().Split(',').Select(Int32.Parse);
            var boards = input.Skip(1).Select(x => new Board(x)).ToList();

            foreach (var n in extract)
            {
                foreach (var board in boards)
                {
                    board.Mark(n);
                    if (board.Test())
                    {
                        return board.Sum() * n;
                    }
                }
            }

            throw new Exception("no win");
        }

        public int Part2(string data)
        {
            var input = data.Split(Environment.NewLine + Environment.NewLine);
            var extract = input.First().Split(',').Select(Int32.Parse);
            var boards = input.Skip(1).Select(x => new Board(x)).ToList();

            foreach (var n in extract)
            {
                foreach (var board in boards)
                {
                    board.Mark(n);
                    if (board.Test())
                    {
                        if (boards.All(b => b.Binged))
                        {
                            return board.Sum() * n;
                        }

                    }
                }
            }

            throw new Exception("no win");
        }
    }
}
