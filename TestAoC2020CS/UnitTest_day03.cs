using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day03
    {
        [TestMethod]
        public void Test_test1()
        {
            var input = File.ReadAllText(@"inputs\day03_test1.txt");
            var result = Day03.Test1(input);
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void Test_1()
        {
            var input = File.ReadAllText(@"inputs\day03_1.txt");
            var result = Day03.Test1(input);
            Assert.AreEqual(240, result);
        }

        [TestMethod]
        public void Test_test2()
        {
            var input = File.ReadAllText(@"inputs\day03_test1.txt");
            var result = Day03.Test2(input);
            Assert.AreEqual(336, result);
        }

        [TestMethod]
        public void Test_2()
        {
            var input = File.ReadAllText(@"inputs\day03_1.txt");
            var result = Day03.Test2(input);
            Assert.AreEqual(2832009600, result);
        }

    }

}
