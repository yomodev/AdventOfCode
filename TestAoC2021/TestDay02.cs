using AoC2021Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace TestAoC2021
{
    [TestClass]
    public class TestDay02
    {
        [TestMethod]
        public void Test1()
        {
            var list = "forward 5,down 5,forward 8,up 3,down 8,forward 2".Split(",");
            var result = new Day02().Part1(list);
            Assert.AreEqual(150, result);
        }

        [TestMethod]
        [DataRow("day02.txt", 1690020)]
        [DataRow("day02b.txt", 2073315)]
        public void TestPart1(string file, int expected)
        {
            var list = File.ReadAllLines(file);
            var result = new Day02().Part1(list);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test2()
        {
            var list = "forward 5,down 5,forward 8,up 3,down 8,forward 2".Split(",");
            var result = new Day02().Part2(list);
            Assert.AreEqual(900, result);
        }

        [TestMethod]
        [DataRow("day02.txt", 1408487760)]
        [DataRow("day02b.txt", 1840311528)]
        public void TestPart2(string file, int expected)
        {
            var list = File.ReadAllLines(file);
            var result = new Day02().Part2(list);
            Assert.AreEqual(expected, result);
        }
    }
}
