using AoC2025;
using AwesomeAssertions;
using Xunit.Abstractions;

namespace AoC2025Tests;

public class Day04Tests(ITestOutputHelper output)
{
    [Theory]
    [InlineData("Day04.0.txt", 13)]
    //[InlineData("Day04.1.txt", 1467)]
    public void Test1(string fileName, int solution)
    {
        var lines = File.ReadLines($"TestData/{fileName}");
        var result = Day04.Part1(lines);
        result.Should().Be(solution);
    }

    [Theory]
    [InlineData("Day04.0.txt", 43)]
    //[InlineData("Day04.1.txt", 8484)]
    public void Test2(string fileName, int solution)
    {
        var lines = File.ReadLines($"TestData/{fileName}");
        var result = Day04.Part2(lines);
        result.Should().Be(solution);
    }
}
