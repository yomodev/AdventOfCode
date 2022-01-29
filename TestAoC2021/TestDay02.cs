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
        public void TestPart1()
        {
            var list = File.ReadAllLines("day02.txt");
            var result = new Day02().Part1(list);
            Assert.AreEqual(1690020, result);
        }

        [TestMethod]
        public void Test2()
        {
            var list = "forward 5,down 5,forward 8,up 3,down 8,forward 2".Split(",");
            var result = new Day02().Part2(list);
            Assert.AreEqual(900, result);
        }

        [TestMethod]
        public void TestPart2()
        {
            var list = File.ReadAllLines("day02.txt");
            var result = new Day02().Part2(list);
            Assert.AreEqual(1408487760, result);
        }
    }
}
