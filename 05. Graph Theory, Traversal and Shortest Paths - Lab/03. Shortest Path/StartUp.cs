namespace _03._Shortest_Path
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] parent;
        static void Main()
        {
            var sizeOfGraph = int.Parse(Console.ReadLine());
            var edge = int.Parse(Console.ReadLine());

            graph = new List<int>[sizeOfGraph + 1];
            visited = new bool[graph.Length];
            parent = new int[graph.Length];
            for (int node = 0; node < graph.Length; node++)
                graph[node] = new List<int>();
            Array.Fill(parent, -1);
            for (int currentEdge = 0; currentEdge < edge; currentEdge++)
            {
                var inputLineFromConsole = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                var firstNode = inputLineFromConsole[0];
                var secondNode = inputLineFromConsole[1];
                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);
            }
            var start = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());
            BFS(start, destination);
        }

        private static void BFS(int startNode, int destination)
        {
            var queue = new Queue<int>();
            queue.Enqueue(startNode);
            visited[startNode] = true;
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (destination == node)
                {
                    var path = GetPath(destination);
                    Console.WriteLine($"Shortest path length is: {path.Count - 1}");
                    Console.WriteLine(string.Join(" ", path));
                    break;
                }
                foreach (var child in graph[node])
                    if (!visited[child])
                    {
                        parent[child] = node;
                        visited[child] = true;
                        queue.Enqueue(child);
                    }
            }
        }
        private static Stack<int> GetPath(int destination)
        {
            var path = new Stack<int>();
            var node = destination;
            while (node != -1)
            {
                path.Push(node);
                node = parent[node];
            }
            return path;
        }
    }
}
