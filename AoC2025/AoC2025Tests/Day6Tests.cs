using AoC2025;
using AwesomeAssertions;
using Xunit.Abstractions;

namespace AoC2025Tests;

public class Day6Tests(ITestOutputHelper output)
{
    [Theory]
    [InlineData("Day6.0.txt", 4277556)]
    [InlineData("Day6.1.txt", 4719804927602)]
    public void Test1(string fileName, long solution)
    {
        var data = File.ReadAllLines($"TestData/{fileName}");
        var result = Day6.Part1(data);
        result.Should().Be(solution);
    }

    [Theory]
    [InlineData("Day6.0.txt", 3263827)]
    [InlineData("Day6.1.txt", 9608327000261)]
    public void Test2(string fileName, long solution)
    {
        var data = File.ReadAllLines($"TestData/{fileName}");
        var result = Day6.Part2(data);
        result.Should().Be(solution);
    }
}
