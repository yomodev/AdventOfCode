using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day12
    {
        [TestMethod]
        public void Test_test1()
        {
            var input = File.ReadAllText(@"inputs\day12_test1.txt");
            var result = Day12.Part1(input);
            Assert.AreEqual(25, result);
        }

        [TestMethod]
        public void Test_part1()
        {
            var input = File.ReadAllText(@"inputs\day12_1.txt");
            var result = Day12.Part1(input);
            Assert.AreEqual(882, result);
        }

    }

}
