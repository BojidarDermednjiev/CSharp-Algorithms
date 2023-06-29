namespace Third
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    public class StartUp
    {
        private static List<int>[] graph;
        private static bool[] visited;
        static void Main()
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());
            graph = new List<int>[nodes + 1];
            for (int node = 0; node < graph.Length; node++)
                graph[node] = new List<int>();
            for (int currentEdge = 0; currentEdge < edges; currentEdge++)
            {
                var edge = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
                var from = edge[0];
                var to = edge[1];
                graph[from].Add(to);
            }
            var startNode = int.Parse(Console.ReadLine());
            visited = new bool[nodes + 1];
            DFS(startNode);
            var sb = new StringBuilder();
            for (int node = 1; node < visited.Length; node++)
            {
                if (!visited[node])
                    sb.Append($"{node} ");
            }
            Console.WriteLine(sb.ToString().TrimEnd());
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