namespace _02._Rumors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static Dictionary<int, int> distances;
        private static List<int>[] graph;
        private static int startPoint;
        static void Main()
            => Engine();
        private static void Engine()
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());
            graph = new List<int>[numberOfPeople + 1];
            for (int node = 0; node < graph.Length; node++)
                graph[node] = new List<int>();
            for (int egde = 0; egde < edges; egde++)
            {
                int[] inputLineFromConsole = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                var from = inputLineFromConsole.First();
                var to = inputLineFromConsole.Skip(1).First();
                if (graph[to].Contains(from) && graph[from].Contains(to))
                    continue;
                graph[from].Add(to);
                graph[to].Add(from);
            }
            BFS();
            Print();
        }
        private static void BFS()
        {
            startPoint = int.Parse(Console.ReadLine());
            distances = new Dictionary<int, int>();
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(startPoint);
            distances[startPoint] = 0;
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                foreach (int neighbor in graph[node])
                    if (!distances.ContainsKey(neighbor))
                    {
                        distances[neighbor] = distances[node] + 1;
                        queue.Enqueue(neighbor);
                    }
            }
        }
        private static void Print()
        {
            var sortedDistance = distances.OrderBy(x => x.Key);
            foreach (KeyValuePair<int, int> kvp in sortedDistance)
            {
                if (kvp.Key == startPoint)
                    continue;
                Console.WriteLine($"{startPoint} -> {kvp.Key} ({kvp.Value})");
            }
        }
    }
}
