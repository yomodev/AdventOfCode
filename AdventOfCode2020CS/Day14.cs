using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020CS
{
    public class Bin
    {
        long value;

        public Bin(long num = 0)
        {
            value = num;
        }

        public Bin Mask(string mask)
        {
            var bs = Convert.ToString(value, 2);
            var a = mask.PadLeft(64, '0').ToArray();
            var len = bs.Length;
            for (int i = 0; i < len; i++)
            {
                if (a[64 - len + i] == 'X')
                {
                    a[64 - len + i] = bs[i];
                }
            }
            return new Bin(Convert.ToInt64(string.Join(null, a).Replace('X', '0'), 2));
        }

        public static Bin operator +(Bin a, Bin b) => new Bin(a + b);

        public static implicit operator long(Bin a) => a.value;

    }

    public class Day14
    {
        public static long Part1(string input)
        {
            var groups = input.Split("mask = ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Split(Environment.NewLine))
                .Select(x => new
                {
                    mask = x.First(),
                    data = x.Skip(1)
                        .Select(s => s.Split(new string[] { "mem[", "] = " }, StringSplitOptions.RemoveEmptyEntries))
                        .Where(s => s.Length > 0)
                        .Select(n => new { address = int.Parse(n[0]), value = int.Parse(n[1]) }).ToArray()
                });

            var dict = groups.SelectMany(x => x.data.Select(y => (k: y.address, v: new Bin(y.value).Mask(x.mask))))
                .GroupBy(k => k.k)
                .ToDictionary(k => k.Key, v => v.Last());

            var result = dict.Sum(x=>x.Value.v);
            return result;
        }

    }

}
