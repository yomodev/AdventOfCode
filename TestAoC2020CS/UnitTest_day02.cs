using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day02
    {
        [TestMethod]
        public void Test_1()
        {
            var result = Day02.Test1(@"inputs\day02_1.txt");
            Assert.AreEqual(456, result);
        }

        [TestMethod]
        public void Test_2()
        {
            var result = Day02.Test2(@"inputs\day02_1.txt");
            Assert.AreEqual(308, result);
        }

    }

}
