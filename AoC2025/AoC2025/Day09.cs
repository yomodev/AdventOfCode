namespace AoC2025;

public class Day09
{
    public static long Part1(IEnumerable<(int x, int y)> data)
    {
        long max = 0;
        var s = data.ToList();
        for (int i = 0; i < s.Count - 1; i++)
        {
            for (int j = i + 1; j < s.Count; j++)
            {
                if (s[i].x == s[j].x || s[i].y == s[j].y)
                {
                    continue;
                }

                long w = Math.Abs(s[i].x - s[j].x) + 1;
                long h = Math.Abs(s[i].y - s[j].y) + 1;
                var area = w * h;
                //Debug.WriteLine($"({s[i].x},{s[i].y}) ({s[j].x},{s[j].y}) => {area}");
                max = Math.Max(max, area);
            }
        }

        return max;
    }

    public static int Part2(string[] lines)
    {
        var result = 0;
        return result;
    }
}
