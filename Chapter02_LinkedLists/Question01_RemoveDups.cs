namespace Chapter02_LinkedLists;

public class Question01_RemoveDups
{
    public static void Run()
    {
        var first = new LinkedListNode(0, null!, null!);
        var originalList = first;
        var second = first;

        for (var i = 1; i < 8; i++)
        {
            second = new LinkedListNode(i % 2, null!, null!);
            first.SetNext(second);
            second.SetPrevious(first);
            first = second;
        }

        var list1 = originalList.Clone();
        var list2 = originalList.Clone();
        DeleteDupsV1(list1);
        DeleteDupsV2(list2);

        Console.WriteLine(originalList.PrintForward());
        Console.WriteLine(list1.PrintForward());
        Console.WriteLine(list2.PrintForward());
    }

    private static void DeleteDupsV1(LinkedListNode node)
    {
        var dict = new Dictionary<int, bool>();
        LinkedListNode lastUnique = null!;

        while (node != null)
        {
            if (dict.ContainsKey(node.Data) && lastUnique is not null)
            {
                lastUnique.SetNext(node.Next);
            }
            else
            {
                dict.Add(node.Data, true);
                lastUnique = node;
            }
            node = node.Next;
        }
    }

    public static void DeleteDupsV2(LinkedListNode head)
    {
        LinkedListNode current = head;
        while (current != null)
        {
            // Remove all future nodes that have the same value
            LinkedListNode runner = current;
            while (runner.Next != null)
            {
                if (runner.Next.Data == current.Data)
                    runner.SetNext(runner.Next.Next);
                else
                    runner = runner.Next;
            }
            current = current.Next;
        }
    }
}
