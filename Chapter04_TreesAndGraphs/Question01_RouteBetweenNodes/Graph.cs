namespace Chapter04_TreesAndGraphs.Question01_RouteBetweenNodes;

public class Graph
{
    public static int MAX_VERTICES = 6;
    public Node[] Nodes { get; private set; }
    public int count;
    public Graph()
    {
        Nodes = new Node[MAX_VERTICES];
        count = 0;
    }

    public void AddNode(Node x)
    {
        if (count < Nodes.Length)
        {
            Nodes[count] = x;
            count++;
        }
        else
        {
            Console.WriteLine("Graph full");
        }
    }
}
