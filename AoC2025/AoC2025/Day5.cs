
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

    public static int Part2((long start, long end)[] ranges, long[] values)
    {
        return 0;
    }
}
