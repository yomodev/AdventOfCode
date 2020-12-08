using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020CS
{
    class Day04
    {
        
        public static void Test1(string filePath)
        {
            var req = new HashSet<string>("byr iyr eyr hgt hcl ecl pid cid".Split(' '));
            req.Remove("cid");

            var result = Aggregate(File.ReadLines(filePath))
                .Select(x => x.Split(' ', ':').Where((s, i) => i % 2 == 0))
                .Select(x => new HashSet<string>(x))
                .Where(x => req.Intersect(x).Count() == req.Count())
                .Count();
            //.ToList().ForEach(x=>Console.WriteLine(string.Join('-',x)));

            Console.WriteLine(result);
        }

        public static void Test2(string filePath)
        {
            var req = new HashSet<string>("byr iyr eyr hgt hcl ecl pid cid".Split(' '));
            req.Remove("cid");

            var result = File.ReadAllText(filePath).Split("\r\n\r\n").Select(x => x.Replace("\r\n", " ").Trim())
                .Select(x => x.Split(' ').ToDictionary(k => k.Split(':')[0], v => v.Split(':')[1]))
                .Where(x => req.Except(x.Keys).Count() == 0)
                // byr(Birth Year) - four digits; at least 1920 and at most 2002.
                .Where(x => int.TryParse(x["byr"], out int byr) && byr >= 1920 && byr <= 2002)
                // iyr(Issue Year) - four digits; at least 2010 and at most 2020.
                .Where(x => int.TryParse(x["iyr"], out int iyr) && iyr >= 2010 && iyr <= 2020)
                // eyr(Expiration Year) - four digits; at least 2020 and at most 2030.
                .Where(x => int.TryParse(x["eyr"], out int eyr) && eyr >= 2020 && eyr <= 2030)
                // hgt(Height) - a number followed by either cm or in:
                //     If cm, the number must be at least 150 and at most 193.
                .Where(x => (x["hgt"].EndsWith("cm") && int.TryParse(x["hgt"].Replace("cm", ""), out int cm) && cm >= 150 && cm <= 193)
                //     If in, the number must be at least 59 and at most 76.
                    || (x["hgt"].EndsWith("in") && int.TryParse(x["hgt"].Replace("in", ""), out int inc) && inc >= 59 && inc <= 76))
                // hcl(Hair Color) - a # followed by exactly six characters 0-9 or a-f.
                .Where(x => Regex.Match(x["hcl"], "^#[0-9a-f]{6}$").Success)
                // ecl(Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
                .Where(x => new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(x["ecl"]))
                // pid(Passport ID) - a nine - digit number, including leading zeroes.
                .Where(x => x["pid"].Length == 9 && long.TryParse(x["pid"], out long pid) && pid > 0 && pid < 999999999)
                .Count();
            Console.WriteLine(result);
        }

        private static IEnumerable<string> Aggregate(IEnumerable<string> enumerable)
        {
            var buf = new StringBuilder();
            foreach (var item in enumerable)
            {
                if (item.Length == 0)
                {
                    yield return buf.ToString().Trim();
                    buf.Clear();
                }
                else
                {
                    buf.Append(item);
                    buf.Append(' ');
                }
            }

            if (buf.Length > 0)
                yield return buf.ToString().Trim();
        }
    }

}
