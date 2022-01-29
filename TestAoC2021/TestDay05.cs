using AoC2021Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestAoC2021
{
    [TestClass]
    public class TestDay05
    {
        [TestMethod]
        [DataRow("day05.test01.txt", 5)]
        [DataRow("day05.txt", 7318)]
        [DataRow("day05b.txt", 6225)]
        public void Test1(string file, int expected)
        {
            var data = File.ReadAllLines(file);
            var result = new Day05().Part1(data);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("day05.test01.txt", 12)]
        [DataRow("day05.txt", 19939)]
        [DataRow("day05b.txt", 22116)]
        public void Test2(string file, int expected)
        {
            var data = File.ReadAllLines(file);
            var result = new Day05().Part2(data);
            Assert.AreEqual(expected, result);
        }
    }
}
