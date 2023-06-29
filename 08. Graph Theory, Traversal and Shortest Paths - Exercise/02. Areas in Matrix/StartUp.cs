namespace _02._Areas_in_Matrix
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static char[,] graph;
        private static bool[,] visited;
        private static SortedDictionary<char, int> areas;

        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());
            graph = new char[rows, cols];
            visited = new bool[rows, cols];
            areas = new SortedDictionary<char, int>();
            var areasCount = default(int);
            FIllMatrix();
            areasCount = Engine(areasCount);
            IO(areasCount);
        }
        private static void FIllMatrix()
        {
            for (int row = 0; row < graph.GetLength(0); row++)
            {
                var elements = Console.ReadLine();
                for (int col = 0; col < graph.GetLength(1); col++)
                    graph[row, col] = elements[col];
            }
        }
        private static int Engine(int areasCount)
        {
            for (int row = 0; row < visited.GetLength(0); row++)
            {
                for (int col = 0; col < visited.GetLength(1); col++)
                {
                    if (visited[row, col])
                        continue;
                    var nodeValue = graph[row, col];
                    DFS(row, col, nodeValue);
                    areasCount++;
                    if (areas.ContainsKey(nodeValue))
                        areas[nodeValue] += 1;
                    else
                        areas[nodeValue] = 1;
                }
            }
            return areasCount;
        }
        private static void DFS(int row, int col, char parentNode)
        {
            if (row < 0 || row >= graph.GetLength(0) || col < 0 || col >= graph.GetLength(1))
                return;
            if (visited[row, col])
                return;
            if (graph[row, col] != parentNode)
                return;
            visited[row, col] = true;
            DFS(row, col - 1, parentNode);
            DFS(row, col + 1, parentNode);
            DFS(row - 1, col, parentNode);
            DFS(row + 1, col, parentNode);
        }
        private static void IO(int areasCount)
        {
            Console.WriteLine($"Areas: {areasCount}");
            foreach (var area in areas)
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
        }
    }
}