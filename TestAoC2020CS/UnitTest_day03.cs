using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day03
    {
        [TestMethod]
        public void Test_test1()
        {
            var result = Day03.Test1(@"inputs\day03_test1.txt");
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void Test_1()
        {
            var result = Day03.Test1(@"inputs\day03_1.txt");
            Assert.AreEqual(240, result);
        }

        [TestMethod]
        public void Test_test2()
        {
            var result = Day03.Test2(@"inputs\day03_test1.txt");
            Assert.AreEqual(336, result);
        }

        [TestMethod]
        public void Test_2()
        {
            var result = Day03.Test2(@"inputs\day03_1.txt");
            Assert.AreEqual(2832009600, result);
        }

    }

}
