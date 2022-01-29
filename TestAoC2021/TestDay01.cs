using AoC2021Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace TestAoC2021
{
    [TestClass]
    public class TestDay01
    {
        [TestMethod]
        public void Test1()
        {
            var list = "199,200,208,210,200,207,240,269,260,263".Split(",").Select(Int32.Parse);
            var result = new Day01().Part1(list);
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void TestPart1()
        {
            var list = File.ReadAllLines("day01.txt").Select(Int32.Parse);
            var result = new Day01().Part1(list);
            Assert.AreEqual(1475, result);
        }

        [TestMethod]
        public void Test2()
        {
            var list = "199,200,208,210,200,207,240,269,260,263".Split(",").Select(Int32.Parse);
            var result = new Day01().Part2(list);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void TestPart2()
        {
            var list = File.ReadAllLines("day01.txt").Select(Int32.Parse);
            var result = new Day01().Part2(list);
            Assert.AreEqual(1516, result);
        }
    }
}
