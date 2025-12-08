using AoC2025;
using AwesomeAssertions;
using Xunit.Abstractions;

namespace AoC2025Tests;

public class Day10Tests(ITestOutputHelper output)
{
    [Theory]
    [InlineData("Day10.0.txt", 0)]
    [InlineData("Day10.1.txt", 0)]
    public void Test1(string fileName, int solution)
    {
        var data = File.ReadAllLines($"TestData/{fileName}");
        var result = Day10.Part1(data);
        result.Should().Be(solution);
    }

    [Theory]
    [InlineData("Day10.0.txt", 0)]
    [InlineData("Day10.1.txt", 0)]
    public void Test2(string fileName, int solution)
    {
        var data = File.ReadAllLines($"TestData/{fileName}");
        var result = Day10.Part2(data);
        result.Should().Be(solution);
    }
}
