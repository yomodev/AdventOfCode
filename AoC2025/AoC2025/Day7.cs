
namespace AoC2025;

public class Day7
{
    public static int Part1(string[] lines)
    {
        var sum = 0;
        var s = lines.First().IndexOf('S');
        var data = new Day7Data(lines);
        data[1, s] = '|';
        var l = s;
        var r = s;
        for (var i = 2; i < data.Height - 1; i += 2)
        {
            for (var j = l; j <= r; j++)
            {
                if (data[i - 1, j] != '|')
                {
                    continue;
                }

                if (data[i, j] == '^')
                {
                    data[i + 1, j + 1] = '|';
                    data[i + 1, j - 1] = '|';
                    l = Math.Min(l, j - 1);
                    r = Math.Max(r, j + 1);
                    sum++;
                    continue;
                }

                data[i + 1, j] = '|';
            }
        }

        return sum;
    }

    public static int Part2(string[] lines)
    {
        var sum = 0;
        var data = lines.Select(x => x.ToCharArray()).ToArray();
        return sum;
    }
}

public class Day7Data(char[] data, int width)
{
    public Day7Data(string[] lines)
        : this([.. lines.SelectMany(x => x.ToCharArray())], lines[0].Length)
    { }

    public int Width => width;
    public int Height => data.Length / width;

    public char this[int y, int x]
    {
        get => data[y * Width + x];
        set => data[y * Width + x] = value;
    }

    public Day7Data Clone()
        => new([.. data], Width);
}
