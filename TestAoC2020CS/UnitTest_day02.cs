using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day02
    {
        [TestMethod]
        public void Test_part1()
        {
            var input = File.ReadAllText(@"inputs\day02_1.txt");
            var result = Day02.Part1(input);
            Assert.AreEqual(456, result);
        }

        [TestMethod]
        public void Test_part2()
        {
            var input = File.ReadAllText(@"inputs\day02_1.txt");
            var result = Day02.Part2(input);
            Assert.AreEqual(308, result);
        }

    }

}
