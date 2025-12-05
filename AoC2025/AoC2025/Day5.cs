
namespace AoC2025;

public class Day5
{
    public static int Part1((long start, long end)[] ranges, long[] values)
    {
        var count = 0;
        foreach (var item in values)
        {
            var isIncluded = ranges.Any(r => item >= r.start && item <= r.end);
            count += isIncluded ? 1 : 0;
        }

        return count;
    }

    public static long Part2(List<(long start, long end)> ranges)
    {
        var sum = 0L;
        ranges.Sort();
        while (true)
        {
        repeat:
            for (int i = 1; i < ranges.Count; i++)
            {
                if (Overlaps(ranges[i], ranges[i - 1]))
                {
                    ranges[i - 1] = (
                        start: Math.Min(ranges[i - 1].start, ranges[i].start),
                        end: Math.Max(ranges[i - 1].end, ranges[i].end));
                    ranges.RemoveAt(i);
                    goto repeat;
                }
            }
            break;
        }

        foreach (var (start, end) in ranges)
        {
            sum += end - start + 1;
        }   

        return sum;
    }

    private static bool Overlaps((long start, long end) value1, (long start, long end) value2)
    {
        return (value1.start <= value2.end && value1.start >= value2.start)
            ||
            (value2.start <= value2.end && value2.start >= value1.start);
    }
}
