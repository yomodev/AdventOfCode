using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day01
    {
        [TestMethod]
        public void Test_1()
        {
            var result = Day01.Test1(@"inputs\day01_1.txt");
            Assert.AreEqual(935419, result);
        }

        [TestMethod]
        public void Test_2()
        {
            var result = Day01.Test2(@"inputs\day01_1.txt");
            Assert.AreEqual(49880012, result);
        }

    }

}
