using AoC2025;
using AwesomeAssertions;
using Xunit.Abstractions;

namespace AoC2025Tests;

public class Day05Tests(ITestOutputHelper output)
{
    [Theory]
    [InlineData("Day05.0.txt", 3)]
    //[InlineData("Day05.1.txt", 698)]
    public void Test1(string fileName, int solution)
    {
        var (ranges, values) = ReadInput(fileName);
        var result = Day05.Part1(ranges, values);
        result.Should().Be(solution);
    }

    [Theory]
    [InlineData("Day05.0.txt", 14)]
    //[InlineData("Day05.1.txt", 352807801032167)]
    public void Test2(string fileName, long solution)
    {
        var (ranges, values) = ReadInput(fileName);
        var result = Day05.Part2(ranges.ToList());
        result.Should().Be(solution);
    }

    private static ((long start, long end)[] ranges, long[] values)
        ReadInput(string fileName)
    {
        var text = File
            .ReadAllText($"TestData/{fileName}")
            .Split(
                Environment.NewLine + Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        var ranges = text.First()
            .Split(Environment.NewLine)
            .Select(line => line.Split('-'))
            .Select(r => (start: long.Parse(r[0]), end: long.Parse(r[1])))
            .ToArray();
        var values = text.Last()
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse)
            .ToArray();

        return (ranges, values);
    }
}
