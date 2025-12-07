namespace AoC2025;

public class Day01
{
    public static int Part1(IEnumerable<string> lines)
    {
        var pos = 50;
        var size = 100;
        var sum = 0;
        foreach (var line in lines)
        {
            var dir = line[0];
            var dist = int.Parse(line[1..]);
            pos += dist * (dir == 'L' ? -1 : 1);
            pos += pos >= size ? -size : 0;
            pos %= size;
            if (pos == 0)
            {
                sum++;
            }
        }

        return sum;
    }

    public static int Part2(IEnumerable<string> lines)
    {
        var pos = 50;
        var size = 100;
        var sum = 0;

        foreach (var line in lines)
        {
            var dir = line[0] == 'L' ? -1 : 1;
            var (div, rem) = Math.DivRem(dir * int.Parse(line.AsSpan(1)), size);
            var cur = pos + rem;
            sum += Math.Abs(div);

            if (cur <= 0)
            {
                if (pos != 0)
                {
                    sum++;
                }

                if (cur < 0)
                {
                    cur += size;
                }
            }
            else if (cur >= size)
            {
                sum++;
                cur -= size;
            }

            pos = cur;
        }

        return sum;
    }
}
