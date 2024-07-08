namespace Chapter02_LinkedLists;

public static class LinkedListHelpers
{
    private static readonly Random RandomIntNumbers = new();
    public static LinkedListNode RandomLinkedList(int N, int min, int max)
    {
        LinkedListNode root = new(RandomIntInRange(min, max), null!, null!);
        LinkedListNode prev = root;
        for (int i = 1; i < N; i++)
        {
            int data = RandomIntInRange(min, max);
            LinkedListNode next = new(data, null!, null!);
            prev.SetNext(next);
            prev = next;
        }
        return root;
    }

    public static int RandomInt(int n) => RandomIntNumbers.Next(n);

    public static int RandomIntInRange(int min, int max) => RandomInt(max + 1 - min) + min;
    
}
