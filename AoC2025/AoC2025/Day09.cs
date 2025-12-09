using System.Collections.Generic;
using System.Reflection;

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

    public static long Part2(IEnumerable<(int x, int y)> data)
    {
        var s = data.ToList();
        var border = CreateBorder(s);
        var list = new List<(long area, (int x, int y) p1, (int x, int y) p2)>();

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
                list.Add((area, s[i], s[j]));
            }
        }

        list.Sort((a, b) => -a.area.CompareTo(b.area));
        foreach (var (area, p1, p2) in list)
        {
            if (Contains(border, p1, p2))
            {
                return area;
            }
        }

        throw new InvalidOperationException("something wrong");
    }

    public static long Part2X(IEnumerable<(int x, int y)> data)
    {
        long max = 0;
        var s = data.ToList();
        var (vv, hh) = CreateLines(s);

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
                if (area < max)
                {
                    continue;
                }

                var top = Math.Min(s[i].y, s[j].y);
                var bottom = Math.Max(s[i].y, s[j].y);
                var left = Math.Min(s[i].x, s[j].x);
                var right = Math.Max(s[i].x, s[j].x);

                if (CheckHorizontal(vv, top, left, right, bottom)
                    &&
                    CheckVertical(hh, top, left, right, bottom))
                {
                    max = area;
                }
            }
        }

        return max;
    }

    private static bool Contains(HashSet<(int x, int y)> border, (int x, int y) p1, (int x, int y) p2)
    {
        var top = Math.Min(p1.y, p2.y);
        var bottom = Math.Max(p1.y, p2.y);
        var left = Math.Min(p1.x, p2.x);
        var right = Math.Max(p1.x, p2.x);

        foreach (var p in border)
        {
            if (p.x > left && p.x < right && p.y > top && p.y < bottom)
            {
                return false;
            }
        }

        return true;
    }

    private static HashSet<(int x, int y)> CreateBorder(List<(int x, int y)> s)
    {
        var set = new HashSet<(int x, int y)>();
        var prev = s[0];
        for (int i = 1; i <= s.Count; i++)
        {
            var cur = i == s.Count ? s[0] : s[i];
            var x1 = Math.Min(prev.x, cur.x);
            var x2 = Math.Max(prev.x, cur.x);
            var y1 = Math.Min(prev.y, cur.y);
            var y2 = Math.Max(prev.y, cur.y);
            for (int x = x1; x <= x2; x++)
            {
                for (int y = y1; y <= y2; y++)
                {
                    set.Add((x, y));
                }
            }

            prev = cur;
        }

        return set;
    }

    private static (
        IDictionary<int, List<(int y1, int y2)>> vv,
        IDictionary<int, List<(int x1, int x2)>> hh)
        CreateLines(List<(int x, int y)> s)
    {
        var vv = new SortedDictionary<int, List<(int y1, int y2)>>();
        var hh = new SortedDictionary<int, List<(int x1, int x2)>>();
        for (int i = 0; i < s.Count - 1; i++)
        {
            for (int j = i + 1; j < s.Count; j++)
            {
                var p1 = s[i];
                var p2 = s[j];
                if (p1.x == p2.x)
                {
                    var x = p1.x;
                    var t = p1.y < p2.y ? (p1.y, p2.y) : (p2.y, p1.y);
                    if (vv.TryGetValue(x, out var l))
                    {
                        l.Add(t);
                        continue;
                    }

                    vv[x] = [t];
                }
                else if (p1.y == p2.y)
                {
                    var y = p2.y;
                    var t = p1.x < p2.x ? (p1.x, p2.x) : (p2.x, p1.x);
                    if (hh.TryGetValue(y, out var l))
                    {
                        l.Add(t);
                        continue;
                    }

                    hh[y] = [t];
                }
            }
        }

        return (vv, hh);
    }

    private static bool CheckVertical(
        IDictionary<int, List<(int x1, int x2)>> hh,
        int top, int left, int right, int bottom)
    {
        foreach (var rows in hh.Where(kvp => kvp.Key > bottom && kvp.Key < top))
        {
            if (rows.Value.Any(r =>
                (r.x1 > left && r.x1 < right)
                ||
                (r.x2 > left && r.x2 < right)
                ||
                (left > r.x1 && right < r.x2)))
            {
                return false;
            }
        }

        return true;
    }

    private static bool CheckHorizontal(
        IDictionary<int, List<(int y1, int y2)>> vv,
        int top, int left, int right, int bottom)
    {
        foreach (var columns in vv.Where(kvp => kvp.Key > left && kvp.Key < right))
        {
            if (columns.Value.Any(c =>
                (c.y1 > top && c.y1 < bottom)
                ||
                (c.y2 > top && c.y2 < bottom)
                ||
                (top > c.y1 && bottom < c.y2)))
            {
                return false;
            }
        }

        return true;
    }
}
