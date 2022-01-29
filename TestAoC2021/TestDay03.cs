using AoC2021Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace TestAoC2021
{
    [TestClass]
    public class TestDay03
    {
        [TestMethod]
        [DataRow("day03.test01.txt", 198)]
        [DataRow("day03.txt", 775304)]
        public void Test1(string file, int expected)
        {
            var list = File.ReadAllLines(file);
            var result = new Day03().Part1(list);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("day03.test01.txt", 230)]
        [DataRow("day03.txt", 1370737)]
        public void Test2(string file, int expected)
        {
            var list = File.ReadAllLines(file);
            var result = new Day03().Part2(list);
            Assert.AreEqual(expected, result);
        }
    }
}
