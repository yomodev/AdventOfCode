
namespace AoC2025;

public class Day6
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
