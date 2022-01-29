using AoC2021Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace TestAoC2021
{
    [TestClass]
    public class TestDay14
    {
        [TestMethod]
        [DataRow("day14.test01.txt", 1588)]
        [DataRow("day14.txt", 2851)]
        [DataRow("day14b.txt", 2851)]
        public void Test1(string file, int expected)
        {
            var input = File.ReadAllText(file);
            var result = new Day14().Part1(input, 10);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("day14.test01.txt", 2188189693529)]
        [DataRow("day14.txt", 0)]
        [DataRow("day14b.txt", 0)]
        public void Test2(string file, long expected)
        {
            var input = File.ReadAllText(file);
            var result = new Day14().Part2(input, 20);
            Assert.AreEqual(expected, result);
        }
    }
}
