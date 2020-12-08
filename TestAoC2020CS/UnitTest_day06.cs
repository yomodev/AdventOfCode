using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day06
    {
        [TestMethod]
        public void Test_test1()
        {
            var result = Day06.Test1(@"inputs\day06_test1.txt");
            Assert.AreEqual(11, result);
        }

        [TestMethod]
        public void Test_1()
        {
            var result = Day06.Test1(@"inputs\day06_1.txt");
            Assert.AreEqual(6625, result);
        }

        [TestMethod]
        public void Test_test2()
        {
            var result = Day06.Test2(@"inputs\day06_test1.txt");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Test_2()
        {
            var result = Day06.Test2(@"inputs\day06_1.txt");
            Assert.AreEqual(3360, result);
        }

    }

}
