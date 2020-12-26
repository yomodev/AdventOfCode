using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020CS
{
    public static class LongEx
    {
        public static long Mask1(this long value, string mask)
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

            var str = string.Join(null, a).Replace('X', '0');
            var result = Convert.ToInt64(str, 2);
            return result;
        }
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
                        .Select(n => new { address = int.Parse(n[0]), value = long.Parse(n[1]) }).ToArray()
                });

            var dict = groups.SelectMany(x => x.data.Select(y => (k: y.address, v: y.value.Mask1(x.mask))))
                .GroupBy(k => k.k)
                .ToDictionary(k => k.Key, v => v.Last());

            var result = dict.Sum(x=>x.Value.v);
            return result;
        }

    }

}
