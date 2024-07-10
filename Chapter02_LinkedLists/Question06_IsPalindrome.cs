namespace Chapter02_LinkedLists;

public class Question06_IsPalindrome
{
    public static void Run()
    {
        const int length = 10;
        var nodes = new LinkedListNode[length];

        for (var i = 0; i < length; i++)
        {
            nodes[i] = new LinkedListNode(i >= length / 2 ? length - i - 1 : i, null!, null!);
        }

        for (var i = 0; i < length; i++)
        {
            if (i < length - 1)
            {
                nodes[i].SetNext(nodes[i + 1]);
            }

            if (i > 0)
            {
                nodes[i].SetPrevious(nodes[i - 1]);
            }
        }
        // nodes[length - 2].Data = 9; // Uncomment to ruin palindrome

        var head = nodes[0];

        Console.WriteLine(head.PrintForward());
        Console.WriteLine($"Is Palindrome: {IsPalindromeV1(head)}");
        Console.WriteLine($"Is Palindrome V2: {IsPalindromeV2(head)}");
        Console.WriteLine($"Is Palindrome V3: {IsPalindromeV3(head)}");
    }

    private static bool IsPalindromeV1(LinkedListNode head)
    {
        var pointer = head;
        var stack = new Stack<LinkedListNode>();
        while (pointer is not null)
        {
            stack.Push(pointer);
            pointer = pointer.Next;
        }

        //reset pointer to head
        pointer = head;

        while (pointer is not null)
        {
            var current = stack.Pop();
            if (current.Data != pointer.Data) return false;
            pointer = pointer.Next;
        }

        return true;
    }

    private static bool IsPalindromeV2(LinkedListNode head)
    {
        var reversed = ReverseList(head);
        return Compare(head, reversed);
    }

    private static bool Compare(LinkedListNode head, LinkedListNode reversedListHead)
    {
        while (head is not null && reversedListHead is not null)
        {
            if (head.Data != reversedListHead.Data) return false;

            head = head.Next;
            reversedListHead = reversedListHead.Next;
        }
        return true;
    }

    private static LinkedListNode ReverseList(LinkedListNode head)
    {
        LinkedListNode newHead = null!;

        while (head is not null)
        {
            var newNode = new LinkedListNode(head.Data, null!, null!);
            newNode.SetNext(newHead);
            newHead = newNode;
            head = head.Next;
        }
        return newHead;
    }

    private static bool IsPalindromeV3(LinkedListNode head)
    {
        int len = LengthOfList(head);
        var (node, result) = IsPalindromeRecurse(head, len);

        return result;
    }

    private static (LinkedListNode? node, bool result) IsPalindromeRecurse(LinkedListNode head, int length)
    {
        if (head == null || length <= 0) return (head, true);

        if (length == 1) return (head.Next, true);

        var (node, result) = IsPalindromeRecurse(head.Next, length - 2);

        if (!result || node == null) return (node, result);

        result = head.Data == node.Data;
        node = node.Next;

        return (node, result);
    }

    private static int LengthOfList(LinkedListNode n)
    {
        var size = 0;
        while (n != null)
        {
            size++;
            n = n.Next;
        }
        return size;
    }
}