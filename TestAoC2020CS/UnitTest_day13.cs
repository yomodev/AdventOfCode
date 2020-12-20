using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day13
    {
        [TestMethod]
        public void Test_test1()
        {
            var input = File.ReadAllText(@"inputs\day13_test1.txt");
            var result = Day13.Part1(input);
            Assert.AreEqual(59 * 5, result);
        }

        [TestMethod]
        public void Test_part1()
        {
            var input = File.ReadAllText(@"inputs\day13_1.txt");
            var result = Day13.Part1(input);
            Assert.AreEqual(296, result);
        }

        [TestMethod]
        public void Test_test2()
        {
            var input = File.ReadAllText(@"inputs\day13_test1.txt");
            var result = Day13.Part2(input);
            Assert.AreEqual(59 * 5, result);
        }

        [TestMethod]
        public void Test_part2()
        {
            var input = File.ReadAllText(@"inputs\day13_1.txt");
            var result = Day13.Part2(input);
            Assert.AreEqual(296, result);
        }

    }

}
