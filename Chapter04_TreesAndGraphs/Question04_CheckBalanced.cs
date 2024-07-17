using Chapter04_TreesAndGraphs.Utils;

namespace Chapter04_TreesAndGraphs;

public class Question04_CheckBalanced
{
    public static void Run()
    {
        var root = Question02_MinimalTree.Create(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        PrintTree(root);

        root = new TreeNode(2);
        root.SetLeftChild(new TreeNode(1));
        root.Left.SetLeftChild(new TreeNode(3));
        PrintTree(root);
        Console.ReadKey();
    }

    private static bool IsBalanced(TreeNode root)
    {
        return GetHeight(root) != int.MinValue;
    }

    private static int GetHeight(TreeNode root)
    {
        if (root is null) return -1;

        int leftHeight = GetHeight(root.Left);
        if (leftHeight == int.MinValue) return int.MinValue;

        int rightHeight = GetHeight(root.Right);
        if (rightHeight == int.MinValue) return int.MinValue;

        if (Math.Abs(leftHeight - rightHeight) > 1) return int.MinValue;
        return Math.Max(leftHeight, rightHeight) + 1;

    }

    private static void PrintTree(TreeNode root)
    {
        BTreePrinter.Print(root);

        if (IsBalanced(root))
            Console.WriteLine("Tree is balanced");
        else
            Console.WriteLine("Tree is not balalnced");
    }
}
