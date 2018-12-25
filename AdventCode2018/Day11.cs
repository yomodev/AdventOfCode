using System;
using System.IO;

namespace AdventCode2018
{
    public class Day11
    {

        public static long Test1(int serial, int w = 300, int h = 300, int square = 3)
        {
            int[][] m = new int[h][];
            for (int j = 0; j < h; j++)
            {
                m[j] = new int[w];
                for (int k = 0; k < w; k++)
                {
                    m[j][k] = CalcValue(serial, k + 1, j + 1);
                }
            }
            printa(m);

            string coord = "0,0";
            long M = Int32.MinValue;
            for (int j = 0; j < h - 2; j++)
            {
                for (int k = 0; k < w - 2; k++)
                {
                    int n = m[j][k] + m[j + 1][k] + m[j + 2][k];
                    n += m[j][k + 1] + m[j + 1][k + 1] + m[j + 2][k + 1];
                    n += m[j][k + 2] + m[j + 1][k + 2] + m[j + 2][k + 2];

                    if (n > M)
                    {
                        coord = string.Format("{0},{1}", k + 1, j + 1);
                        M = n;
                    }
                }
            }

            Console.WriteLine("done {0} = {1}", coord, M);
            return M;
        }


        public static long Test2(int serial, int w = 300, int h = 300)
        {
            int[][] m = new int[h][];
            for (int j = 0; j < h; j++)
            {
                m[j] = new int[w];
                for (int k = 0; k < w; k++)
                {
                    m[j][k] = CalcValue(serial, k + 1, j + 1);
                }
            }
            printa(m);

            string coord = "0,0";
            long M = Int32.MinValue;
            for (int j = 0; j < h; j++)
            {
                //Console.WriteLine("{0}", j);

                for (int k = 0; k < w; k++)
                {
                    for (int q = 0; q < w - k && q < h - j; q++)
                    //for (int q = 2; q < 3; q++)
                    {
                        int n = 0;
                        for (int qj = 0; qj < q; qj++)
                        {
                            for (int qk = 0; qk < q; qk++)
                            {
                                n += m[qj + j][qk + k];
                                //Console.WriteLine("q{0} {1},{2} {3},{4}", q, j, k, qj +j, qk + k);
                            }
                        }
                        //Console.WriteLine("{0}={1} - {2}", coord, n, M);
                        if (n > M)
                        {
                            coord = string.Format("max {0},{1},{2}", k + 1, j + 1, q);
                            M = n;
                            Console.WriteLine("{0} {1}",coord, M);
                        }
                    }

                }
            }

            Console.WriteLine("done {0} = {1}", coord, M);
            return M;
        }

        public static int CalcValue(int serial, int x, int y)
        {
            //For example, to find the power level of the fuel cell 
            //at 3,5 in a grid with serial number 8:
            //The rack ID is 3 + 10 = 13.
            //The power level starts at 13 * 5 = 65.
            //Adding the serial number produces 65 + 8 = 73.
            //Multiplying by the rack ID produces 73 * 13 = 949.
            //The hundreds digit of 949 is 9.
            //Subtracting 5 produces 9 - 5 = 4.
            int rackId = x + 10;
            int result = (((rackId * y + serial) * rackId) / 100) % 10 - 5;
            return result;
        }

        private static void printa(int[][] m)
        {
            using (StreamWriter tw = File.CreateText("day11.txt"))
            {
                for (int i = 0; i < m.Length; i++)
                {
                    tw.WriteLine(string.Join(" ", m[i]));
                }
            }
        }
    }
}

