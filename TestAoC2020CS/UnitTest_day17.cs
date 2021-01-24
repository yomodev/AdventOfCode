using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day17
    {
        [TestMethod]
        public void Test_test1()
        {
            var input = File.ReadAllText(@"inputs\day17_test1.txt");
            var result = Day17.Part1(input);
            Assert.AreEqual(112, result);
        }

        [TestMethod]
        public void Test_part1()
        {
            var input = File.ReadAllText(@"inputs\day17_1.txt");
            var result = Day17.Part1(input);
            Assert.AreEqual(276, result);
        }

        [TestMethod]
        public void Test_test2()
        {
            var input = File.ReadAllText(@"inputs\day17_test1.txt");
            var result = Day17.Part2(input);
            Assert.AreEqual(848, result);
        }

        [TestMethod]
        public void Test_part2()
        {
            var input = File.ReadAllText(@"inputs\day17_1.txt");
            var result = Day17.Part2(input);
            Assert.AreEqual(2136, result);
        }

    }

}
