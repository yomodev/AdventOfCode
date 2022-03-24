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

        [TestMethod]
        public void Buffer2_Test_Ov0()
        {
            var range = Utils.RangeInclusive(1..7);
            var size = 3;
            var windows = range.Buffer2(size).ToList();
            Assert.AreEqual(3, windows.Count);
            Assert.AreEqual(6, windows.First().Sum());
            Assert.AreEqual(15, windows[1].Sum());
            Assert.AreEqual(7, windows.Last().Single());
        }

        [TestMethod]
        public void Buffer_Test_Ov0()
        {
            var range = Utils.RangeInclusive(1..7);
            var size = 3;
            var windows = range.Buffer(size).ToList();
            Assert.AreEqual(3, windows.Count);
            Assert.AreEqual(6, windows.First().Sum());
            Assert.AreEqual(15, windows[1].Sum());
            Assert.AreEqual(7, windows.Last().Single());
        }

        [TestMethod]
        public void Buffer_Test_Ov1()
        {
            var range = Utils.RangeInclusive(1..7);
            var size = 3;
            var windows = range.Buffer(size, overlap: 1).ToList();
            Assert.AreEqual(3, windows.Count);
            Assert.AreEqual(6, windows.First().Sum());
            Assert.AreEqual(12, windows[1].Sum());
            Assert.AreEqual(18, windows.Last().Sum());
        }

        [TestMethod]
        public void Buffer2_Test_Ov1()
        {
            var range = Utils.RangeInclusive(1..7);
            var size = 3;
            var windows = range.Buffer2(size, overlap: 1).ToList();
            Assert.AreEqual(3, windows.Count);
            Assert.AreEqual(6, windows.First().Sum());
            Assert.AreEqual(12, windows[1].Sum());
            Assert.AreEqual(18, windows.Last().Sum());
        }
    }
}
