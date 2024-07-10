namespace Chapter02_LinkedLists;

public class Question07_Intersection
{
    public static void Run()
    {
        int[] vals = { -1, -2, 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        LinkedListNode list1 = LinkedListHelpers.CreateLinkedListFromArray(vals);

        int[] vals2 = { 12, 14, 15 };
        LinkedListNode list2 = LinkedListHelpers.CreateLinkedListFromArray(vals2);

        list2.Next.SetNext(list1.Next.Next.Next.Next);

        Console.WriteLine(list1.PrintForward());
        Console.WriteLine(list2.PrintForward());

        LinkedListNode intersection = FindIntersectionV1(list1, list2);

        Console.WriteLine(intersection.PrintForward());
    }

    private static LinkedListNode FindIntersectionV1(LinkedListNode list1, LinkedListNode list2)
    {
        if (list1 is null || list2 is null) return LinkedListNode.Empty();

        //Calculate length and check if tails are equal
        var (tail1, size1) = GetTailAndSize(list1);
        var (tail2, size2) = GetTailAndSize(list2);

        if (tail1 != tail2) return LinkedListNode.Empty();

        //Set pointers to start of lists
        var shorter = size1 < size2 ? list1 : list2;
        var longer = size1 < size2 ? list2 : list1;

        //Move longer pointer for lenDiff places
        longer = MoveLongerForLenDiff(longer, Math.Abs(size2 - size1));

        //Move both pointers until we have collision
        while (shorter != longer)
        {
            shorter = shorter.Next;
            longer = longer.Next;
        }

        //Return shorter or longer, it should be the same :)
        return shorter;
    }

    private static LinkedListNode MoveLongerForLenDiff(LinkedListNode longer, int lenDiff)
    {
        var current = longer;
        for (int i = 0; i < lenDiff; i++)
        {
            current = current.Next;
        }

        return current;
    }

    private static (LinkedListNode tail, int size) GetTailAndSize(LinkedListNode node)
    {
        var len = 0;

        while (node != null && node.Next != null)
        {
            len++;
            node = node.Next;
        }

        return (node!, len);
    }

    private static LinkedListNode FindIntersectionV2(LinkedListNode list1, LinkedListNode list2)
    {
        if (list1 is null && list2 is null) return LinkedListNode.Empty();
        var dict = new Dictionary<LinkedListNode, bool>();

        var p1 = list1;
        var p2 = list2;

        while (p1 != null)
        {
            dict.Add(p1, true);
            p1 = p1.Next;
        }

        while (p2 != null)
        {
            if (dict.ContainsKey(p2)) return p2;
            p2 = p2.Next;
        }

        return LinkedListNode.Empty();
    }
}
