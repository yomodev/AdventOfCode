using AoC2025;
using AwesomeAssertions;
using Xunit.Abstractions;

namespace AoC2025Tests;

public class Day06Tests(ITestOutputHelper output)
{
    [Theory]
    [InlineData("Day06.0.txt", 4277556)]
    [InlineData("Day06.1.txt", 4719804927602)]
    public void Test1(string fileName, long solution)
    {
        var data = File.ReadAllLines($"TestData/{fileName}");
        var result = Day06.Part1(data);
        result.Should().Be(solution);
    }

    [Theory]
    [InlineData("Day06.0.txt", 3263827)]
    [InlineData("Day06.1.txt", 9608327000261)]
    public void Test2(string fileName, long solution)
    {
        var data = File.ReadAllLines($"TestData/{fileName}");
        var result = Day06.Part2(data);
        result.Should().Be(solution);
    }
}
