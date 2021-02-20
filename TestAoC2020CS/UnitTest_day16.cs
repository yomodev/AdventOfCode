using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day16
    {
        [TestMethod]
        public void Test_test1()
        {
            var input = File.ReadAllText(@"inputs\day16_test1.txt");
            var result = Day16.Part1(input);
            Assert.AreEqual(71, result);
        }

        [TestMethod]
        public void Test_part1()
        {
            var input = File.ReadAllText(@"inputs\day16.txt");
            var result = Day16.Part1(input);
            Assert.AreEqual(19093, result);
        }

        [TestMethod]
        public void Test_test2()
        {
            var input = File.ReadAllText(@"inputs\day16_test2.txt");
            var result = Day16.DecodeTicket(input);
            Assert.AreEqual(12, result["class"]);
            Assert.AreEqual(11, result["row"]);
            Assert.AreEqual(13, result["seat"]);
        }

        [TestMethod]
        public void Test_part2()
        {
            var input = File.ReadAllText(@"inputs\day16.txt");
            var result = Day16.Part2(input);
            Assert.AreEqual(5311123569883, result);
        }

    }

}
