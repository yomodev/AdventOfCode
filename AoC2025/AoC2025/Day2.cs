namespace AoC2025;

public class Day2
{
    public static long Part1(IEnumerable<(long left, long right)> source)
    {
        var sum = 0L;
        foreach (var (left, right) in source)
        {
            for (long i = left; i <= right; i++)
            {
                var str = i.ToString().AsSpan();
                var len = str.Length;
                var half = len / 2;
                if (str[0..half].SequenceEqual(str[half..]))
                {
                    sum += i;
                }
            }
        }

        return sum;
    }

    public static long Part2(IEnumerable<(long left, long right)> source)
    {
        var sum = 0L;
        foreach (var (left, right) in source)
        {
            for (long i = left; i <= right; i++)
            {
                if (IsValid(i))
                {
                    sum += i;
                }
            }
        }

        return sum;
    }

    public static bool IsValid(long i)
    {
        var str = i.ToString();
        var len = str.Length;
        var half = len / 2;
        var valid = Enumerable
            .Range(1, half)
            .Any(x => Match(x, str));

        return valid;
    }

    public static bool Match(int len, ReadOnlySpan<char> str)
    {
        var (d, r) = Math.DivRem(str.Length, len);
        if (r != 0)
        {
            // the slice does not fit evenly
            return false;
        }

        var first = str.Slice(0, len);
        for (int i = 1; i < d; i++)
        {
            if (!str.Slice(i * len, len).SequenceEqual(first))
            {
                return false;
            }
        }

        return true;
    }
}
