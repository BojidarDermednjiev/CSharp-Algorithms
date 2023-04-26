namespace _03._Connected_Areas_in_Matrix
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    public class Area
    {
        public Area(int row, int col, int sice)
        {
            Row = row;
            Col = col;
            Sice = sice;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public int Sice { get; set; }
    }
    public class StartUp
    {
        private static char[,] matrix;
        private static int size = default;
        private const char VisitedSymbol = 'v';
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());
            matrix = new char[rows, cols];
            for (int currenRow = 0; currenRow < rows; currenRow++)
            {
                var colElements = Console.ReadLine();
                for (int currentCol = 0; currentCol < cols; currentCol++)
                    matrix[currenRow, currentCol] = colElements[currentCol];
            }
            var areas = new List<Area>();
            for (int currentRow = 0; currentRow < rows; currentRow++)
                for (int currentCol = 0; currentCol < cols; currentCol++)
                {
                    size = default;
                    ExploreArea(currentRow, currentCol);
                    if (size != default)
                        areas.Add(new Area(currentRow, currentCol, size));
                }
            var sorted = areas.Where(x => x.Sice > 0).OrderByDescending(x => x.Sice).ThenBy(x => x.Row).ThenBy(x => x.Col).ToList();
            Console.WriteLine($"Total areas found: {areas.Count}");
            for (int currentArea = 0; currentArea < sorted.Count; currentArea++)
            {
                var area = sorted[currentArea];
                Console.WriteLine($"Area #{currentArea + 1} at ({area.Row}, {area.Col}), size: {area.Sice}");
            }
        }
        private static void ExploreArea(int row, int col)
        {
            if (IsOutside(row, col) || IsWall(row, col) || IsVisided(row, col))
                return;
            size += 1;
            matrix[row, col] = VisitedSymbol;
            ExploreArea(row - 1, col);
            ExploreArea(row + 1, col);
            ExploreArea(row, col - 1);
            ExploreArea(row, col + 1);
        }
        private static bool IsOutside(int row, int col)
            => row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1);
        private static bool IsWall(int row, int col)
            => matrix[row, col] == '*';
        private static bool IsVisided(int row, int col)
        => matrix[row, col] == VisitedSymbol;
    }
}
