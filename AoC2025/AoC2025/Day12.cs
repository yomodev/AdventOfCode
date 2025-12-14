namespace AoC2025;

public class Day12
{
    public static int Part1(string lines)
    {
        var sum = 0;
        var (shapes, regions) = Parse(lines);
        foreach (var (w, h, shapeCount) in regions)
        {
            var area = w * h;
            var shapeArea = shapeCount
                .Select((count, index) => 
                    count * shapes[index]
                        .SelectMany(x=>x)
                        .Count(c => c == '#'))
                .Sum();

            if (area >= shapeArea)
            {
                sum++;
            }
        }

        return sum;
    }

    public static int Part2(string lines)
    {
        var result = 0;
        return result;
    }

    private static (
        Dictionary<int, string[]> shapes,
        List<(int w, int h, int[] shapeCount)> regions)
        Parse(string lines)
    {
        List<(int w, int h, int[] shapes)> regions = [];
        Dictionary<int, string[]> shapes = [];
        foreach (var section in lines.Split(Environment.NewLine + Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
        {
            if (section.Contains('x'))
            {
                regions = section
                    .Split(Environment.NewLine)
                    .Select(x => x
                        .Split(['x', ':', ' '], StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray())
                    .Select(x => (w: x[0], h: x[1], s: x.Skip(2).ToArray()))
                    .ToList();
                continue;
            }

            var s = section
                .Split([":", Environment.NewLine], StringSplitOptions.RemoveEmptyEntries);
            shapes[int.Parse(s[0])] = [.. s.Skip(1)];
        }

        return (shapes, regions);
    }
}
