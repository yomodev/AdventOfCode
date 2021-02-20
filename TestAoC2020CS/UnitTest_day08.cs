using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day08
    {
        [TestMethod]
        public void Test_test1()
        {
            var input = File.ReadAllText(@"inputs\day08_test1.txt");
            var result = Day08.Part1(input);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Test_part1()
        {
            var input = File.ReadAllText(@"inputs\day08.txt");
            var result = Day08.Part1(input);
            Assert.AreEqual(1753, result);
        }

        [TestMethod]
        public void Test_test2()
        {
            var input = File.ReadAllText(@"inputs\day08_test1.txt");
            var result = Day08.Part2(input);
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void Test_part2()
        {
            var input = File.ReadAllText(@"inputs\day08.txt");
            var result = Day08.Part2(input);
            Assert.AreEqual(733, result);
        }

    }

}
