using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day06
    {
        [TestMethod]
        public void Test_test1()
        {
            var input = File.ReadAllText(@"inputs\day06_test1.txt");
            var result = Day06.Part1(input);
            Assert.AreEqual(11, result);
        }

        [TestMethod]
        public void Test_part1()
        {
            var input = File.ReadAllText(@"inputs\day06.txt");
            var result = Day06.Part1(input);
            Assert.AreEqual(6625, result);
        }

        [TestMethod]
        public void Test_test2()
        {
            var input = File.ReadAllText(@"inputs\day06_test1.txt");
            var result = Day06.Part2(input);
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Test_part2()
        {
            var input = File.ReadAllText(@"inputs\day06.txt");
            var result = Day06.Part2(input);
            Assert.AreEqual(3360, result);
        }

    }

}
