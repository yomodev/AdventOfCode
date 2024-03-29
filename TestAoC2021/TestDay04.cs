using AoC2021Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestAoC2021
{
    [TestClass]
    public class TestDay04
    {
        [TestMethod]
        [DataRow(@"data\day04.test01.txt", 4512)]
        [DataRow(@"data\day04.txt", 51776)]
        [DataRow(@"data\day04b.txt", 8442)]
        public void Test1(string file, int expected)
        {
            var data = File.ReadAllText(file);
            var result = new Day04().Part1(data);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(@"data\day04.test01.txt", 1924)]
        [DataRow(@"data\day04.txt", 16830)]
        [DataRow(@"data\day04b.txt", 4590)]
        [DataRow(@"data\day04.stefy.txt", 34726)]
        public void Test2(string file, int expected)
        {
            var data = File.ReadAllText(file);
            var result = new Day04().Part2(data);
            Assert.AreEqual(expected, result);
        }
    }
}
