using AoC2025;
using AwesomeAssertions;
using Xunit.Abstractions;

namespace AoC2025Tests;

public class Day09Tests(ITestOutputHelper output)
{
    [Theory]
    [InlineData("Day09.0.txt", 50)]
    //[InlineData("Day09.1.txt", 4741451444)]
    public void Test1(string fileName, long solution)
    {
        var data = Parse(fileName);
        var result = Day09.Part1(data);
        result.Should().Be(solution);
    }

    [Theory]
    [InlineData("Day09.0.txt", 24)]
    [InlineData("Day09.1.txt", 1562459680)]
    public void Test2(string fileName, long solution)
    {
        var data = Parse(fileName);
        var result = Day09.Part2(data);
        result.Should().Be(solution);
    }

    private static IEnumerable<(int, int)> Parse(string fileName)
    {
        return File.ReadLines($"TestData/{fileName}")
            .Select(x => x.Split(','))
            .Select(n => (int.Parse(n[0]), int.Parse(n[1])));
    }
}
