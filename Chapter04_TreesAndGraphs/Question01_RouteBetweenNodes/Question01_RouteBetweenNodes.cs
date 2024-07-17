namespace Chapter04_TreesAndGraphs.Question01_RouteBetweenNodes;

public class Question01_RouteBetweenNodes
{
    public static void Run()
    {
        Graph g = CreateNewGraph();
        Node[] n = g.Nodes;
        Node start = n[3];
        Node end = n[5];
        Console.WriteLine(Search(g, start, end));
    }

    public static Graph CreateNewGraph()
    {
        var graph = new Graph();
        Node[] temp =
        [
            new Node("a", 3),
            new Node("b", 0),
            new Node("c", 0),
            new Node("d", 1),
            new Node("e", 1),
            new Node("f", 0),
        ];

        temp[0].AddAdjacent(temp[1]);
        temp[0].AddAdjacent(temp[2]);
        temp[0].AddAdjacent(temp[3]);
        temp[3].AddAdjacent(temp[4]);
        temp[4].AddAdjacent(temp[5]);
        for (int i = 0; i < 6; i++)
        {
            graph.AddNode(temp[i]);
        }
        return graph;
    }

    static bool Search(Graph graph, Node start, Node end)
    {

        if (start == end) return true;

        var queue = new Queue<Node>();
        foreach (var node in graph.Nodes)
        {
            node.State = State.Unvisited;
        }

        start.State = State.Visiting;
        queue.Enqueue(start);
        Node u;
        while (queue.Count > 0)
        {
            u = queue.Dequeue();
            if (u is not null)
            {
                foreach (var v in u.Adjacent)
                {
                    if (v.State == State.Unvisited)
                    {
                        if (v == end) return true;
                        else
                        {
                            v.State = State.Visiting;
                            queue.Enqueue(v);
                        }
                    }
                }
                u.State = State.Visited;
            }
        }
        return false;
    }
}

public enum State
{
    Unvisited, Visited, Visiting
}