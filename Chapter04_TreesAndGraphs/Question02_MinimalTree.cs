using Chapter04_TreesAndGraphs.Utils;

namespace Chapter04_TreesAndGraphs;

public class Question02_MinimalTree
{
    public static void Run()
    {
        var root = Create(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        BTreePrinter.Print(root);
    }

    public static TreeNode Create(params int[] sortedArray)
    {
        return Create(sortedArray, 0, sortedArray.Length - 1);
    }

    private static TreeNode Create(int[] sortedArray, int start, int end)
    {
        if (start > end) return null!;
        var mid = (start + end) / 2;
        var node = new TreeNode(sortedArray[mid])
        {
            Left = Create(sortedArray, start, mid - 1),
            Right = Create(sortedArray, mid + 1, end)
        };
        return node;
    }
}
