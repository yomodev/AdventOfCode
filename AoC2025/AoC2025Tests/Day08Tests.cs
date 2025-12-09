using AoC2025;
using AwesomeAssertions;
using Xunit.Abstractions;

namespace AoC2025Tests;

public class Day08Tests(ITestOutputHelper output)
{
    [Theory]
    [InlineData("Day08.0.txt", 10, 40)]
    //[InlineData("Day08.1.txt", 1000, 57564)]
    public void Test1(string fileName, int connections, int solution)
    {
        var data = Parse(fileName);
        var result = Day08.Part1(data, connections);
        result.Should().Be(solution);
    }

    [Theory]
    [InlineData("Day08.0.txt", 25272)]
    //[InlineData("Day08.1.txt", 133296744)]
    public void Test2(string fileName, int solution)
    {
        var data = Parse(fileName);
        var result = Day08.Part2(data);
        result.Should().Be(solution);
    }

    private static List<(int, int, int)> Parse(string fileName)
    {
        return [.. File
            .ReadLines($"TestData/{fileName}")
            .Select(x => x.Split(','))
            .Select(n => (int.Parse(n[0]), int.Parse(n[1]), int.Parse(n[2])))];
    }
}
