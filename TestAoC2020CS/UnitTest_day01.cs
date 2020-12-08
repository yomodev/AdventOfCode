using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day01
    {
        [TestMethod]
        public void Test_1()
        {
            var result = Day01.Test1(File.ReadAllText(@"inputs\day01_1.txt"));
            Assert.AreEqual(935419, result);
        }

        [TestMethod]
        public void Test_2()
        {
            var result = Day01.Test2(File.ReadAllText(@"inputs\day01_1.txt"));
            Assert.AreEqual(49880012, result);
        }

    }

}
