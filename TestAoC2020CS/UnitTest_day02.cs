using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day02
    {
        [TestMethod]
        public void Test_1()
        {
            var input = File.ReadAllText(@"inputs\day02_1.txt");
            var result = Day02.Test1(input);
            Assert.AreEqual(456, result);
        }

        [TestMethod]
        public void Test_2()
        {
            var input = File.ReadAllText(@"inputs\day02_1.txt");
            var result = Day02.Test2(input);
            Assert.AreEqual(308, result);
        }

    }

}
