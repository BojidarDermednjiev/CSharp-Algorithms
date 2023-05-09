namespace _06._Road_Reconstruction
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Edge
    {
        public Edge(int first, int second)
        {
            First = first;
            Second = second;
        }

        public int First { get; set; }
        public int Second { get; set; }
        public override string ToString()
            => $"{First} {Second}";
    }
    public class StartUp
    {
        private static List<int>[] graph;
        private static List<Edge> edges;
        private static bool[] visited;
        static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            var streets = int.Parse(Console.ReadLine());
            graph = new List<int>[size];
            edges= new List<Edge>();
            for (int node = 0; node < graph.Length; node++)
                graph[node] = new List<int>();
            for (int currentStreet = 0; currentStreet < streets; currentStreet++)
            {
                var edgeParts = Console.ReadLine().Split(" - ").Select(x => int.Parse(x)).ToArray();
                var firstNode = edgeParts[0];
                var secondNode = edgeParts[1];
                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);
                edges.Add(new Edge(firstNode, secondNode));
            }
            Console.WriteLine($"Important streets:");
            foreach (var edge in edges)
            {
                graph[edge.First].Remove(edge.Second);
                graph[edge.Second].Remove(edge.First);
                visited = new bool[graph.Length];
                DFS(default(int));
                if (visited.Contains(false))
                {
                    var newEdge = new Edge(Math.Min(edge.First, edge.Second), Math.Max(edge.First, edge.Second));
                    Console.WriteLine(newEdge);
                }
                graph[edge.First].Add(edge.Second);
                graph[edge.Second].Add(edge.First);
            }
        }
        private static void DFS(int node)
        {
            if (visited[node])
                return;
            visited[node] = true;
            foreach (var child in graph[node])
                DFS(child);
        }
    }
}
