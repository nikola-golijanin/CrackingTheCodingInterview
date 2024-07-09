namespace Chapter02_LinkedLists;

public class Question05_SumLists
{
    public static void Run()
    {
        /* Create linked list */
        var l1 = LinkedListHelpers.RandomLinkedList(4, 0, 9);
        var l2 = LinkedListHelpers.RandomLinkedList(7, 0, 9);


        Console.WriteLine(" " + l1.PrintForward());
        Console.WriteLine("+");
        Console.WriteLine(" " + l2.PrintForward());
        Console.WriteLine("=");
        var resultList = SumLists(l1, l2);
        Console.WriteLine(" " + resultList.PrintForward());
    }


    private static LinkedListNode SumLists(LinkedListNode l1, LinkedListNode l2)
    {
        var p1 = l1;
        var p2 = l2;
        var carry = 0;
        var head = new LinkedListNode();
        var pointer = head;

        while (p1 != null || p2 != null)
        {
            var newNode = (p1, p2) switch
            {
                (null, null) => null,
                (null, _) => CreateNewNode(p2, ref carry),
                (_, null) => CreateNewNode(p1, ref carry),
                (_, _) => CreateNewNode(p1, p2, ref carry)
            };

            pointer.SetNext(newNode!);
            pointer = pointer.Next;
            p1 = p1?.Next;
            p2 = p2?.Next;
        };

        if (carry != 0)
            pointer.SetNext(new LinkedListNode(1, null!, null!));

        return head.Next;
    }


    private static LinkedListNode CreateNewNode(LinkedListNode node, ref int carry)
    {
        var newNodeValue = node.Data + carry;
        carry = newNodeValue / 10;
        return new LinkedListNode(newNodeValue % 10, null!, null!);
    }

    private static LinkedListNode CreateNewNode(LinkedListNode node1, LinkedListNode node2, ref int carry)
    {
        var newNodeValue = node1.Data + node2.Data + carry;
        carry = newNodeValue / 10;
        return new LinkedListNode(newNodeValue % 10, null!, null!);
    }
}
