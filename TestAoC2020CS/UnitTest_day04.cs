using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day04
    {
        [TestMethod]
        public void Test_test1()
        {
            var input = File.ReadAllText(@"inputs\day04_test1.txt");
            var result = Day04.Part1(input);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Test_part1()
        {
            var input = File.ReadAllText(@"inputs\day04_1.txt");
            var result = Day04.Part1(input);
            Assert.AreEqual(264, result);
        }

        [TestMethod]
        public void Test_test2()
        {
            var input = File.ReadAllText(@"inputs\day04_test2.txt");
            var result = Day04.Part2(input);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Test_test3()
        {
            var input = File.ReadAllText(@"inputs\day04_test3.txt");
            var result = Day04.Part2(input);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Test_part2()
        {
            var input = File.ReadAllText(@"inputs\day04_1.txt");
            var result = Day04.Part2(input);
            Assert.AreEqual(224, result);
        }

    }

}
