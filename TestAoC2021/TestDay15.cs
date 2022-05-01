using AoC2021Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestAoC2021
{
    [TestClass]
    public class TestDay15
    {
        [TestMethod]
        [DataRow(@"data\day15.test01.txt", 40)]
        [DataRow(@"data\day15b.txt", 0)]
        public void Test1(string file, int expected)
        {
            var input = File.ReadAllText(file);
            var result = new Day15().Part1(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(@"data\day15.test01.txt", 0)]
        [DataRow(@"data\day15b.txt", 0)]
        public void Test2(string file, long expected)
        {
            var input = File.ReadAllText(file);
            var result = new Day15().Part2(input);
            Assert.AreEqual(expected, result);
        }
    }
}
