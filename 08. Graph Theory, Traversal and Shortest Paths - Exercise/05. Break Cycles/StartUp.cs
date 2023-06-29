namespace _05._Break_Cycles
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Edge
    {
        public Edge(string first, string second)
        {
            First = first;
            Second = second;
        }
        public string First { get; set; }
        public string Second { get; set; }
        public override string ToString()
             => $"{First} - {Second}";
    }
    public class StartUp
    {
        private static Dictionary<string, List<string>> graph;
        private static List<Edge> edges;
        static void Main()
        {
            graph = new Dictionary<string, List<string>>();
            edges = new List<Edge>();
            var size = int.Parse(Console.ReadLine());
            for (int currentIndex = 0; currentIndex < size; currentIndex++)
            {
                var nodeAndChildren = Console.ReadLine().Split(" -> ");
                var node = nodeAndChildren[0];
                var children = nodeAndChildren[1].Split().ToList();
                graph[node] = children;
                foreach (var child in children)
                    edges.Add(new Edge(node, child));
            }
            edges = edges.OrderBy(x => x.First).ThenBy(x => x.Second).ToList();
            var reversedEdges = new HashSet<string>();
            var removedEdges = new List<Edge>();
            foreach (var edge in edges)
            {
                var removed = graph[edge.First].Remove(edge.Second) && graph[edge.Second].Remove(edge.First);
                if (!removed)
                    continue;
                if (reversedEdges.Contains(edge.ToString()))
                    continue;
                if (BFS(edge.First, edge.Second))
                    removedEdges.Add(edge);
                else
                {
                    graph[edge.First].Add(edge.Second);
                    graph[edge.Second].Add(edge.First);
                }
            }
            Console.WriteLine($"Edges to remove: {removedEdges.Count}");
            removedEdges.ForEach(x => Console.WriteLine(x));
        }
        private static bool BFS(string start, string destination)
        {
            var queue = new Queue<string>();
            queue.Enqueue(start);
            var visited = new HashSet<string>() { start };
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node == destination)
                    return true;
                foreach (var child in graph[node])
                {
                    if (visited.Contains(child))
                        continue;
                    visited.Add(child);
                    queue.Enqueue(child);
                }
            }
            return false;
        }
    }
}