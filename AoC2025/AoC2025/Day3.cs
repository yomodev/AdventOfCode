namespace AoC2025;

public class Day3
{
    public static int Part1(IEnumerable<string> lines)
    {
        int sum = 0;
        foreach (var line in lines)
        {
            var len = line.Length;
            var max = 0;
            for (int i = 0; i < len - 1; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    max = Math.Max(max, N(line, i, j));
                }
            }

            sum += max;
        }

        return sum;
    }

    public static int N(ReadOnlySpan<char> span, int x, int y)
    {
        return (span[x] - '0') * 10 + span[y] - '0';
    }

    public static long Part2(IEnumerable<string> lines)
    {
        long sum = 0;
        foreach (var line in lines)
        {
            sum += FindMax(line, 12);
        }

        return sum;
    }

    private static long FindMax(ReadOnlySpan<char> line, int size)
    {
        long max = 0;
        return max;
    }
}
