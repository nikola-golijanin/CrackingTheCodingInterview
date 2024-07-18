using Chapter04_TreesAndGraphs.Utils;

namespace Chapter04_TreesAndGraphs;

public static class Question06_Successor
{
    public static void Run()
    {
        var root = Question02_MinimalTree.Create(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        var node = root.Find(6);
        var successorNode = node.Successor(); // It shoud be 7
        Console.WriteLine($"Successor node of {node.Data} is {successorNode.Data}");
    }

    static public TreeNode Successor(this TreeNode node)
    {
        if (node == null) return null;
        if (node.Right != null) return LeftMost(node.Right);

        var current = node;
        var parent = current.Parent;
        // go up until we're on left instead of right
        while (parent != null && parent.Right == current)
        {
            current = parent;
            parent = current.Parent;
        }
        return parent;
    }

    private static TreeNode LeftMost(TreeNode node)
    {
        while (node.Left != null)
            node = node.Left;
        return node;
    }
}
