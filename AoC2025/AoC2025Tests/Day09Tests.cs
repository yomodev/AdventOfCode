using AoC2025;
using AwesomeAssertions;
using Xunit.Abstractions;

namespace AoC2025Tests;

public class Day09Tests(ITestOutputHelper output)
{
    [Theory]
    [InlineData("Day09.0.txt", 0)]
    [InlineData("Day09.1.txt", 0)]
    public void Test1(string fileName, int solution)
    {
        var data = File.ReadAllLines($"TestData/{fileName}");
        var result = Day09.Part1(data);
        result.Should().Be(solution);
    }

    [Theory]
    [InlineData("Day09.0.txt", 0)]
    [InlineData("Day09.1.txt", 0)]
    public void Test2(string fileName, int solution)
    {
        var data = File.ReadAllLines($"TestData/{fileName}");
        var result = Day09.Part2(data);
        result.Should().Be(solution);
    }
}
