using AoC2021Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestAoC2021
{
    [TestClass]
    public class TestDay13
    {
        [TestMethod]
        [DataRow(@"data\day13.test01.txt", 17)]
        [DataRow(@"data\day13.txt", 814)]
        [DataRow(@"data\day13b.txt", 631)]
        public void Test1(string file, int expected)
        {
            var input = File.ReadAllText(file);
            var result = new Day13().Part1(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(@"data\day13.test01.txt", @"data\day13.test01.output.txt")]
        [DataRow(@"data\day13.txt", @"data\day13.output.txt")]
        [DataRow(@"data\day13b.txt", @"data\day13b.output.txt")]
        public void Test2(string inputFile, string expectedFile)
        {
            var input = File.ReadAllText(inputFile);
            var result = new Day13().Part2(input);
            var expected = File.ReadAllText(expectedFile);
            Assert.AreEqual(expected, result);
        }
    }
}
