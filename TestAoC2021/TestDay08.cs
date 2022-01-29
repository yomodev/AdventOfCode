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
        [DataRow("day08.test01.txt", 26)]
        [DataRow("day08.txt", 421)]
        public void Test1(string file, int expected)
        {
            var input = File.ReadLines(file);
            var result = new Day08().Part1(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("day08.test01.txt", 61229)]
        [DataRow("day08.txt", 986163)]
        public void Test2(string file, long expected)
        {
            var input = File.ReadLines(file);
            var result = new Day08().Part2(input);
            Assert.AreEqual(expected, result);
        }
    }
}
