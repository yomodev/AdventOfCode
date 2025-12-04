namespace AoC2025;

public class Day4
{
    public static int Part1(IEnumerable<string> lines)
    {
        var matrix = lines.Select(line => line.ToCharArray()).ToArray();
        int count = ListFree(matrix).Count;
        return count;
    }

    private static List<(int x, int y)> ListFree(char[][] matrix)
    {
        List<(int x, int y)> free = [];
        int width = matrix[0].Length;
        int height = matrix.Length;
        for (int y = 0; y < matrix.Length; y++)
        {
            for (int x = 0; x < matrix[y].Length; x++)
            {
                if (IsFree(matrix, x, y, width, height))
                {
                    // Debug.WriteLine($"Free at {x},{y}");
                    free.Add((x, y));
                }
            }
        }

        return free;
    }

    public static int Part2(IEnumerable<string> lines)
    {
        var matrix = lines.Select(line => line.ToCharArray()).ToArray();
        var removed = 0;
        while (true)
        {
            var free = ListFree(matrix);
            if (free is [])
            {
                break;
            }

            foreach (var (x, y) in free)
            {
                matrix[y][x] = '.';
            }

            removed += free.Count;
        }

        return removed;
    }

    private static bool IsFree(char[][] matrix, int x, int y, int width, int height)
    {
        var roll = '@';
        if (matrix[y][x] == '.')
        {
            return false;
        }

        bool[] test =
        {
            x - 1 >= 0 && y - 1 >= 0 && matrix[y - 1][x - 1] == roll, // top-left
            y - 1 >= 0 && matrix[y - 1][x] == roll, // top
            x + 1 < width && y - 1 >= 0 && matrix[y - 1][x + 1] == roll, // top-right
            x - 1 >= 0 && matrix[y][x - 1] == roll, // left
            x + 1 < width && matrix[y][x + 1] == roll, // right
            x - 1 >= 0  && y + 1 < height && matrix[y + 1][x - 1] == roll, // bottom-left
            y + 1 < height && matrix[y + 1][x] == roll, // bottom-center
            x + 1 < width && y + 1 < height && matrix[y + 1][x + 1] == roll, // bottom-right
        };

        var result = test.Count(x => x) < 4;
        return result;
    }
}
