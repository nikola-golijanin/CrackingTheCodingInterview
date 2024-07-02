namespace Chapter01_ArraysAndStrings;

public class Question02_CheckPermutation
{
    public static void Run()
    {
        var (s1, s2) = ("abcde", "edcba");
        Console.WriteLine($"CheckPermutationV1   Is {s1} a permutation of {s2}: {CheckPermutationV1(s1, s2)}");
        Console.WriteLine($"CheckPermutationV2   Is {s1} a permutation of {s2}: {CheckPermutationV2(s1, s2)}");

        Console.WriteLine("================================================================");


        var (s11, s22) = ("hello", "world");
        Console.WriteLine($"CheckPermutationV1   Is {s11} a permutation of {s22}: {CheckPermutationV1(s11, s22)}");
        Console.WriteLine($"CheckPermutationV2   Is {s11} a permutation of {s22}: {CheckPermutationV2(s11, s22)}");

        Console.WriteLine("================================================================");

        var (s13, s23) = ("nikola", "golijanin");
        Console.WriteLine($"CheckPermutationV1   Is {s13} a permutation of {s23}: {CheckPermutationV1(s13, s23)}");
        Console.WriteLine($"CheckPermutationV2   Is {s13} a permutation of {s23}: {CheckPermutationV1(s13, s23)}");
    }

    private static bool CheckPermutationV1(string s1, string s2)
    {
        if (s1.Length != s2.Length) return false;
        return Sort(s1) == Sort(s2);
    }

    private static readonly Func<string, string> Sort = (s) =>
    {
        var content = s.ToCharArray();
        Array.Sort(content);
        return new string(content);
    };

    public static bool CheckPermutationV2(string s1, string s2)
    {
        if (s1.Length != s2.Length) return false;
        var letters = new int[128];
        for (int i = 0; i < s1.Length; i++)
        {
            letters[s1[i]]++;
        }

        for (int i = 0; i < s2.Length; i++)
        {
            letters[s2[i]]--;
            if (letters[s2[i]] < 0)
            {
                return false;
            }
        }
        return true;
    }
}
