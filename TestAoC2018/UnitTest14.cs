using AdventCode2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using static AdventCode2018.Day13;

namespace TestAoC2018
{
    [TestClass]
    public class UnitTest14
    {
        [TestMethod]
        public void TestMethod1()
        {
            string result = Day14.Test1(9);
            Assert.AreEqual("5158916779", result);

            result = Day14.Test1(5);
            Assert.AreEqual("0124515891", result);

            result = Day14.Test1(18);
            Assert.AreEqual("9251071085", result);

            result = Day14.Test1(2018);
            Assert.AreEqual("5941429882", result);

        }

        [TestMethod]
        public void TestMethod2()
        {
            long result = Day14.Test2("51589");
            Assert.AreEqual(9, result);

            result = Day14.Test2("01245");
            Assert.AreEqual(5, result);

            result = Day14.Test2("92510");
            Assert.AreEqual(18, result);

            result = Day14.Test2("59414");
            Assert.AreEqual(2018, result);

        }


    }

}
