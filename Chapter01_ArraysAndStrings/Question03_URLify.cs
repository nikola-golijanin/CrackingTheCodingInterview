using System.Text;

namespace Chapter01_ArraysAndStrings;

public class Question03_URLify
{
    public static void Run()
    {
        var s = "abc d e f";
        var result = URLifyV1(s);
        Console.WriteLine("URLify " + result);
        var result2 = URLifyV2(s);
        Console.WriteLine("URLify2 " + result2);
    }

    private static string URLifyV1(string text)
    {
        return text.Replace(" ", "%20");
    }

    private static string URLifyV2(string text)
    {
        var stringBuilder = new StringBuilder();
        var content = text.ToCharArray();
        foreach (char c in content)
        {
            ReplaceSpace(c, stringBuilder);

        }
        return stringBuilder.ToString();
    }

    private static readonly Action<char, StringBuilder> ReplaceSpace = (c, sb) =>
    {
        _ = ' '.Equals(c) ? sb.Append("%20") : sb.Append(c);
    };
}
