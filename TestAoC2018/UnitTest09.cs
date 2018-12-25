using System;
using AdventCode2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test2018
{
    [TestClass]
    public class UnitTest09
    {
        [TestMethod]
        public void TestMethod_Day09_1()
        {
            long res1 = Day09.Test1(9, 25);
            Assert.AreEqual(32, res1);

            long res2 = Day09.Test1(10, 1618);
            Assert.AreEqual(8317, res2);

            long res3 = Day09.Test1(13, 7999);
            Assert.AreEqual(146373, res3);

            long res4 = Day09.Test1(17, 1104);
            Assert.AreEqual(2764, res4);

            long res5 = Day09.Test1(21, 6111);
            Assert.AreEqual(54718, res5);

            long res6 = Day09.Test1(30, 5807);
            Assert.AreEqual(37305, res6);

            long res7 = Day09.Test1(416, 71617);
            Assert.AreEqual(436720, res7);

            //Day09.Test1(416, 7161700);//
        }

        [TestMethod]
        public void TestMethod_Day09_2()
        {
            long res1 = Day09.Test2(9, 25);
            Assert.AreEqual(32, res1);

            long res2 = Day09.Test2(10, 1618);
            Assert.AreEqual(8317, res2);

            long res3 = Day09.Test2(13, 7999);
            Assert.AreEqual(146373, res3);

            long res4 = Day09.Test2(17, 1104);
            Assert.AreEqual(2764, res4);

            long res5 = Day09.Test2(21, 6111);
            Assert.AreEqual(54718, res5);

            long res6 = Day09.Test2(30, 5807);
            Assert.AreEqual(37305, res6);

            long res7 = Day09.Test2(416, 71617);
            Assert.AreEqual(436720, res7);
            
            long res8 = Day09.Test2(416, 7161700);
            Assert.AreEqual(0, res7);

        }
    }
}
