using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day05
    {
        [TestMethod]
        public void TestMethod1()
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
    }
}
