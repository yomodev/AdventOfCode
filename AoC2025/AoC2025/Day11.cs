namespace AoC2025;

public class Day11
{
    public static long Part1(string[] lines)
    {
        var devices = Parse(lines);
        var paths = Paths(devices, "you");
        return paths;
    }

    private static long Paths(
        Dictionary<string, string[]> devices,
        string current,
        string final = "out",
        Dictionary<string, long>? paths = null)
    {
        if (current == final)
        {
            return 1;
        }

        paths ??= [];
        if (paths.TryGetValue(current, out var result))
        {
            return result;
        }

        var total = 0L;
        if (devices.TryGetValue(current, out var list))
        {
            total = list
                .Sum(next => Paths(devices, next, final, paths));
        }

        paths[current] = total;

        return total;
    }

    public static long Part2(string[] lines)
    {
        var devices = Parse(lines);
        var svr_dac = Paths(devices, "svr", "dac");
        var dac_fft = Paths(devices, "dac", "fft");
        var fft_out = Paths(devices, "fft", "out");
        var svr_fft = Paths(devices, "svr", "fft");
        var fft_dac = Paths(devices, "fft", "dac");
        var dac_out = Paths(devices, "dac", "out");
        return svr_dac * dac_fft * fft_out
            + svr_fft * fft_dac * dac_out;
    }

    private static Dictionary<string, string[]> Parse(string[] lines)
    {
        return lines
            .Select(line => line.Split([':', ' '], StringSplitOptions.RemoveEmptyEntries))
            .ToDictionary(k => k[0], v => v.Skip(1).ToArray());
    }
}
