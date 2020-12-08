using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day04
    {
        [TestMethod]
        public void Test_test1()
        {
            var result = Day04.Test1(@"inputs\day04_test1.txt");
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Test_1()
        {
            var result = Day04.Test1(@"inputs\day04_1.txt");
            Assert.AreEqual(264, result);
        }

        [TestMethod]
        public void Test_test2()
        {
            var result = Day04.Test2(@"inputs\day04_test2.txt");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Test_test3()
        {
            var result = Day04.Test2(@"inputs\day04_test3.txt");
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Test_2()
        {
            var result = Day04.Test2(@"inputs\day04_1.txt");
            Assert.AreEqual(224, result);
        }

    }

}
