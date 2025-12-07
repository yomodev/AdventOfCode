using AoC2025;
using AwesomeAssertions;
using Xunit.Abstractions;

namespace AoC2025Tests;

public class Day7Tests(ITestOutputHelper output)
{
    [Theory]
    [InlineData("Day7.0.txt", 21)]
    [InlineData("Day7.1.txt", 1630)]
    public void Test1(string fileName, int solution)
    {
        var data = File.ReadAllLines($"TestData/{fileName}");
        var result = Day7.Part1(data);
        result.Should().Be(solution);
    }

    [Theory]
    [InlineData("Day7.0.txt", 0)]
    [InlineData("Day7.1.txt", 0)]
    public void Test2(string fileName, int solution)
    {
        var data = File.ReadAllLines($"TestData/{fileName}");
        var result = Day7.Part2(data);
        result.Should().Be(solution);
    }
}
