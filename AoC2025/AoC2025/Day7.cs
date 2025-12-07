
namespace AoC2025;

public class Day7
{
    public static int Part1(string[] lines)
    {
        var sum = 0;
        var data = lines.Select(x => x.ToCharArray()).ToArray();
        var s = data[0].IndexOf('S');
        data[1][s] = '|';
        var l = s;
        var r = s;
        for (var i = 2; i < data.Length - 1; i+=2)
        {
            for (var j = l; j <= r; j++)
            {
                if (data[i - 1][j] != '|')
                {
                    continue;
                }

                if (data[i][j] == '^')
                {
                    data[i + 1][j + 1] = '|';
                    data[i + 1][j - 1] = '|';
                    l = Math.Min(l, j - 1);
                    r = Math.Max(r, j + 1);
                    sum++;
                    continue;
                }

                data[i + 1][j] = '|';
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
