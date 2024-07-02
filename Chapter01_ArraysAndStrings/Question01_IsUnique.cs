namespace Chapter01_ArraysAndStrings;

public class Question01_IsUnique
{
    public static void Run()
    {
        string[] words = { "abcde", "hello", "apple", "kite", "padle" };
        foreach (var word in words)
        {
            Console.WriteLine("Regular v1: " + word + " is unique: " + IsUniqueCharsV1(word));
            Console.WriteLine("Regular v2: " + word + " is unique: " + IsUniqueCharsV2(word));
            Console.WriteLine("HashSet: " + word + "is unique: " + IsUniqueCharsWithHashSet(word));
            Console.WriteLine("==================================================");
        }
    }

    private static bool IsUniqueCharsV1(string s)
    {
        if (s.Length > 256) return false;
        bool[] charSet = new bool[128];
        for (int i = 0; i < s.Length; i++)
        {
            int val = s[i];
            if (charSet[val]) return false;
            charSet[val] = true;
        }

        return true;
    }

    private static bool IsUniqueCharsV2(string s)
    {
        if (s.Length > 256) return false;

        var checker = 0;

        for (int i = 0; i < s.Length; i++)
        {
            var val = s[i] - 'a';

            if ((checker & (1 << val)) > 0)
            {
                return false;
            }
            checker |= 1 << val;
        }

        return true;
    }

    private static bool IsUniqueCharsWithHashSet(string s)
    {
        var set = new HashSet<char>();
        foreach (var c in s)
        {
            if (set.Contains(c)) return false;
            set.Add(c);
        }
        return true;
    }
}
