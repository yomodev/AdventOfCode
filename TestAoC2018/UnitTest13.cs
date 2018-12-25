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
    public class UnitTest13
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] map = File.ReadAllLines("day13_1.txt");

            // look for carts
            List<Cart> carts = Day13.LoadCarts(map);

            string joined = string.Join("", map);
            int cnt = joined.ToCharArray().Count(c => "<>^v".IndexOf(c) > -1);
            Assert.AreEqual(0, cnt);

        }


        [TestMethod]
        public void TestMethod2()
        {
            Cart c1 = new Cart(1, 1, (int)Dir.RIGHT);
            c1.Pos = new Point(1, 1);

            c1.Move('-');
            Assert.AreEqual(c1.Pos, new Point(2, 1));

            c1.CurDir = Dir.LEFT;
            c1.Move('-');
            Assert.AreEqual(c1.Pos, new Point(1, 1));

            c1.CurDir = Dir.UP;
            c1.Move('|');
            Assert.AreEqual(c1.Pos, new Point(1, 0));

            c1.CurDir = Dir.DOWN;
            c1.Move('|');
            Assert.AreEqual(c1.Pos, new Point(1, 1));

            c1.CurDir = Dir.DOWN;
            c1.Move('+');
            Assert.AreEqual(Dir.RIGHT, c1.CurDir);
            Assert.AreEqual(Dir.STRAIGHT, c1.NextDir);
            Assert.AreEqual(c1.Pos, new Point(1, 2));

            c1.CurDir = Dir.DOWN;
            c1.Move('+');
            Assert.AreEqual(Dir.DOWN, c1.CurDir);
            Assert.AreEqual(Dir.RIGHT, c1.NextDir);
            Assert.AreEqual(c1.Pos, new Point(1, 3));

            c1.CurDir = Dir.DOWN;
            c1.Move('+');
            Assert.AreEqual(Dir.LEFT, c1.NextDir);
            Assert.AreEqual(Dir.LEFT, c1.CurDir);
            Assert.AreEqual(c1.Pos, new Point(1, 4));

            c1.Move('+');
            Assert.AreEqual(Dir.STRAIGHT, c1.NextDir);
            Assert.AreEqual(c1.Pos, new Point(0, 4));





        }

    }

}
