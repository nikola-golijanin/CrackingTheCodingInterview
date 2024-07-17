namespace Chapter04_TreesAndGraphs.Question01_RouteBetweenNodes;

public class Node
{
    public Node[] Adjacent { get; private set; }
    public int adjacentCount;
    public string Value { get; private set; }
    public State State;
    public Node(string value, int adjacentLength)
    {
        Value = value;
        adjacentCount = 0;
        Adjacent = new Node[adjacentLength];
    }

    public void AddAdjacent(Node x)
    {
        if (adjacentCount < Adjacent.Length)
        {
            Adjacent[adjacentCount] = x;
            adjacentCount++;
        }
        else
        {
            Console.WriteLine("No more adjacent can be added");
        }
    }
}
