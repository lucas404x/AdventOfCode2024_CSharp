using System.Text.RegularExpressions;

namespace AdventOfCode2024.Days;

internal partial class Day3 : Day
{
    [GeneratedRegex(@"mul\(\d+\,\d+\)")]
    private static partial Regex MulFinderRegex();
    
    [GeneratedRegex(@"(mul\(\d+\,\d+\))|(?'name'do(\(\)))|(?'name'don't(\(\)))")]
    private static partial Regex MultipleInstructionFinderRegex();
    
    [GeneratedRegex(@"\d+")]
    private static partial Regex DigitMulFinderRegex();
    
    public override string FirstHalf()
    {
        var memory = string.Join(string.Empty, Input);
        return MulFinderRegex().Matches(memory)
            .Select(m => ParseMulInstruction(m.Value))
            .Sum()
            .ToString();
    }

    private static long ParseMulInstruction(string instruction)
    {
        var matches = DigitMulFinderRegex().Matches(instruction);
        return long.Parse(matches[0].Value) * long.Parse(matches[1].Value);
    }

    public override string SecondHalf()
    {
        var memory = string.Join(string.Empty, Input);
        var instructions = MultipleInstructionFinderRegex().Matches(memory);
        long sum = 0;
        bool enabled = true;
        foreach (Match instruction in instructions)
        {
            switch (instruction.Value)
            {
                case "do()":
                    enabled = true;
                    break;
                case "don't()":
                    enabled = false;
                    break;
                default:
                    if (enabled)
                    {
                        sum += ParseMulInstruction(instruction.Value);
                    }
                    break;
            }
        }
        return sum.ToString();
    }
}