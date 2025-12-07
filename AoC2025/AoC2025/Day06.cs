
namespace AoC2025;

public class Day06
{
    public static long Part1(string[] lines)
    {
        var sum = 0L;
        var ops = lines.Last().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var data = lines
            .Take(lines.Length - 1)
            .Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray())
            .ToArray();

        var results = ops.Select(x => x == "+" ? 0L : 1L).ToArray();
        for (int i = 0; i < ops.Length; i++)
        {
            var op = ops[i] == "+"
                ? (Func<long, long, long>)((long a, long b) => a + b)
                : (Func<long, long, long>)((long a, long b) => a * b);
            foreach (var item in data)
            {
                results[i] = op(results[i], item[i]);
            }
        }

        sum = results.Sum();
        return sum;
    }

    public static long Part2(string[] lines)
    {
        var sum = 0L;
        var nums = new List<long>(lines.Length - 1);
        var data = lines.Select(x => x.ToCharArray()).ToArray();

        for (int x = data.First().Length - 1; x >= 0; x--)
        {
            var line = new char[nums.Capacity];
            for (int y = 0; y < line.Length; y++)
            {
                line[y] = data[y][x];
            }

            var str = new string(line).Trim();
            if (str is [])
            {
                continue;
            }

            nums.Add(long.Parse(str));
            var op = data[^1][x];
            if (op == '+')
            {
                sum += nums.Sum();
                nums.Clear();
            }
            else if (op == '*')
            {
                sum += nums.Aggregate(1L, (a, b) => a * b);
                nums.Clear();
            }
        }

        return sum;
    }

    public static long Part2Old(string[] lines)
    {
        var sum = 0L;
        var ops = lines.Last().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var results = ops.Select(x => x == "+" ? 0L : 1L).ToArray();
        var data = lines.Take(lines.Length - 1).Select(x => x.ToCharArray()).ToArray();
        var tran = Transpose(data);

        Func<long, long, long> Op(int i) => ops[i] == "+"
                ? (Func<long, long, long>)((long a, long b) => a + b)
                : (Func<long, long, long>)((long a, long b) => a * b);

        var opi = 0;
        var op = Op(opi);
        for (int i = 0; i < tran.Length; i++)
        {
            var str = new string(tran[i]).Trim();
            if (str is [])
            {
                op = Op(++opi);
                continue;
            }

            results[opi] = op(results[opi], long.Parse(str));
        }

        sum = results.Sum();
        return sum;
    }

    private static char[][] Transpose(char[][] data)
    {
        var tran = new char[data.First().Length][];
        for (int i = 0; i < tran.Length; i++)
        {
            tran[i] = new char[data.Length];
            for (int j = 0; j < data.Length; j++)
            {
                tran[i][j] = data[j][i];
            }
        }

        return tran;
    }
}
