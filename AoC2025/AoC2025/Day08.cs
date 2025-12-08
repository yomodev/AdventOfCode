namespace AoC2025;

public class Day08
{
    public static int Part1(IList<(int x, int y, int z)> lines, int connections)
    {
        var d = new List<(Point p1, Point p2, double distance)>(lines.Count * lines.Count);
        var p = lines.ToDictionary(k => new Point(k.x, k.y, k.z), v => new HashSet<Point> { new(v.x, v.y, v.z) });
        var total = 0;

        for (int i = 0; i < lines.Count - 1; i++)
        {
            for (int j = i + 1; j < lines.Count; j++)
            {
                if (i == j) continue;
                var p1 = new Point(lines[i].x, lines[i].y, lines[i].z);
                var p2 = new Point(lines[j].x, lines[j].y, lines[j].z);
                var distance = Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2) + Math.Pow(p2.Z - p1.Z, 2));
                d.Add((p1, p2, distance));
            }
        }

        d.Sort((a, b) => a.distance.CompareTo(b.distance));
        for (int i = 0; i < connections; i++)
        {
            var (p1, p2, distance) = d[i];
            var set = p[p1];

            if (set.Contains(p2)) continue;
            set.UnionWith(p[p2]);
            foreach (var item in set.Where(x => x != p1))
            {
                p[item] = set;
            }
        }

        var m = p.Values.Distinct().Select(x => x.Count).OrderByDescending(h => h).Take(3);
        total = m.Aggregate(1, (a, b) => a * b);
        return total;
    }

    public static int Part2(string[] lines)
    {
        var result = 0;
        return result;
    }
}

public readonly record struct Point
{
    public int X { get; init; }
    public int Y { get; init; }
    public int Z { get; init; }
    public Point(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}
