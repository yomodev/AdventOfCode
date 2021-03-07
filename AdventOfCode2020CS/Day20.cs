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
            var tiles = sections.Select(x => new Tile(x));

            var borderDict = tiles.SelectMany(x => x.Borders).Distinct().ToDictionary(k => k, v => new List<int>());
            tiles.ForEach(t => t.Borders.ForEach(b => borderDict[b].Add(t.Id)));

            var result = tiles.Where(x => x.Borders.Sum(b => borderDict[b].Count) == 6).Multiply(x=>x.Id);
            return result;
        }

    }

    internal class Tile
    {
        public int Id { get; set; }
        public string[] Data { get; private set; }
        public List<string> Borders { get; private set; } = new List<string>();

        public Tile(string str)
        {
            var lines = str.Split(Environment.NewLine);
            Id = int.Parse(new string(lines.First().Where(x => char.IsDigit(x)).ToArray()));
            Data = lines.Skip(1).ToArray();
            Assert.AreEqual(100, string.Join(null, Data).Length);

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
}
