namespace AdventOfCode2024.Days;

internal class Day2 : Day
{
    public override string FirstHalf()
    {
        int safeReports = 0;
        foreach (var line in Input)
        {
            var values = line.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (IsSafeFH(values))
            {
                safeReports++;
            }
        }
        return safeReports.ToString();
    }

    private static bool IsSafeFH(string[] values)
    {
        bool increasing = false, decreasing = false;
        for (int i = 0; i < values.Length - 1; i++)
        {
            int currentValue = int.Parse(values[i]);
            int nextValue = int.Parse(values[i + 1]);
            if (Math.Abs(currentValue - nextValue) is 0 or > 3)
            {
                return false;
            }
            if (currentValue > nextValue)
            {
                decreasing = true;
            }
            else
            {
                increasing = true;
            }
        }
        return increasing != decreasing;
    }

    public override string SecondHalf()
    {
        return string.Empty;
    }
}