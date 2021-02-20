using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day11
    {
        [TestMethod]
        public void Test_test1()
        {
            var input = File.ReadAllText(@"inputs\day11_test1.txt");
            var result = Day11.Part1(input);
            Assert.AreEqual(37, result);
        }

        [TestMethod]
        public void Test_part1()
        {
            var input = File.ReadAllText(@"inputs\day11.txt");
            var result = Day11.Part1(input);
            Assert.AreEqual(2334, result);
        }

        [TestMethod]
        public void Test_test2()
        {
            var input = File.ReadAllText(@"inputs\day11_test1.txt");
            var result = Day11.Part2(input);
            Assert.AreEqual(26, result);
        }

        [TestMethod]
        public void Test_part2()
        {
            var input = File.ReadAllText(@"inputs\day11.txt");
            var result = Day11.Part2(input);
            Assert.AreEqual(2100, result);
        }

    }

}
