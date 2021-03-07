using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2020CS
{
    public class Day20
    {

        public static long Part1(string input)
        {
            var sections = input.Split(Environment.NewLine + Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var tiles = sections.Select(x => new SquareTile(x));

            var borderDict = tiles.SelectMany(x => x.Borders).Distinct().ToDictionary(k => k, v => new List<int>());
            tiles.ForEach(t => t.Borders.ForEach(b => borderDict[b].Add(t.Id)));

            var result = tiles.Where(x => x.Borders.Sum(b => borderDict[b].Count) == 6).Multiply(x => x.Id);
            return result;
        }

        public static long Part2(string input, string monster)
        {
            return 0;
        }
    }

    internal class SquareTile : Tile
    {
        public int Id { get; set; }
        public List<string> Borders { get; private set; } = new List<string>();

        public SquareTile(string str)
        {
            var lines = str.Split(Environment.NewLine);
            Id = int.Parse(new string(lines.First().Where(x => char.IsDigit(x)).ToArray()));
            Data = lines.Skip(1).ToArray();
            Assert.AreEqual(100, Data.Sum(x => x.Length));

            Borders.Add(OneBorder(Data.First()));
            Borders.Add(OneBorder(Data.Last()));
            Borders.Add(OneBorder(new String(Data.Select(x => x.First()).ToArray())));
            Borders.Add(OneBorder(new String(Data.Select(x => x.Last()).ToArray())));
        }

        private string OneBorder(string v)
        {
            var rev = new string(v.Reverse().ToArray());
            return string.Compare(v, rev) < 0 ? v : rev;
        }

    }

    internal class Tile
    {
        public string[] Data { get; protected set; }

        public Tile() { }

        public Tile(string str)
        {

        }

        public Tile Rotate()
        {
            throw new NotImplementedException();
        }

        public Tile Flip()
        {
            throw new NotImplementedException();
        }

        public Tile RemoveBorder()
        {
            throw new NotImplementedException();
        }

    }

    internal class TileMap : Tile
    {
        void AddAt(Tile tile, int x, int y)
        { }

        Tile Rasterize()
        {
            throw new NotImplementedException();

        }

        int Scan()
        {
            throw new NotImplementedException();

        }
    }

}
