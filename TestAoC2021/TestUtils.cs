using AoC2021Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace TestAoC2021
{
    [TestClass]
    public class TestUtils
    {
        [TestMethod]
        public void Test1()
        {
            var range = Utils.RangeInclusive(1..3);
            Assert.AreEqual(3, range.Count());
            Assert.AreEqual(1, range.First());
            Assert.AreEqual(3, range.Last());
        }

        [TestMethod]
        public void Test2()
        {
            var range = Utils.RangeInclusive(1..3);
            Assert.AreEqual(3, range.Count());
            Assert.AreEqual(1, range.First());
            Assert.AreEqual(3, range.Last());
        }

        [TestMethod]
        public void Test3()
        {
            var range = Utils.RangeInclusive(3..3);
            Assert.AreEqual(1, range.Count());
            Assert.AreEqual(3, range.Single());
        }
    }
}
