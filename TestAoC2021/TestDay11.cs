using AoC2021Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace TestAoC2021
{
    [TestClass]
    public class TestDay11
    {
        [TestMethod]
        [DataRow(@"data\day11.test01.txt", 1656)]
        [DataRow(@"data\day11.txt", 1683)]
        [DataRow(@"data\day11b.txt", 1594)]
        public void Test1(string file, int expected)
        {
            var input = File.ReadLines(file);
            var result = new Day11().Part1(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(@"data\day11.test01.txt", 195)]
        [DataRow(@"data\day11.txt", 788)]
        [DataRow(@"data\day11b.txt", 437)]
        public void Test2(string file, long expected)
        {
            var input = File.ReadLines(file);
            var result = new Day11().Part2(input);
            Assert.AreEqual(expected, result);
        }
    }
}
