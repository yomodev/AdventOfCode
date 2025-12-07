namespace AoC2025;

public class Day07
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

    public static long Part2(string[] lines)
    {
        var s = lines.First().IndexOf('S');
        var data = new Day7Data(lines);
        data[1, s] = '|';
        var result = Explore(data, 2, s);
        return result;
    }

    private static long Explore(Day7Data data, int y, int x, Dictionary<(int, int), long>? dict = null)
    {
        dict ??= [];
        if (dict.TryGetValue((x, y), out var res))
        {
            return res;
        }

        // data.Save($"output{y}_{x}_{Guid.NewGuid()}.txt");
        if (y == data.Height)
        {
            return 1;
        }

        var result = 0L;
        if (data[y, x] == '^')
        {
            var left = data.Clone();
            left[y - 1, x] = '|';
            result = Explore(left, y + 2, x - 1, dict);
            
            data[y + 1, x] = '|';
            result += Explore(data, y + 2, x + 1, dict);
        }
        else if (data[y, x] == '.')
        {
            data[y, x] = '|';
            data[y + 1, x] = '|';
            result = Explore(data, y + 2, x, dict);
        }

        dict[(x, y)] = result;
        return result;
    }
}

public class Day7Data(char[] data, int width)
{
    private readonly char[] data = data;
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

    public Day7Data Clone() => new([.. data], Width);

    public void Save(string fileName)
    {
        var text = ToString();
        File.WriteAllText(fileName, text);
    }

    public override string ToString()
    {
        var text = string.Join(Environment.NewLine, data
            .Chunk(Width)
            .Select(line => new string(line)));
        return text;
    }
}
