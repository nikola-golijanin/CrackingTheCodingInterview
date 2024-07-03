

namespace Chapter01_ArraysAndStrings;

public class Question04_IsPermutationOfPalindrome
{
    public static void Run()
    {
        Console.WriteLine(IsPermutationOfPalindrome("Tact Coa"));
        Console.WriteLine(IsPermutationOfPalindrome("Ana Milovana voli"));

    }

    private static bool IsPermutationOfPalindrome(string s)
    {
        s = s.ToLower();
        int[] table = BuildCharFrequencyTable(s);
        return CheckMaxOneOdd(table);
    }

    private static bool CheckMaxOneOdd(int[] table)
    {
        bool foundOdd = false;
        foreach (var count in table)
        {
            if (count % 2 == 1)
            {
                if (foundOdd)
                {
                    return false;
                }
                foundOdd = true;
            }
        }
        return true;
    }

    private static int[] BuildCharFrequencyTable(string s)
    {
        int[] table = new int['z' - 'a' + 1];
        foreach (char c in s)
        {
            int x = GetCharNumber(c);
            if (x != -1)
            {
                table[x]++;
            }
        }
        return table;
    }

    private static int GetCharNumber(char c)
    {
        int aAsInt = 'a';
        int zAsInt = 'z';
        int val = c;
        if (aAsInt <= val && val <= zAsInt)
        {
            return val - aAsInt;
        }
        return -1;
    }
}
