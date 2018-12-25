using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace AdventCode2018
{
    public class Day10
    {

        public static void Test1(string file)
        {
            List<Tuple<int, int>> pos = new List<Tuple<int, int>>();
            List<Tuple<int, int>> speed = new List<Tuple<int, int>>();

            foreach (string line in File.ReadLines(file))
            {
                string[] split = line.Split(new char[] { '<', '>', ',' }, StringSplitOptions.RemoveEmptyEntries);

                int x = Int32.Parse(split[1]);
                int y = Int32.Parse(split[2]);
                int dx = Int32.Parse(split[4]);
                int dy = Int32.Parse(split[5]);

                pos.Add(new Tuple<int, int>(x, y));
                speed.Add(new Tuple<int, int>(dx, dy));

            }

            List<Tuple<int, int>> prevList = new List<Tuple<int, int>>();
            Rectangle prevWin;
            Rectangle win = Window(pos);
            int sec = 0;
            do
            {
                sec++;
                prevList = new List<Tuple<int, int>>(pos);

                for (int i = 0; i < pos.Count; i++)
                {
                    pos[i] = new Tuple<int, int>(pos[i].Item1 + speed[i].Item1, pos[i].Item2 + speed[i].Item2);
                }
                prevWin = win;
                win = Window(pos);                
            }
            while (win.Width < prevWin.Width && win.Height < prevWin.Height);

            Console.WriteLine("{0} sec {1}x{2}", sec-1, prevWin.Width, prevWin.Height);

            Bitmap b = new Bitmap(prevWin.Width +3, prevWin.Height + 3);

            foreach (var item in prevList)
            {
                b.SetPixel(item.Item1 +1 - prevWin.X, item.Item2 +1 - prevWin.Y, Color.White);
            }

            b.Save("day10.bmp", ImageFormat.Bmp);
        }

        private static Rectangle Window(List<Tuple<int, int>> pos)
        {
            int x = Int32.MaxValue;
            int w = Int32.MinValue;
            int y = x;
            int h = w;
            for (int i = 0; i < pos.Count; i++)
            {
                x = pos[i].Item1 < x ? pos[i].Item1 : x;
                w = pos[i].Item1 > w ? pos[i].Item1 : w;
                y = pos[i].Item2 < y ? pos[i].Item2 : y;
                h = pos[i].Item2 > h ? pos[i].Item2 : h;
            }

            return new Rectangle(x, y, w - x, h - y);
        }
    }
}

