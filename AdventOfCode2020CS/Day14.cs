using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020CS
{
    public class Day14
    {
        public static long Mask(long value, string mask)
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

            var dict = groups.SelectMany(x => x.data.Select(y => (k: y.address, v: Mask(y.value, x.mask))))
                .GroupBy(k => k.k)
                .ToDictionary(k => k.Key, v => v.Last());

            var result = dict.Sum(x => x.Value.v);
            return result;
        }

        public static string Mask2(int value, string mask)
        {
            var bs = Convert.ToString(value, 2);
            var a = mask.PadLeft(64, '0').ToArray();
            var len = bs.Length;
            for (int i = 0; i < len; i++)
            {
                if (a[64 - len + i] == '0')
                {
                    a[64 - len + i] = bs[i];
                }
            }

            var result = string.Join(null, a)[(64 - 36)..];
            return result;
        }

        public static IEnumerable<long> Address(string mask)
        {
            var offsets = mask.Select((x, i) => (x, i)).Where(x => x.x == 'X').Select(x => x.i).ToArray();
            var range = (int)Math.Pow(2, offsets.Length);
            foreach (var n in Enumerable.Range(0, range))
            {
                var b = Convert.ToString(n, 2).PadLeft(offsets.Length, '0');
                var s = mask.ToArray();
                var j = 0;
                foreach (var i in offsets)
                {
                    s[i] = b[j++];
                }

                var result = Convert.ToInt64(string.Join(null, s), 2);
                yield return result;
            }
        }

        public static long Part2(string input)
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

            var dict = new Dictionary<long, long>();
            groups.SelectMany(x => x.data.Select(y => (value: y.value, mask: Mask2(y.address, x.mask))))
                .ForEach(x =>
                {
                    Address(x.mask).ForEach(a => dict[a] = x.value);
                });

            var result = dict.Sum(x => x.Value);
            return result;
        }

    }

}
