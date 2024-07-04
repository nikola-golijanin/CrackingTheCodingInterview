using System.Text;

namespace Chapter01_ArraysAndStrings;

public class Question06_StringCompression
{
    public static void Run()
    {
        Console.WriteLine($"String Compression: {StringCompressionV1("aabcccccaaa")}");
        Console.WriteLine($"String Compression: {StringCompressionV2("aabcccccaaa")}");
    }

    private static string StringCompressionV1(string s)
    {
        var compressed = new StringBuilder();
        var current = s[0];
        var counter = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == current)
            {
                counter++;
                if (IsLastIteration(i, s.Length))
                {
                    compressed.Append(current);
                    compressed.Append(counter);
                }
            }
            else
            {
                compressed.Append(current);
                compressed.Append(counter);
                current = s[i];
                counter = 1;
            }
        }
        return compressed.Length < s.Length ? compressed.ToString() : s;
    }

    private static string StringCompressionV2(string s)
    {
        var compressedLength = CountCompressedString(s);
        if (compressedLength >= s.Length)
            return s;

        var compressed = new StringBuilder(compressedLength);
        var current = s[0];
        var counter = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == current)
            {
                counter++;
                if (IsLastIteration(i, s.Length))
                {
                    compressed.Append(current);
                    compressed.Append(counter);
                }
            }
            else
            {
                compressed.Append(current);
                compressed.Append(counter);
                current = s[i];
                counter = 1;
            }
        }
        return compressed.Length < s.Length ? compressed.ToString() : s;
    }

    private static int CountCompressedString(string s)
    {
        var counter = 0;
        var current = s[0];
        var compressedLength = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == current)
            {
                counter++;
            }
            else
            {
                current = s[i];
                compressedLength += counter;
                counter = 1;
            }
        }
        return compressedLength;
    }

    private static readonly Func<int, int, bool> IsLastIteration = (i, length) => i == length - 1;
}
