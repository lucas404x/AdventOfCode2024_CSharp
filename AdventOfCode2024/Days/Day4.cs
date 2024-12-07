namespace AdventOfCode2024.Days;

internal class Day4 : Day
{
    private const int XmasSize = 4;
    private const int masSize = 3;
    
    public override string FirstHalf()
    {
        int xmasCounter = 0;
        int heightBoundary = Input.Length - XmasSize;
        int widthBoundary = Input[0].Length - XmasSize;
        for (int i = 0; i < Input.Length; i++)
        {
            for (int j = 0; j < Input[i].Length; j++)
            {
                if (Input[i][j] != 'X') continue; 
                HashSet<char> letters = [];
                if (i + 1 >= XmasSize) // up
                {
                    letters.Add(Input[i][j]);
                    letters.Add(Input[i - 1][j]);
                    letters.Add(Input[i - 2][j]);
                    letters.Add(Input[i - 3][j]);
                    if (IsValid(letters)) xmasCounter++;
                    letters.Clear();
                }
                if (i <= heightBoundary) // down
                {
                    letters.Add(Input[i][j]);
                    letters.Add(Input[i + 1][j]);
                    letters.Add(Input[i + 2][j]);
                    letters.Add(Input[i + 3][j]);
                    if (IsValid(letters)) xmasCounter++;
                    letters.Clear();
                }
                if (j + 1 >= XmasSize) // left
                {
                    letters.Add(Input[i][j]);
                    letters.Add(Input[i][j - 1]);
                    letters.Add(Input[i][j - 2]);
                    letters.Add(Input[i][j - 3]);
                    if (IsValid(letters)) xmasCounter++;
                    letters.Clear();
                    
                    if (i + 1 >= XmasSize) // up
                    {
                        letters.Add(Input[i][j]);
                        letters.Add(Input[i - 1][j - 1]);
                        letters.Add(Input[i - 2][j - 2]);
                        letters.Add(Input[i - 3][j - 3]);
                        if (IsValid(letters)) xmasCounter++;
                        letters.Clear();
                    }
                    
                    if (i <= heightBoundary) // down
                    {
                        letters.Add(Input[i][j]);
                        letters.Add(Input[i + 1][j - 1]);
                        letters.Add(Input[i + 2][j - 2]);
                        letters.Add(Input[i + 3][j - 3]);
                        if (IsValid(letters)) xmasCounter++;
                        letters.Clear();
                    }
                }
                if (j <= widthBoundary) // right
                {
                    letters.Add(Input[i][j]);
                    letters.Add(Input[i][j + 1]);
                    letters.Add(Input[i][j + 2]);
                    letters.Add(Input[i][j + 3]);
                    if (IsValid(letters)) xmasCounter++;
                    letters.Clear();

                    if (i + 1 >= XmasSize) // up
                    {
                        letters.Add(Input[i][j]);
                        letters.Add(Input[i - 1][j + 1]);
                        letters.Add(Input[i - 2][j + 2]);
                        letters.Add(Input[i - 3][j + 3]);
                        if (IsValid(letters)) xmasCounter++;
                        letters.Clear();
                    }
                    
                    if (i <= heightBoundary) // down
                    {
                        letters.Add(Input[i][j]);
                        letters.Add(Input[i + 1][j + 1]);
                        letters.Add(Input[i + 2][j + 2]);
                        letters.Add(Input[i + 3][j + 3]);
                        if (IsValid(letters)) xmasCounter++;
                        letters.Clear();
                    }
                }
            }
        }
        return xmasCounter.ToString();
    }

    private static bool IsValid(HashSet<char> letters)
    {
        if (letters.Count != XmasSize) return false;
        var str = string.Join(string.Empty, letters);
        return str is "XMAS" or "SAMX";
    }
    
    public override string SecondHalf()
    {
        int masCounter = 0;
        for (int i = 1; i < Input.Length - 1; i++)
        {
            for (int j = 1; j < Input[i].Length - 1; j++)
            {
                if (Input[i][j] != 'A') continue; 
                HashSet<char> letters = [];
                HashSet<char> letters2 = [];
                
                letters.Add(Input[i - 1][j + 1]);
                letters.Add(Input[i][j]);
                letters.Add(Input[i + 1][j - 1]);

                if (IsValidMas(letters))
                {
                    letters2.Add(Input[i - 1][j - 1]);
                    letters2.Add(Input[i][j]);
                    letters2.Add(Input[i + 1][j + 1]);
                    if (IsValidMas(letters2)) masCounter++;
                }
                letters.Clear();
                letters2.Clear();
            }
        }
        return masCounter.ToString();
    }
    
    private static bool IsValidMas(HashSet<char> letters)
    {
        if (letters.Count != masSize) return false;
        var str = string.Join(string.Empty, letters);
        return str[1] == 'A' && !str.Contains('X');
    }
}