namespace _01._Distance_Between_Vertices
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        private static Dictionary<int, List<int>> graph;
        static void Main()
        {
            graph = new Dictionary<int, List<int>>();
            var nodes = int.Parse(Console.ReadLine());
            var pairs = int.Parse(Console.ReadLine());
            for (int currentNode = 0; currentNode < nodes; currentNode++)
            {
                var nodeAndChildren = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);
                var node = int.Parse(nodeAndChildren[0]);
                if (nodeAndChildren.Length == 1)
                    graph[node] = new List<int>();
                else
                {
                    var children = nodeAndChildren[1].Split().Select(x => int.Parse(x)).ToList();
                    graph[node] = children;
                }
            }
            for (int currentPair = 0; currentPair < pairs; currentPair++)
            {
                var pair = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                var start = pair[0];
                var destination = pair[1];
                var steps = BFA(start, destination);
                Console.WriteLine($"{{{start}, {destination}}} -> {steps}");
            }
        }

        private static int BFA(int start, int destination)
        {
            var queue = new Queue<int>();
            queue.Enqueue(start);
            var visited = new HashSet<int>() { start };
            var parent = new Dictionary<int, int>() { { start, -1 } };
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node == destination)
                    return GetSteps(parent, destination);
                foreach (var child in graph[node])
                {
                    if (visited.Contains(child))
                        continue;
                    visited.Add(child);
                    queue.Enqueue(child);
                    parent[child] = node;
                }
            }
            return -1;
        }

        private static int GetSteps(Dictionary<int, int> parent, int destination)
        {
            var steps = default(int);
            var node = destination;
            while (node != -1)
            {
                node = parent[node];
                steps++;
            }
            return steps - 1;
        }
    }
}