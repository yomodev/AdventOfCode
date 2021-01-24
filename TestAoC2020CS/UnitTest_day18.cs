using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day18
    {
        [TestMethod]
        public void Test_test1()
        {
            var input = "1 + 2 * 3 + 4 * 5 + 6";
            var result = Day18.Part1(input);
            Assert.AreEqual(71, result);
        }

        [TestMethod]
        public void Test_test2()
        {
            var input = "1 + (2 * 3) + (4 * (5 + 6))";
            var result = Day18.Calc1(input);
            Assert.AreEqual(51, result);
        }

        [TestMethod]
        public void Test_test3()
        {
            var input = "2 * 3 + (4 * 5)";
            var result = Day18.Calc1(input);
            Assert.AreEqual(26, result);
        }

        [TestMethod]
        public void Test_test4()
        {
            var input = "5 + (8 * 3 + 9 + 3 * 4 * 3)";
            var result = Day18.Calc1(input);
            Assert.AreEqual(437, result);
        }

        [TestMethod]
        public void Test_test5()
        {
            var input = "5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))";
            var result = Day18.Calc1(input);
            Assert.AreEqual(12240, result);
        }

        [TestMethod]
        public void Test_test6()
        {
            var input = "((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2";
            var result = Day18.Calc1(input);
            Assert.AreEqual(13632, result);
        }

        [TestMethod]
        public void Test_part1()
        {
            var input = File.ReadAllText(@"inputs\day18_1.txt");
            var result = Day18.Part1(input);
            Assert.AreEqual(11004703763391, result);
        }

        [TestMethod]
        public void Test_test7()
        {
            var input = "1 + 2 * 3 + 4 * 5 + 6";
            var result = Day18.Calc2(input);
            Assert.AreEqual(231, result);
        }

        [TestMethod]
        public void Test_test8()
        {
            var input = "1 + (2 * 3) + (4 * (5 + 6))";
            var result = Day18.Calc2(input);
            Assert.AreEqual(51, result);
        }

        [TestMethod]
        public void Test_test9()
        {
            var input = "2 * 3 + (4 * 5)";
            var result = Day18.Calc2(input);
            Assert.AreEqual(46, result);
        }

        [TestMethod]
        public void Test_test10()
        {
            var input = "5 + (8 * 3 + 9 + 3 * 4 * 3)";
            var result = Day18.Calc2(input);
            Assert.AreEqual(1445, result);
        }

        [TestMethod]
        public void Test_test11()
        {
            var input = "5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))";
            var result = Day18.Calc2(input);
            Assert.AreEqual(669060, result);
        }

        [TestMethod]
        public void Test_test12()
        {
            var input = "((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2";
            var result = Day18.Calc2(input);
            Assert.AreEqual(23340, result);
        }

    }

}
