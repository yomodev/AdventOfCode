using AoC2025;
using AwesomeAssertions;
using Xunit.Abstractions;

namespace AoC2025Tests;

public class Day02Tests(ITestOutputHelper output)
{
    [Theory]
    [InlineData("Day02.0.txt", 1227775554)]
    //[InlineData("Day02.1.txt", 23701357374)]
    public void Test1(string fileName, long solution)
    {
        var txt = File.ReadAllText($"TestData/{fileName}");
        var data = txt
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Split('-'))
            .Select(y => (long.Parse(y[0]), long.Parse(y[1])));
        var result = Day02.Part1(data);
        result.Should().Be(solution);
    }

    [Theory]
    [InlineData("Day02.0.txt", 4174379265)]
    //[InlineData("Day02.1.txt", 34284458938)]
    public void Test2(string fileName, long solution)
    {
        var txt = File.ReadAllText($"TestData/{fileName}");
        var data = txt
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Split('-'))
            .Select(y => (long.Parse(y[0]), long.Parse(y[1])));
        var result = Day02.Part2(data);
        result.Should().Be(solution);
    }
}
