using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021Libaaaaaaaaaaaaaaaaaa
{
    public class Board
    {
        private readonly List<List<int?>> rows = new();
        public bool Binged { get; private set; } = false;

        public Board(string data)
        {
            rows = data.Split(Environment.NewLine)
                .Select(line => line
                    .Split(' ')
                    .Where(x => x.Length > 0)
                    .Select(Int32.Parse)
                    .Cast<int?>()
                    .ToList())
                .ToList();
        }

        public void Mark(int n)
        {
            for (int y = 0; y < rows.Count; y++)
            {
                var row = rows[y];
                for (int x = 0; x < row.Count; x++)
                {
                    if (row[x] == n)
                    {
                        row[x] = null;
                    }
                }
            }
        }

        public bool Test(out int sum)
        {
            sum = 0;
            var bingo = rows.Any(row => row.All(x => x == null));
            if (!bingo)
            {
                var list = rows.SelectMany(x => x).ToList();
                var mod = rows.First().Count;
                for (int c = 0; c < mod; c++)
                {
                    var column = list.Where((_, i) =>
                    {
                        return (i + c) % mod == 0;
                    });

                    if (column.All(x => x == null))
                    {
                        bingo = true;
                        break;
                    }
                }
            }

            if (bingo)
            {
                sum = rows.SelectMany(row => row).Where(x => x != null).Cast<int>().Sum();
                Binged = true;
                return true;
            }

            return false;
        }

    }

    public class Day04old
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
                    if (board.Test(out int sum))
                    {
                        return sum * n;
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
                    if (board.Test(out int sum))
                    {
                        if (boards.All(b => b.Binged))
                        {
                            return sum * n;
                        }

                    }
                }
            }

            throw new Exception("no win");
        }
    }
}
