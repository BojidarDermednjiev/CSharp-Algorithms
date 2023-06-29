namespace _01._TBC
{
    using System;
    public class StartUp
    {
        private static char[,] map;
        private const char VisitedSymbol = 'v';
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());
            map = new char[rows, cols];

            for (int currenRow = 0; currenRow < rows; currenRow++)
            {
                var colElements = Console.ReadLine();
                for (int currentCol = 0; currentCol < cols; currentCol++)
                    map[currenRow, currentCol] = colElements[currentCol];
            }

            int count = default(int);

            for (int row = 0; row < rows; row++)
                for (int col = 0; col < cols; col++)
                    if (map[row, col] == 't')
                    {
                        count++;
                        DFS(row, col);
                    }
            Console.WriteLine(count);
        }
        private static void DFS(int rol, int col)
        {
            if (IsOutside(rol, col))
                return;
            if (IsWall(rol, col) || IsVisided(rol, col))
                return;

            map[rol, col] = 'v';

            DFS(rol - 1, col - 1);
            DFS(rol - 1, col);
            DFS(rol - 1, col + 1);
            DFS(rol, col - 1);
            DFS(rol, col + 1);
            DFS(rol + 1, col - 1);
            DFS(rol + 1, col);
            DFS(rol + 1, col + 1);
        }
        private static bool IsOutside(int row, int col)
           => row < 0 || col < 0 || row >= map.GetLength(0) || col >= map.GetLength(1);
        private static bool IsWall(int row, int col)
            => map[row, col] == 'd';
        private static bool IsVisided(int row, int col)
        => map[row, col] == VisitedSymbol;
    }
}