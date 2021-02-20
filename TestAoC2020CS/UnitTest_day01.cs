using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day01
    {
        [TestMethod]
        public void Test_part1()
        {
            var result = Day01.Part1(File.ReadAllText(@"inputs\day01.txt"));
            Assert.AreEqual(935419, result);
        }

        [TestMethod]
        public void Test_part2()
        {
            var result = Day01.Part2(File.ReadAllText(@"inputs\day01.txt"));
            Assert.AreEqual(49880012, result);
        }

    }

}
