using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day10
    {
        [TestMethod]
        public void Test_test1()
        {
            var input = File.ReadAllText(@"inputs\day10_test1.txt");
            var result = Day10.Part1(input);
            Assert.AreEqual(7*5, result);
        }

        [TestMethod]
        public void Test_test2()
        {
            var input = File.ReadAllText(@"inputs\day10_test2.txt");
            var result = Day10.Part1(input);
            Assert.AreEqual(22*10, result);
        }

        [TestMethod]
        public void Test_part1()
        {
            var input = File.ReadAllText(@"inputs\day10.txt");
            var result = Day10.Part1(input);
            Assert.AreEqual(2312, result);
        }

        [TestMethod]
        public void Test_test3()
        {
            var input = File.ReadAllText(@"inputs\day10_test1.txt");
            var result = Day10.Part2(input);
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void Test_test4()
        {
            var input = File.ReadAllText(@"inputs\day10_test2.txt");
            var result = Day10.Part2(input);
            Assert.AreEqual(19208, result);
        }

        [TestMethod]
        public void Test_part2()
        {
            var input = File.ReadAllText(@"inputs\day10.txt");
            var result = Day10.Part2(input);
            Assert.AreEqual(12089663946752, result);
        }

    }

}
