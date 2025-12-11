using AoC2025;
using AwesomeAssertions;
using Xunit.Abstractions;

namespace AoC2025Tests;

public class Day11Tests(ITestOutputHelper output)
{
    [Theory]
    [InlineData("Day11.0.txt", 5)]
    //[InlineData("Day11.1.txt", 477)]
    public void Test1(string fileName, long solution)
    {
        var data = File.ReadAllLines($"TestData/{fileName}");
        var result = Day11.Part1(data);
        result.Should().Be(solution);
    }

    [Theory]
    [InlineData("Day11.2.txt", 2)]
    //[InlineData("Day11.1.txt", 383307150903216)]
    public void Test2(string fileName, long solution)
    {
        var data = File.ReadAllLines($"TestData/{fileName}");
        var result = Day11.Part2(data);
        result.Should().Be(solution);
    }
}
