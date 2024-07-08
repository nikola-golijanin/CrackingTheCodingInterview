
namespace Chapter02_LinkedLists;

public class Question02_ReturnKthToLast
{
    public static void Run()
    {
        var head = LinkedListHelpers.RandomLinkedList(10, 0, 10);

        const int k = 3;
        var newHead = KthToLast(head, k);


        Console.WriteLine(head.PrintForward());
        Console.WriteLine(newHead.PrintForward());
    }

    private static LinkedListNode KthToLast(LinkedListNode head, int k)
    {
        if (k < 0) return null!;

        var p1 = head;
        var p2 = head;

        for (var i = 0; i < k; i++)
        {
            if (p1 is null) return null!;

            p1 = p1.Next;
        }

        while (p1 != null)
        {
            p2 = p2.Next;
            p1 = p1.Next;
        }

        return p2;
    }
}
