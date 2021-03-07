using AdventOfCode2020CS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestAoC2020CS
{
    [TestClass]
    public class UnitTest_day20
    {
        [TestMethod]
        public void Test_test01()
        {
            var input = File.ReadAllText(@"inputs\day20_test1.txt");
            var result = Day20.Part1(input);
            Assert.AreEqual(20899048083289, result);
        }

        [TestMethod]
        public void Test_part1()
        {
            var input = File.ReadAllText(@"inputs\day20.txt");
            var result = Day20.Part1(input);
            Assert.AreEqual(66020135789767, result);
        }

        const string monster = @"                  # 
#    ##    ##    ###
 #  #  #  #  #  #   ";

        [TestMethod]
        public void Test_test02()
        {
            var input = File.ReadAllText(@"inputs\day20_test2.txt");
            var result = Day20.Part2(input, monster);
            Assert.AreEqual(273, result);
        }

        [TestMethod]
        public void Test_part2()
        {
            var input = File.ReadAllText(@"inputs\day20.txt");
            var result = Day20.Part2(input, monster);
            Assert.AreEqual(424, result);
        }

    }

}
