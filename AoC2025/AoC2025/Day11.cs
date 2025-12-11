namespace AoC2025;

public class Day11
{
    public static int Part1(string[] lines)
    {
        var dict = Parse(lines);
        var paths = new HashSet<string>();
        Paths(dict, paths, "you");
        return paths.Where(x => x.EndsWith("out")).Count();
    }

    private static void Paths(
        Dictionary<string, string[]> dict,
        HashSet<string> paths,
        string node,
        string path = "")
    {
        path = $"{path} {node}";
        paths.Add(path);
        if (node == "out")
        {
            // File.AppendAllText("paths.txt", path + Environment.NewLine);
            return;
        }

        foreach (var sub in dict[node])
        {
            if (paths.Contains($"{path} {sub}"))
            {
                continue;
            }

            Paths(dict, paths, sub, path);
        }
    }

    public static int Part2(string[] lines)
    {
        var dict = Parse(lines);
        var paths = new HashSet<string>();
        Paths(dict, paths, "svr");
        return paths
            .Where(x => x.EndsWith("out") && x.Contains("fft") && x.Contains("dac"))
            .Count();
    }

    private static Dictionary<string, string[]> Parse(string[] lines)
    {
        return lines
            .Select(line => line.Split([':', ' '], StringSplitOptions.RemoveEmptyEntries))
            .ToDictionary(k => k[0], v => v.Skip(1).ToArray());
    }
}
