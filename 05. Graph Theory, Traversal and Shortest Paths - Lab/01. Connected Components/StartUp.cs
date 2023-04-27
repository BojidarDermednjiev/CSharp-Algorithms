namespace _01._Connected_Components
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class StartUp
    {
        private static List<int>[] graph;
        private static bool[] visited;
        static void Main()
        {
            var readSizeNumberOfGraph = int.Parse(Console.ReadLine());
            graph = new List<int>[readSizeNumberOfGraph];
            visited = new bool[readSizeNumberOfGraph];
            for (int node = 0; node < readSizeNumberOfGraph; node++)
            {
                var inputLine = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputLine))
                    graph[node] = new List<int>();
                else
                {
                    var children = inputLine.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
                    graph[node] = children;
                }
            }
            for (int node = 0; node < graph.Length; node++)
            {
                if (visited[node])
                    continue;
                var component = new List<int>();
                DFS(node, component);
                BFS(node, component);
                Console.WriteLine($"Connected component: {string.Join(" ", component)}");
            }
        }
        private static void DFS(int node, List<int> component)
        {
            if (visited[node])
                return;
            visited[node] = true;
            foreach (var child in graph[node])
                DFS(child, component);
            component.Add(node);
        }
        private static void BFS(int startNode, List<int> component)
        {
            var queue = new Queue<int>();
            queue.Enqueue(startNode);
            visited[startNode] = true;
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                component.Add(node);
                foreach (var child in graph[node])
                    if (!visited[child])
                    {
                        visited[child] = true;
                        queue.Enqueue(child);
                    }
            }
        }
    }
}
