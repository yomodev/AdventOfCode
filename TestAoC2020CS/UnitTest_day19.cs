using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day19
    {
        [TestMethod]
        public void Test_test01()
        {
            var input = File.ReadAllText(@"inputs\day19_test2.txt");
            var result = Day19.Part1(input);
            Assert.AreEqual(2, result);
        }

        public void Test_part1()
        {
            var input = File.ReadAllText(@"inputs\day19_1.txt");
            var result = Day19.Part1(input);
            Assert.AreEqual(0, result);
        }

    }

}
