namespace Chapter01_ArraysAndStrings;

public class Question05_OneAway
{
    public static void Run()
    {
        Console.WriteLine("===================== IsOneEditAwayV1 =====================");

        Console.WriteLine($"{IsOneEditAwayV1("pale", "ple")}");
        Console.WriteLine($"{IsOneEditAwayV1("pales", "pale")}");
        Console.WriteLine($"{IsOneEditAwayV1("pale", "bale")}");
        Console.WriteLine($"{IsOneEditAwayV1("pale", "bake")}");

        Console.WriteLine("===================== IsOneEditAwayV2 =====================");

        Console.WriteLine($"{IsOneEditAwayV2("pale", "ple")}");
        Console.WriteLine($"{IsOneEditAwayV2("pales", "pale")}");
        Console.WriteLine($"{IsOneEditAwayV2("pale", "bale")}");
        Console.WriteLine($"{IsOneEditAwayV2("pale", "bake")}");
    }

    private static bool IsOneEditAwayV1(string first, string second)
    {

        var editDistance = Math.Abs(first.Length - second.Length);
        if (editDistance > 1) return false;

        var diff = first.Length - second.Length;
        return diff switch
        {
            0 => OneEditReplace(first, second),
            -1 => OneEditInsert(first, second),
            1 => OneEditInsert(second, first),
            _ => false,
        };
    }

    private static bool OneEditReplace(string s1, string s2)
    {
        var foundDiff = false;

        for (int i = 0; i < s1.Length; i++)
        {
            if (s1[i] != s2[i])
            {
                if (foundDiff) return false;
                foundDiff = true;
            }
        }
        return true;
    }

    public static bool OneEditInsert(string shorter, string longer)
    {
        var shorterIndex = 0;
        var longerIndex = 0;
        while (shorterIndex < shorter.Length && longerIndex < longer.Length)
        {
            if (shorter[shorterIndex] != longer[longerIndex])
            {
                if (shorterIndex != longerIndex)
                {
                    return false;
                }
                longerIndex++;
            }
            else
            {
                shorterIndex++;
                longerIndex++;
            }
        }
        return true;
    }

    private static bool IsOneEditAwayV2(string first, string second)
    {

        var editDistance = Math.Abs(first.Length - second.Length);
        if (editDistance > 1) return false;

        (string shorter, string longer) = first.Length < second.Length ?
                                                               (first, second) :
                                                               (second, first);

        var shorterIndex = 0;
        var longerIndex = 0;
        var foundDiff = false;
        while (shorterIndex < shorter.Length && longerIndex < longer.Length)
        {
            if (shorter[shorterIndex] != longer[longerIndex])
            {
                if (foundDiff) return false;
                foundDiff = true;

                if (editDistance == 0)
                    shorterIndex++;
            }
            else
            {
                shorterIndex++;
            }
            longerIndex++;
        }
        return true;
    }
}
