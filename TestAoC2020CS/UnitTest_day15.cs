using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day15
    {
        [TestMethod]
        public void Test_test1()
        {
            var result = Day15.Part1("0,3,6");
            Assert.AreEqual(436, result);
        }

        [TestMethod]
        public void Test_test2()
        {
            var result = Day15.Part1("1,3,2");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Test_test3()
        {
            var result = Day15.Part1("2,1,3");
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Test_test4()
        {
            var result = Day15.Part1("1,2,3");
            Assert.AreEqual(27, result);
        }

        [TestMethod]
        public void Test_test5()
        {
            var result = Day15.Part1("3,2,1");
            Assert.AreEqual(438, result);
        }

        [TestMethod]
        public void Test_test6()
        {
            var result = Day15.Part1("2,3,1");
            Assert.AreEqual(78, result);
        }

        [TestMethod]
        public void Test_test7()
        {
            var result = Day15.Part1("3,1,2");
            Assert.AreEqual(1836, result);
        }

        [TestMethod]
        public void Test_part1()
        {
            var result = Day15.Part1("15,12,0,14,3,1");
            Assert.AreEqual(249, result);
        }

        [TestMethod]
        public void Test_test8()
        {
            var result = Day15.Part2("0,3,6");
            Assert.AreEqual(175594, result);
        }

        [TestMethod]
        public void Test_test9()
        {
            var result = Day15.Part2("1,3,2");
            Assert.AreEqual(2578, result);
        }

        [TestMethod]
        public void Test_test10()
        {
            var result = Day15.Part2("2,1,3");
            Assert.AreEqual(3544142, result);
        }

        [TestMethod]
        public void Test_test11()
        {
            var result = Day15.Part2("1,2,3");
            Assert.AreEqual(261214, result);
        }

        [TestMethod]
        public void Test_test12()
        {
            var result = Day15.Part2("3,2,1");
            Assert.AreEqual(18, result);
        }

        [TestMethod]
        public void Test_test13()
        {
            var result = Day15.Part2("2,3,1");
            Assert.AreEqual(6895259, result);
        }

        [TestMethod]
        public void Test_test14()
        {
            var result = Day15.Part2("3,1,2");
            Assert.AreEqual(362, result);
        }

        [TestMethod]
        public void Test_Part2()
        {
            var result = Day15.Part2("15,12,0,14,3,1");
            Assert.AreEqual(41687, result);
        }
    
    }

}
