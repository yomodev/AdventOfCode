using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace AdventCode2018
{
    public class Day13
    {
        const string DirectionString = @">^<v.";

        public enum Dir
        {
            RIGHT, UP, LEFT, DOWN, STRAIGHT
        }

        public class Cart
        {
            public Dir CurDir { get; set; }
            public Dir NextDir { get; set; }
            public Point Pos;// { get; set; }
            public bool Crashed = false;


            public Cart(int x, int y, int dir)
            {
                CurDir = (Dir)dir;
                NextDir = Dir.LEFT;
                Pos = new Point(x, y);
            }

            public void Move(char c)
            {
                Dir dir = CurDir;
                if (c == '+')
                {
                    dir = NextDir == Dir.LEFT ? (Dir)(((int)CurDir + 1) % 4) : dir; //CCW
                    dir = NextDir == Dir.RIGHT ? (Dir)((int)CurDir - 1 < 0 ? 3 : (int)CurDir - 1) : dir; //CW
                    NextDir = (Dir)(((int)NextDir + 2) % 6);//ok
                }
                // CW
                else if ((c == '\\' && (CurDir == Dir.LEFT || CurDir == Dir.RIGHT))
                      || (c == '/' && (CurDir == Dir.DOWN || CurDir == Dir.UP)))
                {
                    dir = (Dir)((int)CurDir - 1 < 0 ? 3 : (int)CurDir - 1);
                }
                // CCW
                else if (c == '/' || c == '\\')
                {
                    dir = (Dir)(((int)CurDir + 1) % 4);
                }
                else if (c != '-' && c != '|')
                {
                    throw new Exception("invalid block");
                }

                switch (dir)
                {
                    case Dir.LEFT:
                        Pos.X--;
                        break;
                    case Dir.RIGHT:
                        Pos.X++;
                        break;
                    case Dir.UP:
                        Pos.Y--;
                        break;
                    case Dir.DOWN:
                        Pos.Y++;
                        break;
                    default:
                        throw new Exception("invalid direction");
                }

                if (Pos.X < 0 || Pos.Y < 0)
                {
                    throw new Exception("invalid point");
                }

                if (!Enum.IsDefined(typeof(Dir), dir))
                {
                    throw new Exception("invalid direction");
                }

                CurDir = dir;
            }
            
            public override string ToString()
            {
                return string.Format("{0},{1} dir: {2}, next: {3}", Pos.X, Pos.Y, CurDir, NextDir);
            }
            
        }



        public static List<Cart> LoadCarts(string[] map)
        {
            List<Cart> carts = new List<Cart>();
            for (int y = 0; y < map.Length; y++)
            {
                for (int x = 0; x < map[0].Length; x++)
                {
                    int dir = DirectionString.IndexOf(map[y][x]);
                    if (dir > -1)
                    {
                        Cart c = new Cart(x, y, dir);
                        carts.Add(c);

                        List<char> s = map[c.Pos.Y].ToList();
                        s[c.Pos.X] = c.CurDir == Dir.DOWN || c.CurDir == Dir.UP ? '|' : '-';
                        map[c.Pos.Y] = string.Join("", s);
                    }
                }
            }

            return carts;
        }

        
        public static Point Test1(string file)
        {
            string[] map = File.ReadAllLines(file);
            List<Cart> carts = LoadCarts(map);

            while (true)
            {
                foreach (Cart cart in carts)
                {
                    cart.Move(map[cart.Pos.Y][cart.Pos.X]);
                    Console.WriteLine(cart);
                }

                var groups = carts.GroupBy(i => i.Pos).OrderByDescending(g => g.Count());
                if (groups.First().Count() > 1)
                {
                    Point p = groups.First().Key;
                    Console.WriteLine(p);
                    return p;
                }
            }
        }

        public static Point Test2(string file)
        {
            string[] map = File.ReadAllLines(file);
            List<Cart> carts = LoadCarts(map);
            Console.WriteLine("carts {0}", carts.Count);

            int step = 0;
            while (true)
            {
                step++;
                foreach (Cart cart in carts.OrderBy(c => c.Pos.Y).ThenBy(c => c.Pos.X).ToList())
                {
                    if (carts.IndexOf(cart) == -1)
                        continue;

                    cart.Move(map[cart.Pos.Y][cart.Pos.X]);
                    Console.WriteLine("step {0} - move - {1}", step, cart);

                    var groups = carts.GroupBy(i => i.Pos).OrderByDescending(g => g.Count());
                    foreach (var grp in groups.Where(g => g.Count() > 1))
                    {
                        foreach (var c in grp)
                        {
                            Console.WriteLine("step {0} - delete - {1}", step, c);
                            carts.Remove(c);
                        }

                        if (carts.Count == 1)
                        {
                            Point p = carts.First().Pos;
                            Console.WriteLine(p);
                            return p;
                        }
                    }
                }

                
            }
        }


        public static Point Test(string file)
        {
            string[] map = File.ReadAllLines(file);
            List<Cart> carts = LoadCarts(map);
            Console.WriteLine("carts {0}", carts.Count);

            int step = 0;
            while (true)
            {
                step++;
                
                // Move all carts
                carts = carts.Where(c => !c.Crashed).OrderBy(c => c.Pos.Y).ThenBy(c => c.Pos.X).ToList();
                //carts = carts.Where(c => !c.Crashed).OrderBy(c => c.ToString()).ToList();
                foreach (var cart in carts)
                {
                    cart.Move(map[cart.Pos.Y][cart.Pos.X]);

                    bool result = carts.Where(c => !c.Crashed).Count(c => c.Pos.X == cart.Pos.X && c.Pos.Y == cart.Pos.Y) == 1;

                    //Console.WriteLine("step {0} - move - {1}", step, cart);
                    if (!result)
                    {
                        foreach (var item in carts.Where(c => c.Pos.X == cart.Pos.X && c.Pos.Y == cart.Pos.Y).OrderBy(c => c.ToString()))
                        {
                            Console.WriteLine("step {0} - delete - {1}", step, cart);
                            item.Crashed = true;
                        }
                    }
                }

                foreach (Cart cart in carts.OrderBy(c => c.ToString()))
                {
                    //Console.WriteLine("step {0} - move - {1}", step, cart);
                }

                //PrintAll(map, carts.Where(c => !c.Crashed).ToList());
                if (carts.Count(c => !c.Crashed) == 1)
                {
                    Point p = carts.Where(c => !c.Crashed).First().Pos;
                    Console.WriteLine(p);
                    return p;
                }
            }

        }


    }

}
