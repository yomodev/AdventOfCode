using AoC2021Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace TestAoC2021
{
    [TestClass]
    public class TestDay09
    {
        [TestMethod]
        [DataRow(@"data\day09.test01.txt", 15)]
        [DataRow(@"data\day09.txt", 550)]
        [DataRow(@"data\day09b.txt", 480)]
        public void Test1(string file, int expected)
        {
            var input = File.ReadLines(file);
            var result = new Day09().Part1(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(@"data\day09.test01.txt", 1134)]
        [DataRow(@"data\day09.txt", 1100682)]
        [DataRow(@"data\day09b.txt", 1045660)]
        public void Test2(string file, long expected)
        {
            var input = File.ReadLines(file);
            var result = new Day09().Part2(input);
            Assert.AreEqual(expected, result);
        }
    }
}
