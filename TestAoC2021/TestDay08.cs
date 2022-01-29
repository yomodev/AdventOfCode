using AoC2021Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace TestAoC2021
{
    [TestClass]
    public class TestDay08
    {
        [TestMethod]
        [DataRow(@"data\day08.test01.txt", 26)]
        [DataRow(@"data\day08.txt", 421)]
        [DataRow(@"data\day08b.txt", 284)]
        public void Test1(string file, int expected)
        {
            var input = File.ReadLines(file);
            var result = new Day08().Part1(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(@"data\day08.test01.txt", 61229)]
        [DataRow(@"data\day08.txt", 986163)]
        [DataRow(@"data\day08b.txt", 973499)]
        public void Test2(string file, long expected)
        {
            var input = File.ReadLines(file);
            var result = new Day08().Part2(input);
            Assert.AreEqual(expected, result);
        }
    }
}
