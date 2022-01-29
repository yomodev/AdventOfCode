using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021Lib
{
    public class Day03
    {
        public int Part1(IEnumerable<string> list)
        {
            var bin = string.Join(null, Enumerable
                .Range(0, list.First().Length)
                .Select(c => Common(list, c, invert: false)));

            var gamma = Convert.ToInt32(bin, 2);
            var epsilon = Convert.ToInt32(Negate(bin), 2);
            return gamma * epsilon;
        }

        public int Part2(IEnumerable<string> list)
        {
            var oxygenGenerator = CalculateRating(list, invert: false);
            var CO2Scrubber = CalculateRating(list, invert: true);
            return oxygenGenerator * CO2Scrubber;
        }

        private int CalculateRating(IEnumerable<string> list, bool invert)
        {
            var column = 0;
            do
            {
                var common = Common(list, column, invert);
                list = Filter(list, column, common).ToList();
                column++;
            }
            while (list.Count() > 1);
            return Convert.ToInt32(list.First(), 2);
        }

        public IEnumerable<string> Filter(IEnumerable<string> list, int column, char value)
        {
            return list.Where(x => x[column] == value);
        }

        public char Common(IEnumerable<string> list, int column, bool invert)
        {
            var avg = list.Average(x => x[column] - '0');
            char result = avg >= .5 ? '0' : '1';
            return invert ? Negate(result) : result;
        }

        public string Negate(string input)
        {
            return string.Join(null, input.Select(Negate));
        }

        public char Negate(char input)
        {
            return input == '0' ? '1' : '0';
        }
    }
}
