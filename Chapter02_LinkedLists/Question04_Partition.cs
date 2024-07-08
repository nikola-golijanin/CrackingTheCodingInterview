
namespace Chapter02_LinkedLists;

public class Question04_Partition
{
    public static void Run()
    {
        /* Create linked list */
        var head = LinkedListHelpers.RandomLinkedList(10, 0, 10);

        Console.WriteLine(head.PrintForward());

        /* Partition */
        var newHead = Partition(head, 5);

        /* Print Result */
        Console.WriteLine(newHead.PrintForward());
    }

    private static LinkedListNode Partition(LinkedListNode node, int v)
    {
        LinkedListNode head = node;
        LinkedListNode tail = node;

        while (node is not null)
        {
            var next = node.Next;
            if (node.Data < v)
            {
                /* Insert node at head. */
                node.SetNext(head);
                head = node;
            }
            else
            {
                /* Insert node at tail. */
                tail.SetNext(node);
                tail = node;
            }
            node = next;
        }
        tail.SetNext(null!);
        return head;
    }
}
