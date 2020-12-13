using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day09
    {
        [TestMethod]
        public void Test_test1()
        {
            var input = File.ReadAllText(@"inputs\day09_test1.txt");
            var result = Day09.Test1(input, preamble: 5);
            Assert.AreEqual(127, result);
        }

        [TestMethod]
        public void Test_1()
        {
            var input = File.ReadAllText(@"inputs\day09_1.txt");
            var result = Day09.Test1(input, preamble: 25);
            Assert.AreEqual(15353384, result);
        }

        

    }

}