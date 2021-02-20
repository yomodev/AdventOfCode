using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day19
    {
        [TestMethod]
        public void Test_test01()
        {
            var input = File.ReadAllText(@"inputs\day19_test1.txt");
            var result = Day19.Part1(input);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Test_part1()
        {
            var input = File.ReadAllText(@"inputs\day19_1.txt");
            var result = Day19.Part1(input);
            Assert.AreEqual(241, result);
        }

        [TestMethod]
        public void Test_test02()
        {
            var input = File.ReadAllText(@"inputs\day19_test2.txt");
            var result = Day19.Part2(input);
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void Test_part2()
        {
            var input = File.ReadAllText(@"inputs\day19_1.txt");
            var result = Day19.Part2(input);
            Assert.AreEqual(424, result);
        }

    }

}
