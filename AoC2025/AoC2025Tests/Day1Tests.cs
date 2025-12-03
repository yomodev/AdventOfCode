using AoC2025;
using AwesomeAssertions;
using Xunit.Abstractions;

namespace AoC2025Tests;

public class Day1Tests(ITestOutputHelper output)
{
    [Theory]
    [InlineData("Day1.0.txt", 3)]
    [InlineData("Day1.1.txt", 1066)]
    public void Test1(string fileName, int solution)
    {
        var lines = File.ReadAllLines($"TestData/{fileName}");
        var result = Day1.Part1(lines);
        result.Should().Be(solution);
    }

    [Theory]
    [InlineData("Day1.0.txt", 6)]
    [InlineData("Day1.1.txt", 6223)]
    public void Test2(string fileName, int solution)
    {
        var lines = File.ReadAllLines($"TestData/{fileName}");
        var result = Day1.Part2(lines);
        result.Should().Be(solution);
    }
}
