using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day14
    {
        [TestMethod]
        public void Test_test1()
        {
            var b1 = new Bin(11);
            var b2 = b1.Mask("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X");
            var result = b2 + 0;
            Assert.AreEqual(73, result);
        }

        [TestMethod]
        public void Test_test2()
        {
            var input = File.ReadAllText(@"inputs\day14_test1.txt");
            var result = Day14.Part1(input);
            Assert.AreEqual(165, result);
        }

        [TestMethod]
        public void Test_part1()
        {
            var input = File.ReadAllText(@"inputs\day14_1.txt");
            var result = Day14.Part1(input);
            Assert.AreEqual(18630548206046, result);
        }

    }

}
