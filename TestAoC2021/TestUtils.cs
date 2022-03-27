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
        public void Buffer_Test_Ov0()
        {
            var range = Utils.RangeInclusive(1..7);
            var windows = range.Buffer(size: 3).ToList();
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
            Assert.AreEqual(6, windows.First().Sum()); // 123
            Assert.AreEqual(12, windows[1].Sum()); // 345
            Assert.AreEqual(18, windows.Last().Sum()); // 567
        }

        [TestMethod]
        public void Buffer_Test_Ov2()
        {
            var range = Utils.RangeInclusive(1..7);
            var windows = range.Buffer(size: 3, overlap: 2).ToList();
            Assert.AreEqual(5, windows.Count);
            Assert.AreEqual(6, windows[0].Sum());// 123
            Assert.AreEqual(9, windows[1].Sum()); // 234
            Assert.AreEqual(12, windows[2].Sum()); // 345
            Assert.AreEqual(15, windows[3].Sum()); // 456
            Assert.AreEqual(18, windows[4].Sum()); // 567
        }

        [TestMethod]
        public void Buffer_Test_Ov3()
        {
            var range = Utils.RangeInclusive(1..7);
            var windows = range.Buffer(size: 4, overlap: 3).ToList();
            Assert.AreEqual(4, windows.Count);
            Assert.AreEqual(10, windows[0].Sum());// 1234
            Assert.AreEqual(14, windows[1].Sum()); // 2345
            Assert.AreEqual(18, windows[2].Sum()); // 3456
            Assert.AreEqual(22, windows[3].Sum()); // 4567
        }

        [TestMethod]
        public void Buffer_Test_4Ov1()
        {
            var range = Utils.RangeInclusive(1..7);
            var windows = range.Buffer(size: 4, overlap: 1).ToList();
            Assert.AreEqual(2, windows.Count);
            Assert.AreEqual(10, windows[0].Sum());// 1234
            Assert.AreEqual(22, windows[1].Sum()); // 4567
        }

        [TestMethod]
        public void Buffer_Test_4()
        {
            var range = Utils.RangeInclusive(1..7);
            var windows = range.Buffer(size: 4, overlap: 0).ToList();
            Assert.AreEqual(2, windows.Count);
            Assert.AreEqual(10, windows[0].Sum());// 1234
            Assert.AreEqual(18, windows[1].Sum()); // 567
        }
    }
}
