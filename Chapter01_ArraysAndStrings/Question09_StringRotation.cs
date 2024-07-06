namespace Chapter01_ArraysAndStrings;

public class Question09_StringRotation
{
    public static void Run()
    {
        string s1 = "waterbottle";
        string s2 = "erbottlewat";

        Console.WriteLine($"IsRotation: {IsRotation(s1, s2)}");
    }

    private static bool IsRotation(string s1, string s2)
    {
        if (s1.Length != s2.Length && s1.Length > 0)
            return false;

        var s1Doubled = s1 + s1;
        return s1Doubled.Contains(s2);
    }
}
