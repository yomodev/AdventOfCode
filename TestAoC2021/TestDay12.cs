using AoC2021Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace TestAoC2021
{
    [TestClass]
    public class TestDay12
    {
        [TestMethod]
        [DataRow("day12.test01.txt", 10)]
        [DataRow("day12.test02.txt", 19)]
        [DataRow("day12.test03.txt", 226)]
        [DataRow("day12.txt", 4775)]
        [DataRow("day12b.txt", 3713)]
        public void Test1(string file, int expected)
        {
            var input = File.ReadLines(file);
            var result = new Day12().Part1(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("day12.test01.txt", 36)]
        [DataRow("day12.test02.txt", 103)]
        [DataRow("day12.test03.txt", 3509)]
        [DataRow("day12.txt", 152480)]
        [DataRow("day12b.txt", 91292)]
        public void Test2(string file, long expected)
        {
            var input = File.ReadLines(file);
            var result = new Day12().Part2(input);
            Assert.AreEqual(expected, result);
        }
    }
}
