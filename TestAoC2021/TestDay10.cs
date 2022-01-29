using AoC2021Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace TestAoC2021
{
    [TestClass]
    public class TestDay10
    {
        [TestMethod]
        [DataRow("day10.test01.txt", 26397)]
        [DataRow("day10.txt", 311895)]
        [DataRow("day10b.txt", 323691)]
        public void Test1(string file, int expected)
        {
            var input = File.ReadLines(file);
            var result = new Day10().Part1(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("day10.test01.txt", 288957)]
        [DataRow("day10.txt", 2904180541)]
        [DataRow("day10b.txt", 2858785164)]
        public void Test2(string file, long expected)
        {
            var input = File.ReadLines(file);
            var result = new Day10().Part2(input);
            Assert.AreEqual(expected, result);
        }
    }
}
