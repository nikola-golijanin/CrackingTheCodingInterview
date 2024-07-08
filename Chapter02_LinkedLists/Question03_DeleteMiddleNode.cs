
namespace Chapter02_LinkedLists;

public class Question03_DeleteMiddleNode
{
    public static void Run()
    {
        var head = LinkedListHelpers.RandomLinkedList(10, 0, 10);

        var nodeToDelete = head.Next.Next.Next.Next;
        Console.WriteLine("Node with value {0} should be deleted", nodeToDelete.Data);
        Console.WriteLine("Input list: " + head.PrintForward());
        var deleted = DeleteMiddleNode(nodeToDelete); // delete node 4
        Console.WriteLine("Output list: " + head.PrintForward());
        Console.WriteLine("deleted? {0}", deleted);
    }

    private static bool DeleteMiddleNode(LinkedListNode node)
    {
        ArgumentNullException.ThrowIfNull(node, "Input node can not be null!");
        ArgumentNullException.ThrowIfNull(node.Next, "Input node can not be last in list!");

        var next = node.Next;
        node.SetNext(next.Next);
        node.Data = next.Data;
        return true;
    }
}
