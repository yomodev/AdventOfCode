using AoC2025;
using AwesomeAssertions;
using Xunit.Abstractions;

namespace AoC2025Tests;

public class Day07Tests(ITestOutputHelper output)
{
    [Theory]
    [InlineData("Day07.0.txt", 21)]
    //[InlineData("Day07.1.txt", 1630)]
    public void Test1(string fileName, int solution)
    {
        var data = File.ReadAllLines($"TestData/{fileName}");
        var result = Day07.Part1(data);
        result.Should().Be(solution);
    }

    [Theory]
    [InlineData("Day07.0.txt", 40)]
    //[InlineData("Day07.1.txt", 47857642990160)]
    public void Test2(string fileName, long solution)
    {
        var data = File.ReadAllLines($"TestData/{fileName}");
        var result = Day07.Part2(data);
        result.Should().Be(solution);
    }
}
