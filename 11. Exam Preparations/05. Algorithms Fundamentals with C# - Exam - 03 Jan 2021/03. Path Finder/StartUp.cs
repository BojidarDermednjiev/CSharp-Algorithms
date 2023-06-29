namespace _03._Path_Finder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public class StartUp
    {
        static int n;
        static List<int>[] graph;

        static void Main()
        {
            int nodes = int.Parse(Console.ReadLine());
            List<int>[] graph = new List<int>[nodes];
            for (int node = 0; node < nodes; node++)
            {
                string[] children = Console.ReadLine().Split();
                graph[node] = new List<int>();

                foreach (string child in children)
                    if (child != string.Empty)
                        graph[node].Add(int.Parse(child));
                
            }
            int numberOfSearching = int.Parse(Console.ReadLine());
            for (int currentSearch = 0; currentSearch < numberOfSearching; currentSearch++)
            {
                string[] pathNodes = Console.ReadLine().Split();
                int[] path = new int[pathNodes.Length];
                for (int currentPath = 0; currentPath < pathNodes.Length; currentPath++)
                    path[currentPath] = int.Parse(pathNodes[currentPath]);

                Console.WriteLine(CheckPathExists(graph, path) ? "yes" : "no");
            }
        }
        static bool CheckPathExists(List<int>[] graph, int[] path)
        {
            int current = path[0];
            for (int currentPath = 1; currentPath < path.Length; currentPath++)
            {
                if (!graph[current].Contains(path[currentPath]))
                    return false;

                current = path[currentPath];
            }
            return true;
        }
    }
}