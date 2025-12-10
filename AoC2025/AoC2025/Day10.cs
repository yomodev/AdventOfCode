namespace AoC2025;

public class Day10
{
    public static int Part1(string[] lines)
    {
        var sum = lines.Select(Parse).Select(Solve).Sum();
        return sum;
    }

    private static int Solve((string lights, string[] buttons, int[] joltage) tuple)
    {
        var queue = new Queue<(string state, int steps)>();
        queue.Enqueue((new string('0', tuple.lights.Length), 0));
        var visited = new HashSet<string>();
        while (queue.Count > 0)
        {
            var (curr, steps) = queue.Dequeue();
            if (curr == tuple.lights)
            {
                return steps;
            }

            foreach (var btn in tuple.buttons)
            {
                var next = Xor(curr, btn);
                if (!visited.Contains(next))
                {
                    visited.Add(next);
                    queue.Enqueue((next, steps + 1));
                }
            }
        }

        return 0;
    }

    private static string Xor(string a, string b)
    {
        var size = a.Length;
        var chars = new char[size];
        for (int i = 0; i < size; i++)
        {
            chars[i] = a[i] != b[i] ? '1' : '0';
        }

        return new string(chars);
    }

    private static (string lights, string[] buttons, int[] joltage) Parse(string line)
    {
        var size = 0;
        string lights = string.Empty;
        List<string> buttons = [];
        int[] joltage = [];

        //[.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}
        foreach (var item in line.Split(' '))
        {
            if (item[0] == '[')
            {
                var l = item.Trim('[', ']').ToCharArray();
                size = l.Length;
                lights = new string([.. l.Select(c => c == '#' ? '1' : '0')]);
            }
            else if (item[0] == '(')
            {
                int[] nums = [.. item.Trim('(', ')').Split(',').Select(int.Parse)];
                var wires = new string('0', size).ToCharArray();
                foreach (var index in nums)
                {
                    wires[index] = '1';
                }

                buttons.Add(new string(wires));
            }
            else if (item[0] == '{')
            {
                joltage = [.. item.Trim('{', '}').Split(',').Select(int.Parse)];
            }
        }

        return (lights, buttons.ToArray(), joltage);
    }

    public static int Part2(string[] lines)
    {
        var result = 0;
        return result;
    }
}
