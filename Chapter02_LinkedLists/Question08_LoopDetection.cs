
namespace Chapter02_LinkedLists;

public class Question08_LoopDetection
{
    public static void Run()
    {
        const int listLength = 10;
        const int k = 3;

        // Create linked list
        var nodes = new LinkedListNode[listLength];

        for (var i = 1; i <= listLength; i++)
        {
            nodes[i - 1] = new LinkedListNode(i, null!, i - 1 > 0 ? nodes[i - 2] : null!);
            Console.Write("{0} -> ", nodes[i - 1].Data);
        }
        // Console.WriteLine();

        // Create loop;
        nodes[listLength - 1].SetNext(nodes[listLength - k - 1]);
        Console.WriteLine("{0}", nodes[listLength - k - 1].Data);

        var loop = DetectLoop(nodes[0]);

        if (loop == null)
        {
            Console.WriteLine("No Cycle.");
        }
        else
        {
            Console.WriteLine($"Start of the loop: {loop.Data}");
        }
    }

    private static LinkedListNode DetectLoop(LinkedListNode head)
    {
        var set = new HashSet<LinkedListNode>();
        while (head != null)
        {
            var added = set.Add(head);
            if (!added) return head;
            head = head.Next;
        }

        return null!;
    }
}
