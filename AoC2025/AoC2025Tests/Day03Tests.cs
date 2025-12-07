using AoC2025;
using AwesomeAssertions;
using Xunit.Abstractions;

namespace AoC2025Tests;

public class Day03Tests(ITestOutputHelper output)
{
    [Theory]
    [InlineData("Day03.0.txt", 357)]
    [InlineData("Day03.1.txt", 17109)]
    public void Test1(string fileName, int solution)
    {
        var lines = File.ReadLines($"TestData/{fileName}");
        var result = Day03.Part1(lines);
        result.Should().Be(solution);
    }

    [Theory]
    [InlineData("Day03.0.txt", 3121910778619)]
    [InlineData("Day03.1.txt", 169347417057382)]
    public void Test2(string fileName, long solution)
    {
        var lines = File.ReadLines($"TestData/{fileName}");
        var result = Day03.Part2(lines);
        result.Should().Be(solution);
    }
}
