using AoC2025;
using AwesomeAssertions;
using Xunit.Abstractions;

namespace AoC2025Tests;

public class Day4Tests(ITestOutputHelper output)
{
    [Theory]
    [InlineData("Day4.0.txt", 13)]
    [InlineData("Day4.1.txt", 1467)]
    public void Test1(string fileName, int solution)
    {
        var lines = File.ReadLines($"TestData/{fileName}");
        var result = Day4.Part1(lines);
        result.Should().Be(solution);
    }

    [Theory]
    [InlineData("Day4.0.txt", 43)]
    [InlineData("Day4.1.txt", 0)]
    public void Test2(string fileName, int solution)
    {
        var lines = File.ReadLines($"TestData/{fileName}");
        var result = Day4.Part2(lines);
        result.Should().Be(solution);
    }
}
