using AdventCode2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAoC2018
{
    [TestClass]
    public class UnitTest11
    {
        [TestMethod]
        public void TestMethod1()
        {
            int res = Day11.CalcValue(8, 3, 5);
            Assert.AreEqual(4, res);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int res = Day11.CalcValue(57, 122, 79);
            Assert.AreEqual(-5, res);

            res = Day11.CalcValue(39, 217, 196);
            Assert.AreEqual(0, res);

            res = Day11.CalcValue(71, 101, 153);
            Assert.AreEqual(4, res);
        }
    }
}
