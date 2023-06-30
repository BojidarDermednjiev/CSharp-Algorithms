namespace _02._Paths
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main()
        {
            int nodes = int.Parse(Console.ReadLine());
            List<int>[] graph = new List<int>[nodes];
            for (int currentNode = 0; currentNode < nodes; currentNode++)
            {
                string[] children = Console.ReadLine().Split(' ');
                graph[currentNode] = new List<int>();

                foreach (string child in children)
                    if (!string.IsNullOrEmpty(child))
                        graph[currentNode].Add(int.Parse(child));

            }
            for (int startedNote = 0; startedNote < nodes - 1; startedNote++)
                DFS(graph, startedNote, new List<int>());
        }

        private static void DFS(List<int>[] graph, int node, List<int> path)
        {
            path.Add(node);
            if (node == graph.Length - 1)
                Console.WriteLine(string.Join(" ", path));
            else
                foreach (int child in graph[node])
                    DFS(graph, child, path);

            path.RemoveAt(path.Count - 1);
        }
    }
}
