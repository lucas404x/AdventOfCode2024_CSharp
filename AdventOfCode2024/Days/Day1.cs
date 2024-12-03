namespace AdventOfCode2024.Days;

internal class Day1 : Day
{
    public override string FirstHalf()
    {
        List<int> left = [], right = [];

        foreach (var line in Input)
        {
            var values = line.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            left.Add(int.Parse(values[0]));
            right.Add(int.Parse(values[1]));
        }
        
        left.Sort();
        right.Sort();

        var accumulator = 0;
        for (int i = 0; i < left.Count; i++)
        {
            accumulator += Math.Abs(left[i] - right[i]);
        }
        
        return accumulator.ToString();
    }

    public override string SecondHalf()
    {
        List<int> left = [];
        Dictionary<int, int> rightLocationOccurrences = [];
        
        
        foreach (var line in Input)
        {
            var values = line.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            int leftValue = int.Parse(values[0]);
            int rightValue = int.Parse(values[1]);
            
            left.Add(leftValue);
            if (!rightLocationOccurrences.TryAdd(rightValue, 1))
            {
                rightLocationOccurrences[rightValue]++;
            }
        }

        return left.
            Sum(x =>
            {
                if (rightLocationOccurrences.TryGetValue(x, out int count))
                {
                    return x * count;
                }
                return 0;
            }).
            ToString();
    }
}