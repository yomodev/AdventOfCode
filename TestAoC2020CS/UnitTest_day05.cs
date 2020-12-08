using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day05
    {
        [TestMethod]
        public void Test_GetSeatID()
        {
            var sid = Day05.GetSeatID("FBFBBFFRLR");
            Assert.AreEqual(357, sid);

            sid = Day05.GetSeatID("BFFFBBFRRR");
            Assert.AreEqual(567, sid);

            sid = Day05.GetSeatID("FFFBBBFRRR");
            Assert.AreEqual(119, sid);

            sid = Day05.GetSeatID("BBFFBBFRLL");
            Assert.AreEqual(820, sid);
        }

        [TestMethod]
        public void Test_1()
        {
            var input = File.ReadAllText(@"inputs\day05_1.txt");
            var result = Day05.Test1(input);
            Assert.AreEqual(878, result);
        }

        [TestMethod]
        public void Test_2()
        {
            var input = File.ReadAllText(@"inputs\day05_1.txt");
            var result = Day05.Test2(input);
            Assert.AreEqual(504, result);
        }
    }
}
