using Chapter04_TreesAndGraphs.Utils;

namespace Chapter04_TreesAndGraphs;

public class Question03_ListOfDepths
{
    public static void Run()
    {
        var tree = Question02_MinimalTree.Create(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        var listOfDepths = ListOfDepthsV1(tree);
        var listOfDepths2 = ListOfDepthsV2(tree);

        BTreePrinter.Print(tree);

        Console.Write($"Print ListOfDepthsV1 result:");
        Console.WriteLine();
        foreach (var list in listOfDepths)
        {
            foreach (var sbList in list)
                Console.Write($"{sbList.Data},");
            Console.WriteLine();
        }

        Console.Write($"Print ListOfDepthsV2 result:");
        Console.WriteLine();
        foreach (var list in listOfDepths2)
        {
            foreach (var sbList in list)
                Console.Write($"{sbList.Data},");
            Console.WriteLine();
        }
    }

    private static List<List<TreeNode>> ListOfDepthsV1(TreeNode root)
    {
        List<List<TreeNode>> lists = [];
        CreateLevelList(root, lists, 0);
        return lists;
    }

    private static void CreateLevelList(TreeNode root, List<List<TreeNode>> lists, int level)
    {
        if (root is null) return;

        List<TreeNode> list;
        if (lists.Count == level) // Level not contained in list
        {
            list = []; // Init the list
            // Levels are always traversed in order. 
            // So, if this is the first time we've visited level i, we must have seen levels 0 through i - 1.
            // We can therefore safely add the level at the end.
            lists.Add(list);
        }
        else
        {
            list = lists[level];
        }
        list.Add(root);
        CreateLevelList(root.Left, lists, level + 1);
        CreateLevelList(root.Right, lists, level + 1);
    }

    private static List<List<TreeNode>> ListOfDepthsV2(TreeNode root)
    {
        var result = new List<List<TreeNode>>();
        // Visit the root
        var current = new List<TreeNode>();
        if (root is not null)
            current.Add(root);

        while (current.Count > 0)
        {
            result.Add(current); // Add previous level
            var parents = current; // Go to next level
            current = [];
            foreach (var parent in parents)
            {
                // Visit the children
                if (parent.Left is not null)
                    current.Add(parent.Left);
                if (parent.Right is not null)
                    current.Add(parent.Right);
            }
        }
        return result;
    }
}
