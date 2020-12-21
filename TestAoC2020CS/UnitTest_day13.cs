using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day13
    {
        [TestMethod]
        public void Test_test1()
        {
            var input = File.ReadAllText(@"inputs\day13_test1.txt");
            var result = Day13.Part1(input);
            Assert.AreEqual(59 * 5, result);
        }

        [TestMethod]
        public void Test_part1()
        {
            var input = File.ReadAllText(@"inputs\day13_1.txt");
            var result = Day13.Part1(input);
            Assert.AreEqual(296, result);
        }

        [TestMethod]
        public void Test_test2()
        {
            var input = "7,13,x,x,59,x,31,19";
            var result = Day13.Part2(input);
            Assert.AreEqual(1068781, result);
        }

        [TestMethod]
        public void Test_test3()
        {
            var input = "17,x,13,19";
            var result = Day13.Part2(input);
            Assert.AreEqual(3417, result);
        }

        [TestMethod]
        public void Test_test4()
        {
            var input = "67,7,59,61";
            var result = Day13.Part2(input);
            Assert.AreEqual(754018, result);
        }

        [TestMethod]
        public void Test_test5()
        {
            var input = "67,x,7,59,61";
            var result = Day13.Part2(input);
            Assert.AreEqual(779210, result);
        }

        [TestMethod]
        public void Test_test6()
        {
            var input = "67,7,x,59,61";
            var result = Day13.Part2(input);
            Assert.AreEqual(1261476, result);
        }

        [TestMethod]
        public void Test_test7()
        {
            var input = "1789,37,47,1889";
            var result = Day13.Part2(input);
            Assert.AreEqual(1202161486, result);
        }

        [TestMethod]
        public void Test_part2()
        {
            var input = File.ReadAllLines(@"inputs\day13_1.txt").Last();
            var result = Day13.Part2(input);
            Assert.AreEqual(535296695251210, result);
        }

    }

}
