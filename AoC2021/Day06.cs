using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AoC2021Lib
{
    public class Day06
    {

        public int Part1(List<byte> data, int days = 80)
        {
            for (int day = 0; day < days; day++)
            {
                data = Next(data);
            }
            return data.Count;
        }

        private static List<byte> Next(List<byte> data)
        {
            var list = new List<byte>(data);
            for (int i = 0; i < data.Count; i++)
            {
                var item = data[i];
                list[i] = (byte)(item - 1);
                if (item == 0)
                {
                    list[i] = 6;
                    list.Add(8);
                }
            }

            Console.WriteLine(string.Join(null, list));
            return list;
        }

        public long Debug(List<byte> data, int days = 256)
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            var history = new List<string>();

            for (int day = 0; day < days; day++)
            {
                data = Next(data);
                var str = string.Join(null, data);
                var match = history.Where(h => str.Contains(h));
                if (match.Any())
                {
                    Trace.Write($"{day} {str.Length} ");
                    match.ToList().ForEach(m => Trace.Write($"{m.Length} "));
                    Trace.WriteLine(string.Empty);
                }
                history.Add(str);
            }
            return data.Count;
        }

        // instead of creating a big list, I just count how many times a digit will appear
        public long Part2(List<byte> data, int days = 256)
        {
            long[] digit = new long[9];

            foreach (var n in data)
            {
                digit[n]++;
            }

            int day = 0;
            while(day++ < days)
            {
                long n = digit[0];
                digit[0] = digit[1];
                digit[1] = digit[2];
                digit[2] = digit[3];
                digit[3] = digit[4];
                digit[4] = digit[5];
                digit[5] = digit[6];
                digit[6] = digit[7];
                digit[7] = digit[8];
                digit[8] = n;
                digit[6] += n;
            }

            long result = digit.Sum();
            return result;
        }
        
    }
}
