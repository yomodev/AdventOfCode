using AoC2021Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestAoC2021
{
    [TestClass]
    public class TestDay13
    {
        [TestMethod]
        [DataRow("day13.test01.txt", 17)]
        [DataRow("day13.txt", 814)]
        public void Test1(string file, int expected)
        {
            var input = File.ReadAllText(file);
            var result = new Day13().Part1(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("day13.test01.txt", "day13.test01.output.txt")]
        [DataRow("day13.txt", "day13.output.txt")]
        public void Test2(string inputFile, string expectedFile)
        {
            var input = File.ReadAllText(inputFile);
            var result = new Day13().Part2(input);
            var expected = File.ReadAllText(expectedFile);
            Assert.AreEqual(expected, result);
        }
    }
}
