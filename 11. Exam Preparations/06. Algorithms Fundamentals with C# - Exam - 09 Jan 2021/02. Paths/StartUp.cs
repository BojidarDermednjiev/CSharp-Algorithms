namespace _02._Paths
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<int>[] adj = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                string[] children = Console.ReadLine().Split(' ');
                adj[i] = new List<int>();
                foreach (string child in children)
                {
                    if (!string.IsNullOrEmpty(child))
                        adj[i].Add(int.Parse(child));
                }
            }
            for (int i = 0; i < n - 1; i++)
            {
                DFS(adj, i, new List<int>());
            }
        }

        private static void DFS(List<int>[] adj, int node, List<int> path)
        {
            path.Add(node);
            if (node == adj.Length - 1)
            {
                Console.WriteLine(string.Join(" ", path));
            }
            else
            {
                foreach (int child in adj[node])
                {
                    DFS(adj, child, path);
                }
            }
            path.RemoveAt(path.Count - 1);
        }
    }
}
