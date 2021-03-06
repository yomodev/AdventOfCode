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
            var result = Day14.Mask(11, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X");
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
            var input = File.ReadAllText(@"inputs\day14.txt");
            var result = Day14.Part1(input);
            Assert.AreEqual(18630548206046, result);
        }

        [TestMethod]
        public void Test_test3()
        {
            var mask = Day14.Mask2(42, "000000000000000000000000000000X1001X");
            Assert.AreEqual("000000000000000000000000000000X1101X", mask);

            var values = Day14.Address(mask).ToArray();
            Assert.AreEqual(4, values.Length);
            Assert.IsTrue(values.Contains(26));
            Assert.IsTrue(values.Contains(27));
            Assert.IsTrue(values.Contains(58));
            Assert.IsTrue(values.Contains(59));
        }

        [TestMethod]
        public void Test_test4()
        {
            var input = File.ReadAllText(@"inputs\day14_test2.txt");
            var result = Day14.Part2(input);
            Assert.AreEqual(208, result);
        }

        [TestMethod]
        public void Test_part2()
        {
            var input = File.ReadAllText(@"inputs\day14.txt");
            var result = Day14.Part2(input);
            Assert.AreEqual(4254673508445, result);
        }

    }

}
