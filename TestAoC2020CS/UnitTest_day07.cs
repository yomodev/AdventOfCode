using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day07
    {
        [TestMethod]
        public void Test_test1()
        {
            var input = File.ReadAllText(@"inputs\day07_test1.txt");
            var result = Day07.Part1(input);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Test_part1()
        {
            var input = File.ReadAllText(@"inputs\day07_1.txt");
            var result = Day07.Part1(input);
            Assert.AreEqual(259, result);
        }

        [TestMethod]
        public void Test_test2()
        {
            var input = File.ReadAllText(@"inputs\day07_test1.txt");
            var result = Day07.Part2(input);
            Assert.AreEqual(32, result);
        }

        [TestMethod]
        public void Test_test3()
        {
            var input = File.ReadAllText(@"inputs\day07_test2.txt");
            var result = Day07.Part2(input);
            Assert.AreEqual(126, result);
        }

        [TestMethod]
        public void Test_part2()
        {
            var input = File.ReadAllText(@"inputs\day07_1.txt");
            var result = Day07.Part2(input);
            Assert.AreEqual(45018, result);
        }


    }

}
