namespace _04._Salaries
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static List<int>[] graph;
        private static Dictionary<int, int> visited;
        static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            graph = new List<int>[size];
            visited = new Dictionary<int, int>();
            for (int node = 0; node < size; node++)
            {
                graph[node] = new List<int>();
                var nodeChildren = Console.ReadLine();
                for (int child = 0; child < nodeChildren.Length; child++)
                {
                    if (nodeChildren[child] == 'Y')
                        graph[node].Add(child);
                }
            }
            var salary = default(int);
            for (int node = 0; node < graph.Length; node++)
            {
               salary += DFS(node);
            }
            Console.WriteLine(salary);
        }

        private static int DFS(int node)
        {
            if (visited.ContainsKey(node))
                return visited[node];
            var salary = default(int);
            if (graph[node].Count == 0)
                salary = 1;
            else
                foreach (var child in graph[node])
                    salary += DFS(child);
            visited[node] = salary;
            return salary;
        }
    }
}
