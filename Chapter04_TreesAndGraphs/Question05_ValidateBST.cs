using Chapter04_TreesAndGraphs.Utils;

namespace Chapter04_TreesAndGraphs;

public class Question05_ValidateBST
{
    public static void Run()
    {
        var root = Question02_MinimalTree.Create(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        PrintTree(root);

        root = new TreeNode(2);
        root.SetLeftChild(new TreeNode(1));
        root.Left.SetLeftChild(new TreeNode(3));
        PrintTree(root);
        Console.ReadLine();
    }

    private static bool IsValidBST(TreeNode root)
    {
        return IsValidBST(root, null, null);
    }

    private static bool IsValidBST(TreeNode node, int? min, int? max)
    {
        if (node is null) return true;

        if ((min is not null && node.Data <= min) || (max is not null && node.Data > max))
            return false;

        if (!IsValidBST(node.Left, min, node.Data) || !IsValidBST(node.Right, node.Data, max))
            return false;

        return true;
    }

    private static void PrintTree(TreeNode root)
    {
        BTreePrinter.Print(root);
        var isValidBST = IsValidBST(root);

        if (isValidBST)
            Console.WriteLine("Tree is a valid BST");
        else
            Console.WriteLine("Tree is not a valid BST");
    }
}
