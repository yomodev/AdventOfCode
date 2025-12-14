using AoC2025;
using AwesomeAssertions;
using Xunit.Abstractions;

namespace AoC2025Tests;

public class Day12Tests(ITestOutputHelper output)
{
    /*[Theory]
    [InlineData("Day12.0.txt", 2)]
    [InlineData("Day12.1.txt", 536)]
    public void Test1(string fileName, int solution)
    {
        var data = File.ReadAllText($"TestData/{fileName}");
        var result = Day12.Part1(data);
        result.Should().Be(solution);
    }*/

    [Theory]
    [InlineData("Day12.0.txt", 0)]
    [InlineData("Day12.1.txt", 0)]
    public void Test2(string fileName, int solution)
    {
        var data = File.ReadAllText($"TestData/{fileName}");
        var result = Day12.Part2(data);
        result.Should().Be(solution);
    }
}
