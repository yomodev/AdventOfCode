using AoC2025;
using AwesomeAssertions;
using Xunit.Abstractions;

namespace AoC2025Tests;

public class Day01Tests(ITestOutputHelper output)
{
    [Theory]
    [InlineData("Day01.0.txt", 3)]
    //[InlineData("Day01.1.txt", 1066)]
    public void Test1(string fileName, int solution)
    {
        var lines = File.ReadLines($"TestData/{fileName}");
        var result = Day01.Part1(lines);
        result.Should().Be(solution);
    }

    [Theory]
    [InlineData("Day01.0.txt", 6)]
    //[InlineData("Day01.1.txt", 6223)]
    public void Test2(string fileName, int solution)
    {
        var lines = File.ReadLines($"TestData/{fileName}");
        var result = Day01.Part2(lines);
        result.Should().Be(solution);
    }
}
